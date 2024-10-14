using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_game_of_life_Lib
{
    public class TakenPlaces
    {
        //map -> x: 20 y:16

        List<int> isTakenX = new List<int>();
        List<int> isTakenY = new List<int>();

        public int RandomUntakenX()
        {
            int value = Random.Shared.Next(20);

            while (!isTakenX.Contains(value))
            {
                value =  Random.Shared.Next(20);
            }

            isTakenX.Add(value);

            return value;
        }

        public int RandomUntakenY()
        {
            int value = Random.Shared.Next(16);

            while (!isTakenY.Contains(value))
            {
                value = Random.Shared.Next(16);
            }

            isTakenY.Add(value);

            return value;
        }
    }
}
