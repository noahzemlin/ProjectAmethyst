using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAmethyst
{
    public class Settings
    {
        private static LinkedList<Setting> allSettings;

        public static void init()
        {
            allSettings = new LinkedList<Setting>();

            Setting startWithWindows = new Setting("startWithWindows", "Start with windows", Setting.CHECK, 1, false);
            Setting appVersion = new Setting("appVersion", "Version:", Setting.INFO, "alpha", false);
            Setting leagueVersion = new Setting("leagueVersion", "League Version:", Setting.INFO, "n/a", true);

            allSettings.AddLast(startWithWindows);
            allSettings.AddLast(appVersion);
            allSettings.AddLast(leagueVersion);
        }

        public static void updateSetting(String label, int value)
        {
            foreach(Setting item in allSettings)
            {
                if(item.getLabel() == label)
                {
                    item.setNumValue(value);
                }
            }
        }
        public static void updateSetting(String label, String value)
        {
            foreach (Setting item in allSettings)
            {
                if (item.getLabel() == label)
                {
                    item.setStrValue(value);
                }
            }
        }

        public static void saveSettings()
        {
            String result = "";
            foreach (Setting item in allSettings)
            {
                result += item;
            }
            FileHandle.writeSettings(result);
        }
    }

    //-----------------------------------------------------------------------------------

    class Setting
    {
        public const int INFO = 0, CHECK = 1;

        private String label = "";
        private String display = "";
        private int type = -1;
        private int numValue = -1;
        private String strValue = "";
        private bool hidden = true;

        public Setting(String label, String display, int type, int numValue, bool isHidden)
        {
            this.label = label;
            this.display = display;
            this.type = type;
            this.numValue = numValue;
            this.strValue = "";
            this.hidden = isHidden;
        }
        public Setting(String label, String display, int type, String strValue, bool isHidden)
        {
            this.label = label;
            this.display = display;
            this.type = type;
            this.numValue = -1;
            this.strValue = strValue;
            this.hidden = isHidden;
        }

        public String getLabel()
        {
            return (this.label);
        }
        public String getDisplay()
        {
            return (this.display);
        }

        public String getStrValue()
        {
            return (this.strValue);
        }
        public int getNumValue()
        {
            return (this.numValue);
        }

        public void setStrValue(String val)
        {
            this.strValue = val;
        }
        public void setNumValue(int val)
        {
            this.numValue = val;
        }

        public override string ToString()
        {
            String realValue = "";
            if (this.type == INFO)
                realValue = strValue;
            else if (this.type == CHECK)
                realValue += numValue;
            return (this.label + " :" +
                    "\n\ttype : " + this.type +
                    "\n\tvalue : " + realValue + "\n");
        }
    }
}
