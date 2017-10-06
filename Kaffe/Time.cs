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
            gameTimer = new Timer()
            {
                Interval = 1000
            };
        }

        private static void OnGameTick(object sender, ElapsedEventArgs e)
        {
            
        }
    }
}
