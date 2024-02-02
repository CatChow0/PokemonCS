using System;
public class Map
{
    public static int xPos, yPos;
    public static string elementPos, player;
    public static string[] lines;

    // create a method to read the map
    public static void ReadMap()
    {
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
                else if (lines[i].ElementAt(j) == '|')
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
            }
        }
    }

    // create a method to spawn the player and to move the player
    public static void SpawnPlayer(int _xPos, int _yPos)
    {
        player = "☺";

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

        return false;
    }

    public static void checkColor()
    {
        if (elementPos == "#")
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
    }
}