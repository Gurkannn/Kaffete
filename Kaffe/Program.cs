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
            Time.InitializeTimer();
            Map.InitializeMap(20,15);
            Map.DrawMap();
            Console.ReadKey();
        }
    }
}
