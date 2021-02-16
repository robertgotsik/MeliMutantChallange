using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeliMutantChallange.Models
{
    public class Stat
    {
        public int count_mutant_dna { get; set; }
        public int count_human_dna { get; set; }
        public double ratio { get; set; }

        public void GetStats(List<Adn> results)
        {
            int human = 0, mutant = 0;

            foreach (var item in results)
            {
                switch (item.type)
                {
                    case 0:
                        human++;
                        break;
                    case 1:
                        mutant++;
                        break;
                }
            }

            count_mutant_dna = mutant;
            count_human_dna = human;
            ratio = (double)mutant / (double)human;
        }
    }
}
