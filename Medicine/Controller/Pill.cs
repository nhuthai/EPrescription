using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine
{
    public class Pill
    {
        public String name = "";
        public int amount;
        public bool[] time;

        public Pill()
        {
            amount = 0;
            time = new bool[3];
        }

        public Pill(String name, int amount, bool[] time)
        {
            this.name = name;
            this.amount = amount;
            this.time = time;
        }

        public bool isTimeToTake(DateTime current)
        {
            TimeSpan soonMorning = new TimeSpan(0, 2, 0, 00, 0);
            TimeSpan lateMorning = new TimeSpan(0, 9, 59, 59, 0);
            TimeSpan soonNoon = new TimeSpan(0, 10, 0, 00, 0);
            TimeSpan lateNoon = new TimeSpan(0, 15, 59, 59, 0);
            TimeSpan soonNight = new TimeSpan(0, 16, 0, 00, 0);
            TimeSpan lateNight = new TimeSpan(0, 23, 59, 59, 0);
            bool isMorning = TimeSpan.Compare(soonMorning, current.TimeOfDay) < 0 && TimeSpan.Compare(current.TimeOfDay, lateMorning) < 0;
            bool isNoon = TimeSpan.Compare(soonNoon, current.TimeOfDay) < 0 && TimeSpan.Compare(current.TimeOfDay, lateNoon) < 0;
            bool isNight = TimeSpan.Compare(soonNight, current.TimeOfDay) < 0 && TimeSpan.Compare(current.TimeOfDay, lateNight) < 0;
            return (isMorning && time[0]) || (isNoon && time[1]) || (isNight && time[2]);
        }

        public String timeToString()
        {
            String tokens = "";
            foreach(bool t in time)
            {
                if (t)
                    tokens += '1';
                else
                    tokens += '0';
            }
            return tokens;
        }
    }
}
