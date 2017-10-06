using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaffe.Objects
{
    class Wall : MapObject
    {
        int posX;
        int posY;
        bool canWalkOn;
        bool canInteractWith;
        string icon;
        ConsoleColor color;
        public override int PosX { get => posX; set => posX = value; }
        public override int PosY { get => posY; set => posY = value; }
        public override bool CanWalkOn { get => canWalkOn; set => canWalkOn = value; }
        public override bool CanInteractWith { get => canInteractWith; set => canInteractWith = value; }
        public override string Icon { get => icon; set => Icon = value; }
        public override ConsoleColor Color { get => color; set => color = value; }

        public override void Interact()
        {
            throw new NotImplementedException();
        }
    }
}
