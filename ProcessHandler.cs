using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenTime
{
    public class ProcessHandler
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        private WeeklyTrackedProcesses _trackedProcesses;

        public Process GetOpenedProcess()
        {
            IntPtr foregroundWindowHandle = GetForegroundWindow();
            int foregroundProcessId;
            Process foregroundProcess;

            GetWindowThreadProcessId(foregroundWindowHandle, out foregroundProcessId);
            foregroundProcess = Process.GetProcessById(foregroundProcessId);
            return foregroundProcess;
        }

        public Image? GetProcessIcon(Process process) => Icon.ExtractAssociatedIcon(process.MainModule?.FileName)?
            .ToBitmap();

        public Image? GetProcessIcon(string filePath) => Icon.ExtractAssociatedIcon(filePath)?
            .ToBitmap();


        private void CountDuration()
        {
            Process currentProcess = GetOpenedProcess();
            if (currentProcess.ProcessName == "explorer" ||
                currentProcess.ProcessName == "ScreenTime")
                return;

            ProcessModule? module;
            try
            {
                module = currentProcess.MainModule;
            }
            catch (System.ComponentModel.Win32Exception)
            {
                return;
            }

            DateTime startTime = DateTime.Now;

            while (currentProcess.Id == GetOpenedProcess().Id)
            {
                Thread.Sleep(1000);
            }

            TimeSpan duration = DateTime.Now - startTime;

            _trackedProcesses.AddProcess(currentProcess.ProcessName, module?.FileName, duration, startTime);

        }

        public void StartCounting()
        {
            Thread t1 = new Thread(() =>
            {
                while (true)
                {
                    //Thread.Sleep(1000);
                    //CountDuration();
                    CountDuration();
                    SaveProcesses();
                    Thread.Sleep(100);
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        public Dictionary<string, TimeSpan>? GetProcessesByDate(DateTime date)
        {
            lock (_trackedProcesses)
            {
                return _trackedProcesses?.GetProcessesByDate(date);
            }
            
        }

        public Dictionary<DateTime, DailyTrackedProcesses> GetProcessesByDates(DateTime start, DateTime end)
        {
            return _trackedProcesses.GetProcessesByDates(start, end);
        }

        public string GetProcessName(string path) => _trackedProcesses.GetProcessName(path);

        public TimeSpan GetSum(DateTime date) => _trackedProcesses.GetSum(date);

        public int GetPercentage(string path, DateTime date) => _trackedProcesses.GetPercentage(date, path);

        public void SaveProcesses()
        {
            Thread t1 = new Thread(() =>
            {
                DataLoader.Save(_trackedProcesses.Serialize());
            });
            t1.IsBackground = true;
            t1.Start();

            //DataLoader.Save(_trackedProcesses.Serialize());
        }

        public void LoadProcesses()
        {
            string? data = null;
            //Thread t1 = new Thread(() =>
            //{
            //    data = DataLoader.Load();
            //});
            //t1.IsBackground = true;
            //t1.Start();

            //Task<string?> task = Task.Run<string?>(async () => await DataLoader.Load());

            data = DataLoader.Load();

            _trackedProcesses = WeeklyTrackedProcesses.Deserialize(data);
        }

        public ProcessHandler()
        {
            _trackedProcesses = new WeeklyTrackedProcesses();
        }

    }
}
