﻿using myfoodapp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;

namespace myfoodapp.Business
{
    public sealed class UptimeBackgroundTask
    {
        private BackgroundWorker bw = new BackgroundWorker();
        private LogModel logModel = new LogModel();

        public string UptimeSystem;

        public UptimeBackgroundTask()
        {
            logModel.AppendLog(Log.CreateLog("Uptime Service starting...", Log.LogType.System));

            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += Bw_DoWork;
            bw.ProgressChanged += Bw_ProgressChanged;
            bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
        }

        public void Run()
        {
            logModel.AppendLog(Log.CreateLog("Uptime Service running...", Log.LogType.System));
            bw.RunWorkerAsync();
        }

        public void Stop()
        {
            bw.CancelAsync();
        }

        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            logModel.AppendLog(Log.CreateLog("Uptime Service stopping...", Log.LogType.System));
        }

        private void Bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            var watch = Stopwatch.StartNew();

            while (!bw.CancellationPending)
            {
                var elapsedMs = watch.ElapsedMilliseconds;

                if(elapsedMs % 20000 == 0)
                {
                    TimeSpan t = TimeSpan.FromMilliseconds(elapsedMs);
                    string logDescription = string.Format("App running since {0:D2}h:{1:D2}m:{2:D2}s",
                                            t.Hours,
                                            t.Minutes,
                                            t.Seconds,
                                            t.Milliseconds);

                    UptimeSystem = string.Format("{0:D2}h:{1:D2}m:{2:D2}s",
                                            t.Hours,
                                            t.Minutes,
                                            t.Seconds,
                                            t.Milliseconds);

                    logModel.AppendLog(Log.CreateLog(logDescription, Log.LogType.Information));
                }
            }

            watch.Stop();      
        }
    }
}