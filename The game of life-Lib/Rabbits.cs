using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_game_of_life_Lib
{
    public class Rabbits
    {
        TakenPlaces tp = new TakenPlaces();

        readonly List<Rabbit> rabbitsList = new List<Rabbit>();

        public Rabbits(int numbrerOfRabbits)
        {
            for (int i = 0; i < numbrerOfRabbits; i++)
            {
                rabbitsList.Add(new Rabbit(tp.RandomUntakenX(), tp.RandomUntakenY()));
            }
        }
    }
}
