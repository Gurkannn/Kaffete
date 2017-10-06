using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaffe
{
    class Map
    {
        public static void mapArray(int[,] array)
        {
            for (int x = 0; x < array.GetLength(0); x++ )
            {
                Console.WriteLine("#");
                for (int y = 0; y < array.GetLength(1); y++ )
                {
                    Console.WriteLine("#");
                }
            }
        }
    }
}
