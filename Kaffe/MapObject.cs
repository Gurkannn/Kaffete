using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaffe
{
    abstract class MapObject : IPosition, IEntity
    {
        public abstract bool IsPlayerTail { get; set; }
        public abstract int TailDuration { get; set; }
        public abstract int PosX { get; set; }
        public abstract int PosY { get; set; }
        public abstract bool CanWalkOn { get; set; }
        public abstract bool CanInteractWith { get; set; }
        public abstract string Icon { get; set; }
        public abstract ConsoleColor Color { get; set; }

        public abstract void Interact();
    }
}
