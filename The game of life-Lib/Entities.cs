using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_game_of_life_Lib
{
    public class Entities
    {
        TakenPlaces tp = new TakenPlaces();

        readonly List<Entity> rabbitsList = new List<Entity>();
        readonly List<Entity> foxesList = new List<Entity>();
        readonly List<Entity> grassesList = new List<Entity>();

        public Entities(int numberOfFoxes, int numberOfRabbits, int numberOfGrasses)
        {
            for (int i = 0; i < numberOfFoxes; i++)
            {
                foxesList.Add(new Entity("f", tp.RandomUntakenX(), tp.RandomUntakenY()));
            }
            
            for (int i = 0; i < numberOfRabbits; i++)
            {
                rabbitsList.Add(new Entity("r", tp.RandomUntakenX(), tp.RandomUntakenY()));
            }

            for (int i = 0; i < numberOfGrasses; i++)
            {
                grassesList.Add(new Entity("g", tp.RandomUntakenX(), tp.RandomUntakenY()));
            }
        }

        public List<Entity> Rabbits => rabbitsList;
        public List<Entity> Foxes => foxesList;
        public List<Entity> Grasses => grassesList;
    }
}
