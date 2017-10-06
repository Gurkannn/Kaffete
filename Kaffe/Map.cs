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
        private static Player player;

        public static int Width { get => width; set => width = value; }
        public static int Height { get => height; set => height = value; }
        public static MapObject[,] MapA { get => mapA; set => mapA = value; }
        public static Player Player { get => player; set => player = value; }

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
                        MapA[x, y] = new Wall(x, y);
                    }
                    else
                    {
                        MapA[x, y] = new Empty(x, y);
                    }
                }
            }
            InitializePlayer();
        }
        private static void InitializePlayer()
        {
            Player = new Player(Width / 2, Height / 2);
            //MapA[Player.PosX, Player.PosY] = Player;
        }

        public static void DrawMap()
        {
            Console.Clear();
            for (int y = 0; y < MapA.GetLength(1); y++)
            {
                for (int x = 0; x < MapA.GetLength(0); x++)
                {
                    if (x == Player.PosX && y == Player.PosY)
                    {
                        Console.Write(Player.Icon);
                    }
                    else if (MapA[x, y].IsPlayerTail)
                    {
                        if (MapA[x, y].TailDuration > 0)
                        {
                            Console.Write(Player.Icon);
                        }
                        else
                        {
                            MapA[x, y].IsPlayerTail = false;
                        }
                    }
                    else
                    {
                        Console.Write(MapA[x, y].Icon);
                    }
                }
                Console.WriteLine();
            }
        }

        public static void MovePlayer()
        {
            if (CanMove(Player.CurrentDirection))
            {
                MapA[player.PosX, player.PosY].IsPlayerTail = true;
                MapA[player.PosX, player.PosY].TailDuration = Player.BodyLenght;
                Player.MovePlayer();
            }
        }

        public static void DecreaseTailTimer()
        {
            for (int y = 0; y < MapA.GetLength(1); y++)
            {
                for (int x = 0; x < MapA.GetLength(0); x++)
                {
                    if (MapA[x, y].TailDuration > 0)
                    {
                        MapA[x, y].TailDuration--;
                    }
                }
            }
        }

        private static bool CanMove(Direction direction)
        {
            MapObject tempTile;
            switch (direction)
            {
                case Direction.North:
                    tempTile = MapA[Player.PosX, Player.PosY - 1];
                    if (tempTile.CanWalkOn)
                        return true;
                    else
                        return false;
                case Direction.South:
                    tempTile = MapA[Player.PosX, Player.PosY + 1];
                    if (tempTile.CanWalkOn)
                        return true;
                    else
                        return false;
                case Direction.West:
                    tempTile = MapA[Player.PosX - 1, Player.PosY];
                    if (tempTile.CanWalkOn)
                        return true;
                    else
                        return false;
                case Direction.East:
                    tempTile = MapA[Player.PosX + 1, Player.PosY];
                    if (tempTile.CanWalkOn)
                        return true;
                    else
                        return false;
            }

            return false;
        }
    }
}
