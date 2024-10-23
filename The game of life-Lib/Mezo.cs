namespace The_game_of_life_Lib
{
    public class Mezo
    {
        private const int Szelesseg = 10;
        private const int Magassag = 10;
        private Fu[,] mezo;
        private List<Nyul> nyulak;
        private List<Roka> rokak;
        private Random random;

        public Mezo()
        {
            mezo = new Fu[Szelesseg, Magassag];
            nyulak = new List<Nyul>();
            rokak = new List<Roka>();
            random = new Random();
            MezoIndito();
        }

        private void MezoIndito()
        {
            for (int x = 0; x < Szelesseg; x++)
            {
                for (int y = 0; y < Magassag; y++)
                {
                    mezo[x, y] = new Fu();
                }
            }

            for (int i = 0; i < 6; i++)
            {
                int x = random.Next(Szelesseg);
                int y = random.Next(Magassag);
                nyulak.Add(new Nyul(x, y));
            }

            for (int i = 0; i < 2; i++)
            {
                int x = random.Next(Szelesseg);
                int y = random.Next(Magassag);
                rokak.Add(new Roka(x, y));
            }
        }

        public void KoviMezo()
        {
            for (int x = 0; x < Szelesseg; x++)
            {
                for (int y = 0; y < Magassag; y++)
                {
                    mezo[x, y].FuSzintNoveles();
                }
            }

            List<Nyul> ujNyulak = new();
            for (int i = nyulak.Count - 1; i >= 0; i--)
            {
                Nyul nyul = nyulak[i];
                nyul.Jollakottsag--;

                if (nyul.Jollakottsag <= 0)
                {
                    nyulak.RemoveAt(i);
                    continue;
                }

                Fu legkozelebbiFu = LegkozelebbiFu(nyul);
                if (legkozelebbiFu != null)
                {
                    NyulMozgas(nyul, legkozelebbiFu);
                    for (int x = 0; x < Szelesseg; x++)
                    {
                        for (int y = 0; y < Magassag; y++)
                        {
                            if (mezo[x, y] == legkozelebbiFu)
                            {
                                if (nyul.X == x && nyul.Y == y)
                                {
                                    if (nyul.FuEves(legkozelebbiFu))
                                    {
                                        mezo[nyul.X, nyul.Y] = new Fu();
                                    }
                                }
                            }
                        }
                    }
                }

                foreach (Nyul masikNyul in nyulak)
                {
                    if (masikNyul != nyul && Mellette_E(nyul, masikNyul))
                    {
                        (int koviX, int koviY) = UresHelyKereso(nyul);
                        if (koviX != -1 && koviY != -1 && !Van_ERokaMellete(koviX, koviY))
                        {
                            ujNyulak.Add(new Nyul(koviX, koviY));
                        }
                    }
                }
            }

            nyulak.AddRange(ujNyulak);

            List<Roka> ujRokak = new();
            for (int i = rokak.Count - 1; i >= 0; i--)
            {
                Roka roka = rokak[i];
                roka.Jollakottsag--;

                if (roka.Jollakottsag <= 0)
                {
                    rokak.RemoveAt(i);
                    continue;
                }

                Nyul legkozelebbiNyul = Van_eNyulMellette(roka);
                if (legkozelebbiNyul != null)
                {
                    if (Mellette_E(roka, legkozelebbiNyul))
                    {
                        roka.NyulMegevese();
                        nyulak.Remove(legkozelebbiNyul);
                    }
                    else
                    {
                        RokaMozgas(roka, legkozelebbiNyul);
                        RokaMozgas(roka, legkozelebbiNyul);
                    }
                }

                foreach (Roka masikRoka in rokak)
                {
                    if (masikRoka != roka && Mellette_E(roka, masikRoka))
                    {
                        (int newX, int newY) = UresHelyKereso(roka);
                        if (newX != -1 && newY != -1 && !Van_ENyulMellete(newX, newY))
                        {
                            ujRokak.Add(new Roka(newX, newY));
                        }
                    }
                }
            }

            rokak.AddRange(ujRokak);

            if (nyulak.Count == 0 || rokak.Count == 0)
            {
                Environment.Exit(0);
            }
        }

        private bool Van_ENyulMellete(int x, int y)
        {
            foreach (Nyul nyul in nyulak)
            {
                if (Math.Abs(nyul.X - x) <= 1 && Math.Abs(nyul.Y - y) <= 1)
                {
                    return true;
                }
            }
            return false;
        }

        private bool Van_ERokaMellete(int x, int y)
        {
            foreach (Roka roka in rokak)
            {
                if (Math.Abs(roka.X - x) <= 1 && Math.Abs(roka.Y - y) <= 1)
                {
                    return true;
                }
            }
            return false;
        }


        private Fu LegkozelebbiFu(Nyul nyul)
        {
            Fu legkozelebbiFu = null;
            int minimumTavolsag = int.MaxValue;

            for (int x = 0; x < Szelesseg; x++)
            {
                for (int y = 0; y < Magassag; y++)
                {
                    int tavolsag = Math.Abs(nyul.X - x) + Math.Abs(nyul.Y - y);
                    if (tavolsag < minimumTavolsag && (mezo[x, y].Szint == 1 || mezo[x, y].Szint == 2))
                    {
                        minimumTavolsag = tavolsag;
                        legkozelebbiFu = mezo[x, y];
                    }
                }
            }

            return legkozelebbiFu;
        }

        private Nyul Van_eNyulMellette(Roka roka)
        {
            Nyul legkozelebbiNyul = null;
            int minimumTavolsag = int.MaxValue;

            foreach (Nyul nyul in nyulak)
            {
                int tavolsag = Math.Abs(roka.X - nyul.X) + Math.Abs(roka.Y - nyul.Y);
                if (tavolsag < minimumTavolsag)
                {
                    minimumTavolsag = tavolsag;
                    legkozelebbiNyul = nyul;
                }
            }

            return legkozelebbiNyul;
        }

        private void NyulMozgas(Nyul nyul, Fu fu)
        {
            (int grassX, int grassY) = FuKoordinataKereso(fu);

            if (nyul.X < grassX)
                nyul.Mozgas(nyul.X + 1, nyul.Y);
            else if (nyul.X > grassX)
                nyul.Mozgas(nyul.X - 1, nyul.Y);
            else if (nyul.Y < grassY)
                nyul.Mozgas(nyul.X, nyul.Y + 1);
            else if (nyul.Y > grassY)
                nyul.Mozgas(nyul.X, nyul.Y - 1);
        }

        private (int, int) FuKoordinataKereso(Fu fu)
        {
            for (int x = 0; x < Szelesseg; x++)
            {
                for (int y = 0; y < Magassag; y++)
                {
                    if (mezo[x, y] == fu)
                    {
                        return (x, y);
                    }
                }
            }
            return (-1, -1);
        }


        private void RokaMozgas(Roka roka, Nyul nyul)
        {
            if (roka.X < nyul.X)
                roka.Mozgas(roka.X + 1, roka.Y);
            else if (roka.X > nyul.X)
                roka.Mozgas(roka.X - 1, roka.Y);
            else if (roka.Y < nyul.Y)
                roka.Mozgas(roka.X, roka.Y + 1);
            else if (roka.Y > nyul.Y)
                roka.Mozgas(roka.X, roka.Y - 1);
        }

        private bool Mellette_E(Nyul rabbit1, Nyul rabbit2)
        {
            return Math.Abs(rabbit1.X - rabbit2.X) <= 1 && Math.Abs(rabbit1.Y - rabbit2.Y) <= 1;
        }

        private bool Mellette_E(Roka roka, Nyul nyul)
        {
            return Math.Abs(roka.X - nyul.X) <= 1 && Math.Abs(roka.Y - nyul.Y) <= 1;
        }

        private bool Mellette_E(Roka fox1, Roka fox2)
        {
            return Math.Abs(fox1.X - fox2.X) <= 1 && Math.Abs(fox1.Y - fox2.Y) <= 1;
        }

        private (int, int) UresHelyKereso(Nyul nyul)
        {
            int[,] iranyok = { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };
            for (int i = 0; i < iranyok.GetLength(0); i++)
            {
                int koviX = nyul.X + iranyok[i, 0];
                int koviY = nyul.Y + iranyok[i, 1];
                if (koviX >= 0 && koviX < Szelesseg && koviY >= 0 && koviY < Magassag && mezo[koviX, koviY].Szint == 1)
                {
                    return (koviX, koviY);
                }
            }
            return (-1, -1);
        }

        private (int, int) UresHelyKereso(Roka roka)
        {
            int[,] iranyok = { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };
            for (int i = 0; i < iranyok.GetLength(0); i++)
            {
                int koviX = roka.X + iranyok[i, 0];
                int koviY = roka.Y + iranyok[i, 1];
                if (koviX >= 0 && koviX < Szelesseg && koviY >= 0 && koviY < Magassag && mezo[koviX, koviY].Szint == 1)
                {
                    return (koviX, koviY);
                }
            }
            return (-1, -1);
        }


        public void Kiiras()
        {
            Console.CursorVisible = false;
            char[,] MezoKiiras = new char[Szelesseg, Magassag];

            for (int x = 0; x < Szelesseg; x++)
            {
                for (int y = 0; y < Magassag; y++)
                {
                    MezoKiiras[x, y] = mezo[x, y].FuKarakterek();
                }
            }

            foreach (Nyul nyul in nyulak)
            {
                MezoKiiras[nyul.X, nyul.Y] = 'N';
            }

            foreach (Roka roka in rokak)
            {
                MezoKiiras[roka.X, roka.Y] = 'R';
            }

            for (int x = 0; x < Szelesseg; x++)
            {
                for (int y = 0; y < Magassag; y++)
                {
                    switch (MezoKiiras[x, y])
                    {
                        case 'N':
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.Write(MezoKiiras[x, y] + "  ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;
                        case 'R':
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write(MezoKiiras[x, y] + "  ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;
                        case '_':
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.Write(MezoKiiras[x, y] + "  ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;
                        case 'g':
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write(MezoKiiras[x, y] + "  ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;
                        case 'G':
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.Write(MezoKiiras[x, y] + "  ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;
                        default:
                            Console.Write(MezoKiiras[x, y] + "  ");
                            break;
                    }
                }
                Console.WriteLine();
            }
        }

        public void SzovegKiiro(string title)
        {
            Console.SetCursorPosition((Console.WindowWidth - title.Length) / 2, Console.CursorTop);

            Console.WriteLine(title);

            Console.SetCursorPosition(0, Console.CursorTop);
        }
    }
}
