using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;

namespace Medicine
{
    class ANote
    {
        public int maxAlignX, maxAlignY, minAlignX, minAlignY;
        public static int nControls = 7;
        public ArrayList CtlList = new ArrayList();
        public Label lblName = new Label();
        public TextBox noteName = new TextBox();
        public Label lblAmount = new Label();
        public NumericUpDown noteAmount = new NumericUpDown();
        public CheckBox[] noteTime = new CheckBox[3];

        public ANote()
        {
            Initializer(0, 0);
        }

        public ANote(int alignX, int alignY)
        {
            Initializer(alignX, alignY);
        }

        public void AddToPanel(Control panel)
        {
            foreach (Control aCtl in CtlList)
            {
                panel.Controls.Add(aCtl);
            }
        }

        public void RemoveFromPanel(Control panel)
        {
            foreach (Control aCtl in CtlList)
            {
                panel.Controls.Remove(aCtl);
            }
        }

        private void Initializer(int alignX, int alignY)
        {
            lblName.Text = "Pill: ";
            lblName.Location = new Point(alignX, alignY);
            lblName.AutoSize = true;
            CtlList.Add(lblName);
            noteName.Location = new Point(lblName.Location.X + lblName.Width + 5, alignY);
            noteName.Name = "noteName" + alignY;
            CtlList.Add(noteName);
            lblAmount.Text = "Amount: ";
            lblAmount.Location = new Point(noteName.Location.X + noteName.Width + 10, alignY);
            lblAmount.AutoSize = true;
            CtlList.Add(lblAmount);
            noteAmount.Location = new Point(lblAmount.Location.X + lblAmount.Width + 5, alignY);
            noteAmount.Width = 50;
            CtlList.Add(noteAmount);
            CheckBox morning = new CheckBox();
            morning.Text = "Morning";
            noteTime[0] = morning;
            morning.Location = new Point(noteAmount.Location.X + noteAmount.Width + 5, alignY);
            CheckBox afternoon = new CheckBox();
            afternoon.Text = "Afternoon";
            noteTime[1] = afternoon;
            afternoon.Location = new Point(morning.Location.X + morning.Width + 5, alignY);
            CheckBox night = new CheckBox();
            night.Text = "Night";
            noteTime[2] = night;
            night.Location = new Point(afternoon.Location.X + afternoon.Width + 5, alignY);
            foreach (CheckBox checkBox in noteTime)
                CtlList.Add(checkBox);
            minAlignX = alignX;
            minAlignY = alignY;
            maxAlignX = getMaxAlignX();
            maxAlignY = getMaxAlignY();
        }

        private int getMaxAlignX()
        {
            int max = minAlignX;
            foreach (Control aCtl in CtlList)
            {
                max = Math.Max(max, aCtl.Location.X + aCtl.Size.Width);
            }
            return max;
        }

        private int getMaxAlignY()
        {
            int max = minAlignY;
            foreach (Control aCtl in CtlList)
            {
                max = Math.Max(max, aCtl.Location.Y + aCtl.Size.Height);
            }
            return max;
        }

        public bool getInfor(Pill p)
        {
            if (isBlankNote())
                return false;
            p.name = noteName.Text;
            p.amount = (Int32)noteAmount.Value;
            for(int i = 0; i < noteTime.Length; i++)
            {
                p.time[i] = noteTime[i].Checked;
            }

            return true;
        }

        public bool isBlankNote()
        {
            char[] charsToTrim = { '*', ' ', '\'' };
            foreach (Control c in CtlList)
            {
                if (c.Name.Contains("noteName") && c.Text.Trim(charsToTrim).Length <= 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
