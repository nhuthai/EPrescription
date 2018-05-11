using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Medicine
{
    public class APrescription
    {
        public int maxAlignX, maxAlignY, minAlignX, minAlignY;
        public ArrayList CtlList = new ArrayList();
        public Label lblDisease = new Label();
        public Label lblNotice = new Label();
        public Label lblDoctor = new Label();

        public APrescription(Prescription p)
        {
            Initializer(0, 0, p);
        }

        public APrescription(int alignX, int alignY, Prescription p)
        {
            Initializer(alignX, alignY, p);
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

        private void Initializer(int alignX, int alignY, Prescription p)
        {
            lblDisease.Text = p.disease.name + ": ";
            lblDisease.Location = new Point(alignX, alignY);
            lblDisease.AutoSize = true;
            CtlList.Add(lblDisease);

            int preWidth = lblDisease.Location.X + lblDisease.Width + 5;
            foreach(Pill drug in p.getPills())
            {
                Label lblDrug = new Label();
                lblDrug.Text = drug.name;
                lblDrug.Location = new Point(preWidth, alignY);
                lblDrug.AutoSize = true;
                CtlList.Add(lblDrug);

                Label lblAmount = new Label();
                lblAmount.Text = drug.amount.ToString() + ", ";
                lblAmount.Location = new Point(lblDrug.Location.X + lblDrug.Width + 5, alignY);
                lblAmount.AutoSize = true;
                CtlList.Add(lblAmount);

                preWidth = lblAmount.Location.X + lblAmount.Width + 5;
            }

            lblNotice.Text = p.disease.notice;
            lblNotice.Location = new Point(alignX, lblDisease.Location.Y + lblDisease.Height + 5);
            lblNotice.AutoSize = true;
            CtlList.Add(lblNotice);

            lblDoctor.Text = "by " + p.doctor.name;
            lblDoctor.Location = new Point(alignX, lblNotice.Location.Y + lblNotice.Height + 5);
            lblDoctor.AutoSize = true;
            CtlList.Add(lblDoctor);

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
    }
}
