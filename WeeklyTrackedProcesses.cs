using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;



namespace ScreenTime
{
    [DataContract]
    public class WeeklyTrackedProcesses
    {
        [DataMember]
        private Dictionary<DateTime, DailyTrackedProcesses> _trackedProcesses;

        [DataMember]
        private Dictionary<string, string> _trackedProcessesNames;

        public Dictionary<DateTime, DailyTrackedProcesses> TrackedProcesses
        {
            get => _trackedProcesses;
        }

        private DailyTrackedProcesses this[DateTime date]
        {
            get {
                DateTime onlyDate = date.Date;
                
                if (!TrackedProcesses.ContainsKey(onlyDate))
                {
                    TrackedProcesses[onlyDate] = new DailyTrackedProcesses(onlyDate);
                }

                return TrackedProcesses[onlyDate];
            }
        }

        public void AddProcess(string processName, string path, TimeSpan duration, DateTime date)
        {
            this[date].AddProcess(path, duration);

            if (!_trackedProcessesNames.ContainsKey(path))
            {
                _trackedProcessesNames.Add(path, processName);
            }
        }


        public Dictionary<string, TimeSpan>? GetProcessesByDate(DateTime date)
        {
            date = date.Date;

            return (_trackedProcesses.ContainsKey(date)) ?
                _trackedProcesses[date].GetProcesses() : null;
        }

        public Dictionary<DateTime, DailyTrackedProcesses> GetProcessesByDates(DateTime start, DateTime end)
        {
            start = start.Date;
            end = end.Date;

            //return _trackedProcesses.Where(item => item.Key >= start && item.Key <= end)
            //    .OrderBy(item => item.Key).ToDictionary(x => x.Key, x => x.Value);

            Dictionary < DateTime, DailyTrackedProcesses> result = 
                new Dictionary<DateTime, DailyTrackedProcesses>();

            while (start <= end)
            {
                if (_trackedProcesses.ContainsKey(start))
                    result.Add(start, _trackedProcesses[start]);
                else
                    result.Add(start, new DailyTrackedProcesses(start));

                start = start.AddDays(1);
            }

            return result;
        }

        public string GetProcessName(string path) => _trackedProcessesNames[path];

        public TimeSpan GetSum(DateTime date) => this[date].GetSum();

        public int GetPercentage(DateTime date, string path) => this[date].GetPercentage(path);

        public WeeklyTrackedProcesses()
        {
            _trackedProcesses = new Dictionary<DateTime, DailyTrackedProcesses>();

            _trackedProcessesNames = new Dictionary<string, string>();
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static WeeklyTrackedProcesses Deserialize(string data)
        {
            WeeklyTrackedProcesses? result;
            
            if (data == null)
                result = new WeeklyTrackedProcesses();
            else
                result = JsonConvert.
                DeserializeObject<WeeklyTrackedProcesses>(data);
             
            
            return (result == null) ? 
                new WeeklyTrackedProcesses() : result;
        }
    }
}
