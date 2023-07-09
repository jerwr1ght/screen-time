using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ScreenTime
{
    [DataContract]
    public class DailyTrackedProcesses : IComparable<DailyTrackedProcesses>
    {
        [DataMember]
        private Dictionary<string, TimeSpan> _processes;

        [DataMember]
        private DateTime _trackDate;

        public DateTime TrackDate { get => _trackDate; }

        public TimeSpan this[string path]
        {
            get => _processes[path];
        }

        public DailyTrackedProcesses(DateTime trackDate)
        {
            _processes = new Dictionary<string, TimeSpan>();
            _trackDate = trackDate;
        }

        public bool AddProcess(string path, TimeSpan duration)
        {
            bool result = _processes.TryAdd(path, duration);

            if (!result)
            {
                _processes[path] += duration;
            }

            return result;
        }

        public int GetPercentage(string path)
        {
            double result = this[path].TotalSeconds / GetSum().TotalSeconds * 100;

            return (int)result;
        }

        public TimeSpan GetSum()
        {
            //TimeSpan sum = TimeSpan.Zero;
            //foreach (TimeSpan timeSpan in _processes.Values)
            //    sum += timeSpan;
            //return sum;

            return TimeSpan.FromTicks(_processes.Values
                .Sum(timeSpan => timeSpan.Ticks));

        }

        public int CompareTo(DailyTrackedProcesses? otherItem)
        {
            if (otherItem == null || this.Equals(otherItem)) return 0;

            return TrackDate.CompareTo(otherItem.TrackDate);
        }

        public Dictionary<string, TimeSpan> GetProcesses() 
        {
            return _processes
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
