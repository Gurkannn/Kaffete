using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaffe
{
    class Player : MapObject
    {
        public Player()
        {
            CanWalkOn = false;
            CanInteractWith = false;
        }
        int posX;
        int posY;
        bool canWalkOn;
        bool canInteractWith;
        string icon;
        ConsoleColor color;

        Direction currentDirection;
        public Direction CurrentDirection { get => currentDirection; set => currentDirection = value; }

        public override int PosX { get => posX; set => posX = value; }
        public override int PosY { get => posY; set => posY = value; }

        public override bool CanWalkOn { get => canWalkOn; set => canWalkOn = value; }
        public override bool CanInteractWith { get => canInteractWith; set => canInteractWith = value; }

        public override string Icon { get => icon; set => Icon = value; }
        public override ConsoleColor Color { get => color; set => color = value; }

        public void MovePlayer()
        {
            switch (CurrentDirection)
            {
                case Direction.North:
                    PosY--;
                    break;
                case Direction.South:
                    PosY++;
                    break;
                case Direction.West:
                    PosX--;
                    break;
                case Direction.East:
                    PosX++;
                    break;
                default:
                    break;
            }
        }

        public override void Interact()
        {
            throw new NotImplementedException();
        }
    }

    public enum Direction
    {
        North,South,West,East
    }
}
