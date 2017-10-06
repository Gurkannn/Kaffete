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
        private static MapObject[,] mapA;

        public static int Width { get => width; set => width = value; }
        public static int Height { get => height; set => height = value; }
        public static MapObject[,] MapA { get => mapA; set => mapA = value; }

        public static void InitializeMap(int width, int height)
        {
            Width = width;
            Height = height;

            MapA = new MapObject[Width, Height];

            for (int y = 0; y < MapA.GetLength(1); y++)
            {
                for (int x = 0; x < MapA.GetLength(0); x++)
                {
                    if (y == 0 || x == 0 || y == Height - 1 || x == Width - 1)
                    {
                        MapA[x, y] = new Wall();
                    }
                    else
                    {
                        MapA[x, y] = new Empty();
                    }
                }
            }
        }

        public static void DrawMap()
        {
            for (int y = 0; y < MapA.GetLength(1); y++)
            {
                for (int x = 0; x < MapA.GetLength(0); x++)
                {
                    Console.Write(MapA[x, y].Icon);
                }
                Console.WriteLine();
            }
        }

        public static void mapArray(int[,] array)
        {
            for (int x = 0; x < array.GetLength(0); x++)
            {
                Console.WriteLine("#");
                for (int y = 0; y < array.GetLength(1); y++)
                {
                    Console.WriteLine("#");
                }
            }
        }
    }
}
