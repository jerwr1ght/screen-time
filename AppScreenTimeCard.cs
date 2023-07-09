using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ScreenTime
{
    public partial class AppScreenTimeCard : UserControl
    {
        public static Size ConstSize = new Size(350, 80);

        public AppScreenTimeCard()
        {
            InitializeComponent();

        }

        private string getStringDuration(TimeSpan duration)
        {
            string postfix;
            double extractedValue;


            if (duration.TotalHours >= 1)
            {
                return $"{Math.Round((double)duration.Hours, 1)
                .ToString("0.#").Replace(",", ".")} год " +
                $"{Math.Round((double)duration.Minutes, 1)
                .ToString("0.#").Replace(",", ".")} хв";
            }
            else if (duration.Minutes >= 1)
            {
                extractedValue = duration.Minutes;
                postfix = "хв";
            }
            else
            {
                extractedValue = duration.Seconds;
                postfix = "с";
            }

            return $"{extractedValue
                .ToString("0.#").Replace(",", ".")} {postfix}";
        }

        public AppScreenTimeCard(Image image, string processName, TimeSpan duration, int percents)
        {
            InitializeComponent();
            //this.Name = processName;
            appIcon.Image = image;
            appName.Text = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(processName);
            timeLabel.Text = getStringDuration(duration);
            progressBar.Value = percents;
        }

        public void UpdateInfo(Image image, string processName, TimeSpan duration, int percents)
        {
            //this.Name = processName;
            appIcon.Image = image;
            appName.Text = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(processName);
            timeLabel.Text = getStringDuration(duration);
            progressBar.Value = percents;
        }
    }
}
