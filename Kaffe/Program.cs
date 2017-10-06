using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaffe
{
    class Program
    {
        static void Main(string[] args)
        {
            Time.InitializeTimer();
            Map.InitializeMap(10,10);
            Map.DrawMap();
            Console.ReadKey();
            
        }
    }
}
