namespace The_game_of_life_Lib
{
    public class Entity
    {
        public string Type { get; set; }
        public int MaxTravelingDistance { get; set; }
        public int NutritionalValue { get; set; }
        public int Hunger { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int? GrassLevel { get; set; }

        public Entity(string type, int x, int y)
        {
            Type = type;

            switch (Type)
            {
                case "f": //fox
                    MaxTravelingDistance = 2;
                    NutritionalValue = 0;
                    Hunger = 5;
                    PositionX = x;
                    PositionY = y;
                    GrassLevel = null;
                    return;
                case "r": //rabbit
                    MaxTravelingDistance = 1;
                    NutritionalValue = 2;
                    Hunger = 3;
                    PositionX = x;
                    PositionY = y;
                    GrassLevel = null;
                    return;
                case "g": //grass
                    MaxTravelingDistance = 0;
                    NutritionalValue = 0;
                    Hunger = 0;
                    PositionX = x;
                    PositionY = y;
                    GrassLevel = 1;
                    return;
            }
        }
    }
}
