using System.Text;

namespace PokemonCS
{
    public class Map
    {
        public static int xPos, yPos;
        public static int xMap, yMap;
        public static int xCam, yCam;
        public static int xHouse, yHouse;
        public static string? elementPos, player;
        public static string[]? lines;
        public static string? mapType;
        public static Dictionary<char, ConsoleColor> colorMap = new()
        {
            { '║', ConsoleColor.DarkYellow },
            { '╣', ConsoleColor.DarkYellow },
            { '╠', ConsoleColor.DarkYellow },
            { '▓', ConsoleColor.DarkYellow },
            { '/', ConsoleColor.DarkRed },
            { '\\', ConsoleColor.DarkRed },
            { '-', ConsoleColor.DarkRed },
            { '_', ConsoleColor.DarkRed },
            { '(', ConsoleColor.DarkGreen },
            { ')', ConsoleColor.DarkGreen },
            { '|', ConsoleColor.DarkGray },
            { '█', ConsoleColor.DarkGray },
            { '#', ConsoleColor.Yellow },
            { '░', ConsoleColor.DarkCyan }
        };
        private static readonly HashSet<char> immovableCharacters = new() { '~', '|', '/', '\\', '(', ')', '║', '╣', '╠', '_', '▓', '@' };
        private static readonly Random rnd = new();


        // create a method to read the map
        public static void ReadMap()
        {
            mapType = "map";
            // read the map
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "map.txt");
            lines = File.ReadAllLines(path);
            ColorMap();
        }

        // create a function to color the map
        public static void ColorMap()
        {

            StringBuilder sb = new();
            ConsoleColor currentColor = ConsoleColor.White;

            // Set the console buffer width to match the width of the map
            Console.BufferWidth = lines[0].Length;

            foreach (string line in lines)
            {
                foreach (char c in line)
                {
                    ConsoleColor nextColor = colorMap.ContainsKey(c) ? colorMap[c] : ConsoleColor.White;

                    if (nextColor != currentColor)
                    {
                        Console.ForegroundColor = currentColor;
                        Console.Write(sb.ToString());
                        sb.Clear();
                        currentColor = nextColor;
                    }

                    sb.Append(c);
                }

                Console.ForegroundColor = currentColor;
                Console.Write(sb.ToString());
                sb.Clear();
                Console.WriteLine();
            }

            Console.ResetColor();
        }

        // create a method to spawn the player and to move the player
        public static void SpawnPlayer(int _xPos, int _yPos)
        {
            player = "☺";

            // spawn the player
            xPos = _xPos;
            yPos = _yPos;


            // spawn the player
            Console.SetCursorPosition(xPos, yPos);
            elementPos = lines[yPos].ElementAt(xPos).ToString();
            Console.Write(player);
            Console.SetCursorPosition(xPos, yPos);


            // move the player
            ConsoleKeyInfo keyInfo;
            do
            {
                SetCam();
                keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    // move up
                    case ConsoleKey.UpArrow:
                        yPos -= 1;
                        Console.SetCursorPosition(xPos, yPos);
                        if (CanMove())
                        {
                            yPos += 1;
                            break;
                        }
                        else
                        {
                            if (mapType == "map")
                            {
                                Player.CheckStep(Intro.player);
                            }
                            Console.Write(player);
                            Console.SetCursorPosition(xPos, yPos + 1);
                            CheckColor();
                            Console.Write(elementPos);
                            Console.ResetColor();
                            elementPos = lines[yPos].ElementAt(xPos).ToString();
                            break;
                        }
                    // move down
                    case ConsoleKey.DownArrow:
                        yPos += 1;
                        Console.SetCursorPosition(xPos, yPos);
                        if (CanMove())
                        {
                            yPos -= 1;
                            break;
                        }
                        else
                        {
                            if (mapType == "map")
                            {
                                Player.CheckStep(Intro.player);
                            }
                            Console.Write(player);
                            Console.SetCursorPosition(xPos, yPos - 1);
                            CheckColor();
                            Console.Write(elementPos);
                            Console.ResetColor();
                            elementPos = lines[yPos].ElementAt(xPos).ToString();
                            break;
                        }

                    // move left
                    case ConsoleKey.LeftArrow:
                        xPos -= 1;
                        Console.SetCursorPosition(xPos, yPos);
                        if (CanMove())
                        {
                            xPos += 1;
                            break;
                        }
                        else
                        {
                            if (mapType == "map")
                            {
                                Player.CheckStep(Intro.player);
                            }
                            Console.Write(player);
                            Console.SetCursorPosition(xPos + 1, yPos);
                            CheckColor();
                            Console.Write(elementPos);
                            Console.ResetColor();
                            elementPos = lines[yPos].ElementAt(xPos).ToString();
                            break;
                        }

                    // move right
                    case ConsoleKey.RightArrow:
                        xPos += 1;
                        Console.SetCursorPosition(xPos, yPos);
                        if (CanMove())
                        {
                            xPos -= 1;
                            break;
                        }
                        else
                        {
                            if (mapType == "map")
                            {
                                Player.CheckStep(Intro.player);
                            }
                            Console.Write(player);
                            Console.SetCursorPosition(xPos - 1, yPos);
                            CheckColor();
                            Console.Write(elementPos);
                            Console.ResetColor();
                            elementPos = lines[yPos].ElementAt(xPos).ToString();
                            break;
                        }
                    // pause menu
                    case ConsoleKey.Spacebar:
                        Menu.PauseMenu();
                        break;
                    default:
                        break;

                }
            } while (keyInfo.Key != ConsoleKey.Escape);
        }

        public static bool CanMove()
        {
            string currentPos = lines[yPos].ElementAt(xPos).ToString();

            if (immovableCharacters.Contains(currentPos[0]))
            {
                return true;
            }

            if (currentPos == "#")
            {
                int random = rnd.Next(0, 9);
                if (random == 3)
                {
                    //Create a wild pokemon
                    Fight.currentEnemy = null;
                    Fight.currentEnemy = Pokemon.CreatePokemon(rnd.Next(0, 10));
                    Console.Clear();
                    Console.WriteLine("You found a wild pokemon!");
                    Console.WriteLine("Press any key to start the fight!");
                    Console.ReadKey();
                    Fight.StartRound(Intro.player, Fight.currentEnemy);
                    return true;
                }
                return false;
            }

            if ((lines[yPos].ElementAt(xPos).ToString() == "│" || lines[yPos].ElementAt(xPos).ToString() == "─" || lines[yPos].ElementAt(xPos).ToString() == "┌" || lines[yPos].ElementAt(xPos).ToString() == "┐" || lines[yPos].ElementAt(xPos).ToString() == "└" || lines[yPos].ElementAt(xPos).ToString() == "┘") && mapType == "house") //Colision in the house
            {
                return true;
            }

            // check if the player is in front of an item or a pnj in a house
            if (lines[yPos].ElementAt(xPos).ToString() == "☻" && mapType == "house")
            {
                Console.Clear();
                Fight.DrawBorderLine();
                Console.WriteLine("Do you want to talk to the person? (y/n)");
                Fight.DrawBorderLine();
                string answer = Console.ReadLine();
                if (answer == "y")
                {
                    Console.Clear();
                    Menu.VendorMenu();
                    return true;
                }
                else
                {
                    Console.Clear();
                    ReadHouse();
                    SpawnPlayer(xPos, yPos);
                    return true;
                }
            }

            //Check if the player is front of a door
            if (lines[yPos].ElementAt(xPos).ToString() == "▒" && mapType == "map")
            {
                Console.Clear();
                Fight.DrawBorderLine();
                Console.WriteLine("Do you want to enter the house? (y/n)");
                Fight.DrawBorderLine();
                string answer = Console.ReadLine();
                if (answer == "y")
                {
                    Console.Clear();
                    Console.WriteLine("You entered the house!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    xMap = xPos;
                    yMap = yPos;
                    ReadHouse();
                    SpawnPlayer(1, 1);
                    return true;
                }
                else
                {
                    Console.Clear();
                    ReadMap();
                    SpawnPlayer(xPos, yPos);
                    return true;
                }
            }
            else if (lines[yPos].ElementAt(xPos).ToString() == "▒" && mapType == "house")
            {
                Console.Clear();
                Fight.DrawBorderLine();
                Console.WriteLine("Do you want to leave the house? (y/n)");
                Fight.DrawBorderLine();
                string answer = Console.ReadLine();
                if (answer == "y")
                {
                    Console.Clear();
                    Console.WriteLine("You left the house!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    ReadMap();
                    SpawnPlayer(xMap, yMap);
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        // Set the camera based on the player's position on the map
        public static void SetCam()
        {
            if (xPos - Console.WindowWidth / 2 >= 0 && xPos + Console.WindowWidth / 2 <= lines[yPos].Length - 1)
            {
                xCam = xPos - Console.WindowWidth / 2;
            }
            if (yPos - Console.WindowHeight / 2 >= 0 && yPos + Console.WindowHeight / 2 <= lines.Length)
            {
                yCam = yPos - Console.WindowHeight / 2;
            }
            Console.SetWindowPosition(xCam, yCam);
        }

        // Read the house map and color it
        public static void ReadHouse()
        {
            mapType = "house";
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "house.txt");
            lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
            ColorHouse();
        }

        //Color the house map
        public static void ColorHouse()
        {
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (lines[i].ElementAt(j) == '║' || lines[i].ElementAt(j) == '╣' || lines[i].ElementAt(j) == '╠' || lines[i].ElementAt(j) == '▓')
                    {
                        Console.SetCursorPosition(j, i);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write(lines[i].ElementAt(j));
                        Console.ResetColor();
                    }
                    else if (lines[i].ElementAt(j) == '/' || lines[i].ElementAt(j) == '\\' || lines[i].ElementAt(j) == '-' || lines[i].ElementAt(j) == '_')
                    {
                        Console.SetCursorPosition(j, i);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(lines[i].ElementAt(j));
                        Console.ResetColor();
                    }

                    else if (lines[i].ElementAt(j) == '(' || lines[i].ElementAt(j) == ')')
                    {
                        Console.SetCursorPosition(j, i);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write(lines[i].ElementAt(j));
                        Console.ResetColor();
                    }
                    else if (lines[i].ElementAt(j) == '|')
                    {
                        Console.SetCursorPosition(j, i);
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(lines[i].ElementAt(j));
                        Console.ResetColor();
                    }
                }
            }
        }

        //Check the map to read
        public static void CheckMap()
        {
            if (mapType == "map")
            {
                ReadMap();
            }
            else if (mapType == "house")
            {
                ReadHouse();
            }
        }

        public static void CheckColor()
        {
            if (elementPos == "#")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
        }
    }
}