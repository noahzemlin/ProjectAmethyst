using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAmethyst
{
    public class Setting
    {
        public const int INFO = 0, CHECK = 1;

        private String label = "";
        private int type = -1;
        private int numValue = -1;
        private String strValue = "";
        private bool hidden = true;

        public Setting(String label, int type, int numValue, bool isHidden)
        {
            this.label = label;
            this.type = type;
            this.numValue = numValue;
            this.hidden = isHidden;
        }
        public Setting(String label, int type, String strValue, bool isHidden)
        {
            this.label = label;
            this.type = type;
            this.strValue = strValue;
            this.hidden = isHidden;
        }

        public override string ToString()
        {
            String realValue = "";
            if (this.type == INFO)
                realValue = strValue;
            else if (this.type == CHECK)
                realValue += numValue;
            return (this.label + " :" + 
                    "\n\ttype :" + this.type + 
                    "\n\tvalue : " + realValue);
        }
    }
}
