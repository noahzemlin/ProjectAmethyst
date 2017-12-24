using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAmethyst
{
    class ChampionGroup
    {
        private List<Champion> champs = new List<Champion>();

        public void AddChamp(Champion champ)
        {
            champs.Add(champ);
        }

        public bool RemoveChamp(Champion champ)
        {
            return champs.Remove(champ);
        }

        public Champion GetRandom()
        {
            return champs[AmethystCore.rng.Next(champs.Count)];
        }

    }
}
