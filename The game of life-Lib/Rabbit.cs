namespace The_game_of_life_Lib
{
    public class Rabbit
    {
        public const int MaxTravelingDistance = 1;
        public const int NutritionalValue = 2;
        public int Hunger { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public Rabbit(int x, int y) 
        {
            Hunger = 3;
        }
    }
}
