using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaffe
{
    class Program
    {
            Level.GameStates curGameStates;
            Level.LevelStates curLevelStates;

        static void Main(string[] args)
        {
            Player player = new Player();
            player.MovePlayer();
            Map.InitializeMap(10,10);
            Map.DrawMap();
            Console.ReadKey();
            

        }
    }
}
