namespace The_game_of_life_Lib
{
    internal class Roka
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Jollakottsag { get; set; } = 10;

        public Roka(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Mozgas(int koviX, int koviY)
        {
            X = koviX;
            Y = koviY;
        }

        public void NyulMegevese()
        {
            Jollakottsag += 3;
        }
    }
}
