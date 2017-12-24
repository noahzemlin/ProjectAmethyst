using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAmethyst
{
    public static class AmethystCore
    {
        public static Random rng = new Random();

        private static List<string> champions = new List<string>();
        private static string currentChampion = "";
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
                champions.Add(champ.Name);
            }
        }

        public static string GetNewChampion()
        {
            currentChampion = champions[rng.Next(champions.Count)];
            return currentChampion;
        }

        public static string GetCurrentChampion()
        {
            return currentChampion;
        }

        public static string GetVersion()
        {
            return version;
        }
    }
}
