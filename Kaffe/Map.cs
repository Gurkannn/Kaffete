using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaffe
{
    static class Map
    {
        private static int width;
        private static int height;
        private static MapObject[,] map;

        public static int Width { get => width; set => width = value; }
        public static int Height { get => height; set => height = value; }

        private static void InitializeMap()
        {
            map = new MapObject[Width,Height];

            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    if (y == 0 || x == 0 || y == Height || x == Width)
                    {
                        map[x, y] = new Wall();
                    }
                    else
                    {
                        map[x, y] = new Empty();
                    }
                }
            }
        }

        private static void DrawMap()
        {

        }
        
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
