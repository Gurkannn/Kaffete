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

        static public void GameOver()
        {
            gameActive = false;
        }

        static int gameTick = 300;

        static void GameIntro()
        {
            ConsoleColor tempColor = Console.ForegroundColor;
            Console.SetCursorPosition(0, Console.WindowHeight / 3);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\tTry and get as many objects as possible for\n\thigher score by using 'W' 'A' 'S' 'D'");
            Console.ReadKey();
            Console.ForegroundColor = tempColor;                
        }

        static void Main(string[] args)
        {
            Level.LevelStates levelStates1 = Level.LevelStates.level1;
            Level.GameStates curGameStates = Level.GameStates.intro;
            GameIntro();

            Time.InitializeTimer(gameTick);
            Map.InitializeMap(20, 15);
            Map.SpawnPoint();
            Map.DrawMap();


            while (gameActive)
            {
                Map.DrawMap();
                switch (Console.ReadKey().KeyChar.ToString())
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
                    default:
                        break;
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
    }
}



