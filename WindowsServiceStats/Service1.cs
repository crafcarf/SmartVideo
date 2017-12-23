﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceStats
{
    public partial class Service1 : ServiceBase
    {
        System.Timers.Timer _timer;
        DateTime _scheduleTime;
        public Service1()
        {
            InitializeComponent();
            _timer = new System.Timers.Timer();
            _scheduleTime = DateTime.Today.AddHours(16).AddMinutes(35);
        }
        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            DateTime now = DateTime.Now;
            if (_scheduleTime < DateTime.Now)
            {
                TimeSpan span = now - DateTime.Now;
                _scheduleTime = _scheduleTime.AddMilliseconds(span.Milliseconds).AddDays(1);
                
            }
          
        }
        protected override void OnStart(string[] args)
        {
            _timer.Enabled = true;
            _timer.Interval = _scheduleTime.Subtract(DateTime.Now).TotalSeconds * 1000;
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
        }

        protected override void OnStop()
        {
        }
    }
}
