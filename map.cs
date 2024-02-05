using System;
public class Map
{
    public static int xPos, yPos;
    public static int xMap, yMap;
    public static int xHouse, yHouse;
    public static string elementPos, player;
    public static string[] lines;
    public static string mapType;

    // create a method to read the map
    public static void ReadMap()
    {
        mapType = "map";
        // read the map
        lines = System.IO.File.ReadAllLines(@"map.txt");
        foreach (string line in lines)
        {
            Console.WriteLine(line);
        }
        ColorMap();
    }

    // create a function to color the map
    public static void ColorMap()
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
                else if (lines[i].ElementAt(j) == '|' || lines[i].ElementAt(j) == '█')
                {
                    Console.SetCursorPosition(j, i);
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(lines[i].ElementAt(j));
                    Console.ResetColor();
                }
                else if (lines[i].ElementAt(j) == '#')
                {
                    Console.SetCursorPosition(j, i);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(lines[i].ElementAt(j));
                    Console.ResetColor();
                }
                else if (lines[i].ElementAt(j) == '░')
                {
                    Console.SetCursorPosition(j, i);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write(lines[i].ElementAt(j));
                    Console.ResetColor();
                }
            }
        }
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
                        Console.Write(player);
                        Console.SetCursorPosition(xPos, yPos + 1);
                        checkColor();
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
                        Console.Write(player);
                        Console.SetCursorPosition(xPos, yPos - 1);
                        checkColor();
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
                        Console.Write(player);
                        Console.SetCursorPosition(xPos + 1, yPos);
                        checkColor();
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
                        Console.Write(player);
                        Console.SetCursorPosition(xPos - 1, yPos);
                        checkColor();
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
        if (lines[yPos].ElementAt(xPos).ToString() == "~" || lines[yPos].ElementAt(xPos).ToString() == "|" || lines[yPos].ElementAt(xPos).ToString() == "/" || lines[yPos].ElementAt(xPos).ToString() == "\\" || lines[yPos].ElementAt(xPos).ToString() == "(" || lines[yPos].ElementAt(xPos).ToString() == ")" || lines[yPos].ElementAt(xPos).ToString() == "║" || lines[yPos].ElementAt(xPos).ToString() == "╣" || lines[yPos].ElementAt(xPos).ToString() == "╠" || lines[yPos].ElementAt(xPos).ToString() == "_" || lines[yPos].ElementAt(xPos).ToString() == "▓")
        {
            return true;
        }

        if (lines[yPos].ElementAt(xPos).ToString() == "#")
        {
            Random rnd = new Random();
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
                SpawnPlayer(xPos,yPos);
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
                return false;
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

    // Read the house map and color it
    public static void ReadHouse()
    {
        mapType = "house";
        lines = System.IO.File.ReadAllLines("house.txt");
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

    public static void checkColor()
    {
        if (elementPos == "#")
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
    }
}