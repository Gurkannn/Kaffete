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
        static Random random = new Random();
        static Direction inputDirection;
        private static int score;


        public static int Width { get => width; set => width = value; }
        public static int Height { get => height; set => height = value; }
        public static MapObject[,] MapA { get => mapA; set => mapA = value; }
        public static Player Player { get => player; set => player = value; }
        public static Direction InputDirection { get => inputDirection; set => inputDirection = value; }


        public static void ChangeTile(int x, int y, MapObject obj)
        {
            if (MapA[x, y] != obj)
            {
                MapA[x, y] = obj;
            }
        }

        public static int Score
        {
            get { return score; }
            set
            {
                if (value > score)
                    Player.IncreaseBodyLenght();
                score = value;
                if (score % 3 == 0)
                    Time.DecreaseInterval();
            }
        }

        public static void InitializeMap(int width, int height)
        {
            Score = 0;
            if (Player != null)
                Player.ResetBodyLenght();
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
            string tempMap = "";
            for (int y = 0; y < MapA.GetLength(1); y++)
            {
                for (int x = 0; x < MapA.GetLength(0); x++)
                {
                    if (x == Player.PosX && y == Player.PosY)
                    {
                        tempMap += Player.Icon;
                    }
                    else if (MapA[x, y].IsPlayerTail)
                    {
                        if (MapA[x, y].TailDuration > 0)
                        {
                            tempMap += Player.TailIcon;
                        }
                        else
                        {
                            tempMap += " ";
                            MapA[x, y].IsPlayerTail = false;
                        }
                    }
                    else
                    {
                        tempMap += MapA[x, y].Icon;
                    }
                }
                tempMap += "\n";                
            }
            tempMap += GetScoreString();
            Console.Clear();
            Console.WriteLine(tempMap);
        }

       

        public static string GetScoreString()
        {
            string tempString = "";        

            tempString += "Score: ";
            tempString += Score;
            return tempString;

        }



        public static void SpawnPoint()
        {
            int pointX = random.Next(1, Width - 1);
            int pointY = random.Next(1, Height - 1);
            while (MapA[pointX, pointY].IsPlayerTail)
            {
                pointX = random.Next(1, Width - 1);
                pointY = random.Next(1, Height - 1);
            }
            ChangeTile(pointX, pointY, new Point(pointX, pointY));
            //MapA[pointX, pointY] = new Point(pointX, pointY);
        }

        public static void MovePlayer()
        {
            if (Player.CurrentDirection != InputDirection)
            {
                Player.CurrentDirection = InputDirection;
            }
            if (CanMove(Player.CurrentDirection))
            {
                //MapA[player.PosX, player.PosY].IsPlayerTail = true;
                //MapA[player.PosX, player.PosY].TailDuration = Player.BodyLenght;
                Player.MovePlayer();
                ChangeTile(Player.NextPosX, Player.NextPosY, Player);
                Player.PosX = Player.NextPosX;
                Player.PosY = Player.NextPosY;
                ChangeTile(player.PosX, player.PosY, new Empty(player.PosX, player.PosY) { IsPlayerTail = true, TailDuration = Player.BodyLenght });
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

        public static void IncreaseTailTimer()
        {
            for (int y = 0; y < MapA.GetLength(1); y++)
            {
                for (int x = 0; x < MapA.GetLength(0); x++)
                {
                    if (MapA[x, y].TailDuration > 0)
                    {
                        MapA[x, y].TailDuration++;
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
                    if (tempTile.CanInteractWith)
                        tempTile.Interact();
                    if (tempTile.CanWalkOn)
                        return true;
                    else
                        return false;
                case Direction.South:
                    tempTile = MapA[Player.PosX, Player.PosY + 1];
                    if (tempTile.CanInteractWith)
                        tempTile.Interact();
                    if (tempTile.CanWalkOn)
                        return true;
                    else
                        return false;
                case Direction.West:
                    tempTile = MapA[Player.PosX - 1, Player.PosY];
                    if (tempTile.CanInteractWith)
                        tempTile.Interact();
                    if (tempTile.CanWalkOn)
                        return true;
                    else
                        return false;
                case Direction.East:
                    tempTile = MapA[Player.PosX + 1, Player.PosY];
                    if (tempTile.CanInteractWith)
                        tempTile.Interact();
                    if (tempTile.CanWalkOn)
                        return true;
                    else
                        return false;
            }

            return false;
        }
    }
}
