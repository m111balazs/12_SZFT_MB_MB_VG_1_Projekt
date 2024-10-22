namespace The_game_of_life_Lib
{
    internal class Nyul
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Jollakottsag { get; set; } = 5;

        public Nyul(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Mozgas(int koviX, int koviY)
        {
            X = koviX;
            Y = koviY;
        }

        public bool FuEves(Fu fu)
        {
            if (fu.Szint == 1 || fu.Szint == 2)
            {
                Jollakottsag += (int)fu.Szint;
                return true;
            }
            return false;
        }
    }
}
