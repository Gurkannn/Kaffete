using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaffe
{
    class Program
    {
        static bool gameActive = true;
        static bool gameRestarting = true;
        static Random random = new Random();

        static public void GameOver()
        {
            GameOutro();
        }

        static int gameTick = 300;

        static void GameSetup()
        {

            gameActive = true;
            Time.InitializeTimer(gameTick);
            Map.InitializeMap(random.Next(15, 30), random.Next(14, 24));
            Map.SpawnPoint();
            Map.DrawMap();
        }

        static void GameIntro()
        {
            ConsoleColor tempColor = Console.ForegroundColor;
            Console.SetCursorPosition(0, Console.WindowHeight / 3);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\tTry and get as many objects as possible for\n\thigher score by using 'W' 'A' 'S' 'D'");
            Console.ReadKey();
            Console.ForegroundColor = tempColor;
        }

        static void GameOutro()
        {
            Time.StopTimer();
            gameActive = false;
            Console.Clear();
            ConsoleColor tempColor = Console.ForegroundColor;
            Console.SetCursorPosition(0, Console.WindowHeight / 4);
            Console.WriteLine("\tGame Over!\n   Your score was: " + Map.Score);
            Console.WriteLine("\n\tPress R to restart!\n\tPress E to exit");
            string input = "";

            while (input != "r" && input != "e")
            {
                input = Console.ReadKey(true).KeyChar.ToString().ToLower();
            }
            Console.WriteLine("Debug");
            switch (input)
            {
                case "r":
                    GameSetup();
                    break;
                case "e":
                    gameRestarting = false;
                    break;
            }
            Console.ForegroundColor = tempColor;

        }

        static void GameLoop()
        {

            while (gameActive)
            {
                
                if (gameActive)
                    switch (Console.ReadKey(true).KeyChar.ToString().ToLower())
                    {
                        case "w":
                            if (Map.Player.CurrentDirection != Direction.South)
                                Map.InputDirection = Direction.North;
                            break;
                        case "a":
                            if (Map.Player.CurrentDirection != Direction.East)
                                Map.InputDirection = Direction.West;
                            break;
                        case "s":
                            if (Map.Player.CurrentDirection != Direction.North)
                                Map.InputDirection = Direction.South;
                            break;
                        case "d":
                            if (Map.Player.CurrentDirection != Direction.West)
                                Map.InputDirection = Direction.East;
                            break;
                    }
            }
        }

        static void Main(string[] args)
        {
            Level.LevelStates levelStates1 = Level.LevelStates.level1;
            Level.GameStates curGameStates = Level.GameStates.intro;
            Console.CursorVisible = false;
            GameIntro();

            GameSetup();

            while (gameRestarting)
            {
                GameLoop();
            }
        }
        //switch (curGameStates)
        //{
        //    case Level.GameStates.intro:
        //        Console.SetCursorPosition(Console.WindowWidth / 7, Console.WindowHeight / 2);
        //        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        //        Console.WriteLine("Try and get as many objects as possible for higher score by using 'W' 'A' 'S' 'D'");
        //        Console.ReadKey();
        //        curGameStates = Level.GameStates.ingame;
        //        break;
        //    case Level.GameStates.ingame:
        //        switch (levelStates1)
        //        {
        //            case Level.LevelStates.level1:
        //                Console.SetCursorPosition(0, 0);

        //                switch (Console.ReadKey().KeyChar.ToString())
        //                {

        //                    case "w":
        //                        if (Map.Player.CurrentDirection != Direction.South)
        //                            Map.InputDirection = Direction.North;
        //                        break;
        //                    case "a":
        //                        if (Map.Player.CurrentDirection != Direction.East)
        //                            Map.InputDirection = Direction.West;
        //                        break;
        //                    case "s":
        //                        if (Map.Player.CurrentDirection != Direction.North)
        //                            Map.InputDirection = Direction.South;
        //                        break;
        //                    case "d":
        //                        if (Map.Player.CurrentDirection != Direction.West)
        //                            Map.InputDirection = Direction.East;
        //                        break;
        //                    default:
        //                        break;
        //                }
        //                break;
        //        }
        //        break;

        //}
    }
}



