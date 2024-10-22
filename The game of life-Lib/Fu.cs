using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_game_of_life_Lib
{
    internal class Fu
    {
        public int Szint { get; private set; }

        public Fu()
        {
            Random rnd = new Random();
            int StartingValue = rnd.Next(1, 4);
            switch (StartingValue)
            {
                case 1:
                    Szint = 1;
                    break;
                case 2:
                    Szint = 2;
                    break;
                case 3:
                    Szint = 3;
                    break;

            }
        }

        public void FuSzintNoveles()
        {
            switch (Szint)
            {
                case 1:
                    Szint = 2;
                    break;
                case 2:
                    Szint = 3;
                    break;
            }
        }

        public char FuKarakterek()
        {
            switch (Szint)
            {
                case 1:
                    return '_';
                case 2:
                    return 'g';
                case 3:
                    return 'G';
                default:
                    return '_';
            }
        }
    }
}
