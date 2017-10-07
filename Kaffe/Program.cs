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

        static int gameTick = 200;

        Level.GameStates curGameStates;
        Level.LevelStates curLevelStates;

        static void Main(string[] args)
        {
            Time.InitializeTimer(gameTick);
            Map.InitializeMap(20, 15);
            Map.SpawnPoint();
            Map.DrawMap();
            //Console.ReadKey();

            while (gameActive)
            {
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
            }
        }
    }
}
