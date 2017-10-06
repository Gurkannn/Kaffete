using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Kaffe
{
    static class Time
    {
        private static Timer gameTimer;

        public static void InitializeTimer()
        {
            gameTimer = new Timer();
            gameTimer.Interval = 1000;
        }
    }
}
