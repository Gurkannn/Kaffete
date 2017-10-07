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

        public static void InitializeTimer(int ms)
        {
            if (gameTimer != null)
                if (gameTimer.Enabled)
                    gameTimer.Enabled = false;

            gameTimer = new Timer()
            {
                Interval = ms
            };

            gameTimer.Elapsed += OnGameTick;
            gameTimer.Enabled = true;
        }

        public static void DecreaseInterval()
        {
            if (gameTimer.Interval > 100)            
                gameTimer.Interval -= 20;            
        }

        public static void StopTimer()
        {
            if (gameTimer.Enabled)
                gameTimer.Enabled = false;
        }

        private static void OnGameTick(object sender, ElapsedEventArgs e)
        {
            Map.MovePlayer();
            Map.DrawMap();
            Map.DecreaseTailTimer();
        }
    }
}
