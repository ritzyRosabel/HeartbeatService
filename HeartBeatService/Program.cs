using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace HeartBeatService
{
    class Program
    {
        //If this code works, then it was writen by Rosabel Olugbenga. If it doesn't, then i can only say one thing  "IT IS WHAT IT IS".
        static void Main(string[] args)
        {
           
           // SendMailSevice.SendaMail();
           // var exitCode = HostFactory.Run(x =>
           //{
           //    x.Service<Heartbeat>(s =>
           //    {
           //        s.ConstructUsing(heartbeat => new Heartbeat());
           //        s.WhenStarted(heartbeat => heartbeat.Start());
           //        s.WhenStopped(heartbeat => heartbeat.Stop());
           //    });
           //    x.RunAsLocalSystem();
           //    x.SetServiceName("HeartBeatService");
           //    x.SetDisplayName("Heartbeat Service");
           //    x.SetDescription("records my regular heart beat per time");
           //});

           // var exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
           // Environment.ExitCode = exitCodeValue;

        }
    }
}
