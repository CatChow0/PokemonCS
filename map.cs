using System;
public class Map
{
    public static int xPos;
    public static int yPos;
    public static string elementPos;
    public static string[] lines;

    // create a method to read the map
    public static void ReadMap()
    {
        // read the map
        lines = System.IO.File.ReadAllLines("map.txt");
        foreach (string line in lines)
        {
            Console.WriteLine(line);
        }
    }

    // create a method to spawn the player and to move the player
    public static void SpawnPlayer()
    {
        xPos = 0;
        yPos = 0;
        // spawn the player
        Console.SetCursorPosition(xPos, yPos);
        Console.Write("P");
        Console.SetCursorPosition(xPos, yPos);
        // move the player
        ConsoleKeyInfo keyInfo;
        do
        {
            keyInfo = Console.ReadKey();
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    yPos -= 1;
                    Console.SetCursorPosition(xPos, yPos);             
                    Console.Write("P");
                    Console.SetCursorPosition(xPos, yPos);
                    Console.SetCursorPosition(xPos, yPos + 1);
                    Console.Write(elementPos);
                    elementPos = lines[yPos].ElementAt(xPos).ToString();
                    break;
                case ConsoleKey.DownArrow:
                    yPos += 1;
                    Console.SetCursorPosition(xPos, yPos);
                    Console.Write("P");
                    Console.SetCursorPosition(xPos, yPos);
                    Console.SetCursorPosition(xPos, yPos - 1);
                    Console.Write(elementPos);
                    elementPos = lines[yPos].ElementAt(xPos).ToString();
                    break;
                case ConsoleKey.LeftArrow:
                    xPos -= 1;
                    Console.SetCursorPosition(xPos, yPos);
                    Console.Write("P");
                    Console.SetCursorPosition(xPos, yPos);
                    Console.SetCursorPosition(xPos + 1, yPos);
                    Console.Write(elementPos);
                    elementPos = lines[yPos].ElementAt(xPos).ToString();
                    break;
                case ConsoleKey.RightArrow:
                    xPos += 1;
                    Console.SetCursorPosition(xPos, yPos);
                    Console.Write("P");
                    Console.SetCursorPosition(xPos, yPos);
                    Console.SetCursorPosition(xPos - 1, yPos);
                    Console.Write(elementPos);
                    elementPos = lines[yPos].ElementAt(xPos).ToString();
                    break;
            }
        } while (keyInfo.Key != ConsoleKey.Escape);
    }
}