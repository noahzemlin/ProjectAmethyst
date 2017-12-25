using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAmethyst
{


    class ChampionGroup
    {
        public static List<ChampionGroup> groups = new List<ChampionGroup>();

        public static ChampionGroup selected = null;

        private List<Champion> champs = new List<Champion>();
        private string name = "please renmae me";

        public ChampionGroup() { }

        public ChampionGroup(string name)
        {
            this.name = name;
        }

        public void AddChamp(Champion champ)
        {
            champs.Add(champ);
        }

        public bool RemoveChamp(Champion champ)
        {
            return champs.Remove(champ);
        }

        public string GetRandom()
        {
            return champs[AmethystCore.rng.Next(champs.Count)].id;
        }

        public static ChampionGroup Find(string name)
        {
            Predicate<ChampionGroup> predy = s => s.GetName() == name;
            return groups.Find(predy);
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }

        public override string ToString()
        {
            return name;
        }

        public List<Champion> getChamps()
        {
            return champs;
        }

    }
}
