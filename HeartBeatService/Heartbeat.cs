using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace HeartBeatService
{
   public class Heartbeat
    {
        private readonly Timer _timer;
        public Heartbeat()
        {
            _timer = new Timer(1000000000) { AutoReset = true };
            _timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            string[] lines = new string[] { DateTime.Now.ToString() };
            File.AppendAllLines(@"C:\Temp\Demo\Heartbeat.txt", lines);
            Console.WriteLine("Ope is naughty");
            //send customer birthday wishes
        }
        public void Start()
        {
            _timer.Start();
        }
        public void Stop()
        {
            _timer.Stop();
        }

    }
}
