using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

class Champion {
    public readonly string id;
    public readonly string name;

    public Champion(string id, string name)
    {
        this.id = id;
        this.name = name;
    }
}

namespace ProjectAmethyst
{
    public static class AmethystCore
    {
        public static Random rng = new Random();

        private static List<string> champs = new List<string>();
        private static Dictionary<string, Champion> champData = new Dictionary<string, Champion>();

        private static string currChampId = "";
        private static string version = "";

        public static void LoadChampions()
        {

            string jsonRaw;
            dynamic json;

            using (WebClient wc = new WebClient())
            {
                jsonRaw = wc.DownloadString("https://ddragon.leagueoflegends.com/realms/na.json");
                json = JsonConvert.DeserializeObject(jsonRaw);
                version = json.v;
            }

            using (WebClient wc = new WebClient())
            {
                jsonRaw = wc.DownloadString("http://ddragon.leagueoflegends.com/cdn/" + version + "/data/en_US/champion.json");
            }

            json = JsonConvert.DeserializeObject(jsonRaw);
            dynamic jsondata = json.data;

            foreach(dynamic champ in jsondata)
            {
                Champion champValues = new Champion(champ.Value.id.Value, champ.Value.name.Value);
                champs.Add(champ.Value.id.Value);
                champData.Add(champ.Value.id.Value, champValues);
            }

        }

        public static string GetNewChampion()
        {
            currChampId = champs[rng.Next(champs.Count)];
            return currChampId;
        }

        public static string GetCurrentChampion()
        {
            return currChampId;
        }

        public static string GetName(string id)
        {
            return champData[id].name;
        }

        public static string GetVersion()
        {
            return version;
        }
    }
}
