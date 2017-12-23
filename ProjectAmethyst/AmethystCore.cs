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
        public static string currentChampion = "";

        public static Random rng = new Random();

        private static List<string> champions = new List<string>();

        public static void LoadChampions()
        {

            string jsonRaw;

            using (WebClient wc = new WebClient())
            {
                jsonRaw = wc.DownloadString("http://ddragon.leagueoflegends.com/cdn/7.24.2/data/en_US/champion.json");
            }

            dynamic json = JsonConvert.DeserializeObject(jsonRaw);

            dynamic jsondata = json.data;

            foreach(dynamic champ in jsondata)
            {
                champions.Add(champ.Name);
            }
        }

        public static void GetChampion()
        {
            currentChampion = champions[rng.Next(champions.Count)];
        }
    }
}
