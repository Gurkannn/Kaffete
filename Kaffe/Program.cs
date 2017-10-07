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

        static int gameTick = 400;


        static void Main(string[] args)
        {
            Level.LevelStates levelStates1 = Level.LevelStates.level1;
            Level.GameStates curGameStates = Level.GameStates.intro;
            // Console.CursorVisible = false;
            //Console.ReadKey();
            Map.InitializeMap(20, 15);
            Map.SpawnPoint();
            Map.DrawMap();
            while (gameActive)
            {
                switch (curGameStates)
                {
                    case Level.GameStates.intro:
                        Console.SetCursorPosition(Console.WindowWidth / 7, Console.WindowHeight / 2);
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("Try and get as many objects as possible for higher score by using 'W' 'A' 'S' 'D'");
                        Console.ReadKey();
                        curGameStates = Level.GameStates.ingame;
                        break;
                    case Level.GameStates.ingame:

                        Console.SetCursorPosition(0, 0);
                        Time.InitializeTimer(gameTick);
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
                        break;


                }
            }

        }
    }
}



