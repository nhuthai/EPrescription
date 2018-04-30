using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine
{
    public class Disease
    {
        public String name = "";
        public String notice = "";

        public Disease(String name)
        {
            this.name = name;
        }

        public Disease(String name, String notice)
        {
            this.name = name;
            this.notice = notice;
        }
    }
}
