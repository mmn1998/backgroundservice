using System;
using System.Collections.Generic;
using Serilog;
using System.Text;
using System.Threading;
using Microsoft.Extensions.Logging;

namespace TestBackgroundService
{
    public class Executer : Singleton<Executer>
    {
        private readonly System.Timers.Timer timer;
        private static ILogger<ServiceAgent> _log;
        public Executer()
        {
            timer = new System.Timers.Timer(5 /** 60 **/* 1000);
            timer.Elapsed += Timer_Elapsed;
        }
        public void Start(ILogger<ServiceAgent> logger)
        {
            _log = logger;
            timer.Enabled = true;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                // Code here
                _log.LogInformation("Sevice Proccess ...... ");
            }
            catch (Exception ex)
            {
                _log.LogError("Exception in Confirmation", ex);
            }
        }
    }
}
