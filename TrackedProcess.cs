using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace ScreenTime
{
    public class TrackedProcess : IComparable<TrackedProcess>
    {
        public string Path { get; set; }
        public double Duration { get; set; }


        public TrackedProcess(string filePath, double duration)
        {
            Path = filePath;
            Duration = duration;
        }

        // override object.Equals
        public override bool Equals(object? other)
        {

            TrackedProcess? otherItem = other as TrackedProcess;
            
            if (otherItem == null) return false;

            return Path.Equals(otherItem.Path);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return Path.GetHashCode();
        }

        public override string ToString() => $"{Path} {Duration}";

        public int CompareTo(TrackedProcess? otherItem)
        {
            if (otherItem == null || this.Equals(otherItem)) return 0;

            return Duration.CompareTo(otherItem.Duration);
        }

        public static TrackedProcess operator+ (TrackedProcess first, TrackedProcess second)
        {
            if (first.Path != second.Path)
                throw new ArgumentException("Tracked processes have different paths");

            return new TrackedProcess(first.Path, first.Duration + second.Duration);
        }
    }
}
