using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaffe
{
    interface IEntity
    {
        bool CanWalkOn { get; set; }
        bool CanInteractWith { get; set; }
        string Icon { get; set; }
        ConsoleColor Color { get; set; }

    }
}
