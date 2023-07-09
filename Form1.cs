using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView.WinForms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Globalization;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView.SKCharts;
using LiveChartsCore.VisualElements;
using System.Collections.Generic;
using Microsoft.Win32;

namespace ScreenTime
{
    public partial class Form1 : MaterialForm
    {
        private bool isClosed;

        private DateTime _searchedDate;

        private ObservableCollection<ObservableValue> _dailyChartData;

        private CultureInfo _culture;

        //private int _weekCoefficient;

        private ProcessHandler _processHandler;

        private delegate void SetShowCaseInfo(Control control, string processName, TimeSpan duration, int percents, Image image = null);
        private delegate void HandleShowCase(Control control);

        public void AddNewShowCase(Control control, string processName, TimeSpan duration, int percents, Image image)
        {
            if (control.InvokeRequired)
            {
                SetShowCaseInfo d = new SetShowCaseInfo(AddNewShowCase);
                Invoke(d, new Object[] { control, processName, duration, percents, image });
            }
            else
            {
                AppScreenTimeCard item = new AppScreenTimeCard(image,
                processName, duration, percents);

                control.Controls.Add(item);
                //materialLabel1.Text = $"{trackedProcesses[DateTime.Now].GetSum().Seconds.ToString("0.#")} с";
            }
        }

        public void UpdateScreenTimeCardInfo(Control control, string processName, TimeSpan duration, int percents, Image image)
        {
            if (control.InvokeRequired)
            {
                SetShowCaseInfo d = new SetShowCaseInfo(UpdateScreenTimeCardInfo);
                Invoke(d, new Object[] { control, processName, duration, percents, image });
            }
            else
            {
                AppScreenTimeCard? card = control as AppScreenTimeCard;

                card?.UpdateInfo(image, processName, duration, percents);
            }
        }

        public void ClearControlShowCase(Control control)
        {
            if (control.InvokeRequired)
            {
                HandleShowCase d = new HandleShowCase(ClearControlShowCase);
                Invoke(d, new Object[] { control });
            }
            else
            {
                control.Controls.Clear();
            }
        }


        public void UpdateChart(Control control)
        {
            if (control.InvokeRequired)
            {
                HandleShowCase d = new HandleShowCase(UpdateChart);
                Invoke(d, new Object[] { control });
            }
            else
            {
                CartesianChart? chart = control as CartesianChart;

                if (chart == null) return;

                DateTime today = DateTime.Now.Date;

                DateTime[] steps = Program.GetStartToEndDateTimes(_searchedDate, 0);

                if (today >= steps[0] && today <= steps[1])
                {
                    _dailyChartData[Program
                        .FixDayOfWeek((int)today.DayOfWeek) - 1].Value =
                        Math.Round(_processHandler
                        .GetSum(today)
                        .TotalHours, 1);
                }
            }
        }

        private void SetChartsStartData(bool needToUpdateValues = false)
        {
            DateTime[] steps = Program.GetStartToEndDateTimes(_searchedDate, 0);

            Dictionary<DateTime, DailyTrackedProcesses> data =
                _processHandler.GetProcessesByDates(steps[0], steps[1]);

            chartDatesLabel.Text = $"Статистика за тиждень: {String.Join(" - ", steps
                    .Select(item => item.ToString("d MMMM", _culture))).Replace(".", "")}";

            cartesianChart1.XAxes = new List<Axis>
            {
                new Axis
                {
                    Position = LiveChartsCore.Measure.AxisPosition.End,
                // Use the labels property to define named labels.
                Labels = data.Keys.Select(item => item.ToString("ddd", _culture).ToUpper()).ToArray()
                }
            };

            cartesianChart1.YAxes = new List<Axis>
{
                new Axis
                {
                    MinLimit = 0,
                    MinStep = 0.1
                }
            };

            if (!needToUpdateValues) return; // Не потрібно оновлювати дані

            _dailyChartData.Clear();

            foreach (var item in data.Values.Select(item => Math.Round(item.GetSum().TotalHours, 1)))
                _dailyChartData.Add(new ObservableValue(item));

            ObservableCollection<ISeries> series = new ObservableCollection<ISeries>();
            cartesianChart1.Series = series;

            series.Add(new ColumnSeries<ObservableValue>
            {
                Fill = new SolidColorPaint(new SKColor(66, 165, 245)),
                Name = "Загальний час",
                Values = _dailyChartData,
                YToolTipLabelFormatter =
                (chartPoint) => $"{chartPoint.PrimaryValue} год",

            });


        }

        private void UpdateShowCase(Control control)
        {
            //if (_processHandler
            //    .getOpenedProcess().ProcessName == "ScreenTime")
            //    return;

            if (control.InvokeRequired)
            {
                HandleShowCase d = new HandleShowCase(UpdateShowCase);
                Invoke(d, new Object[] { control });
                return;
            }

            var processes = _processHandler.GetProcessesByDate(_searchedDate);

            if (processes == null)
                processes = new Dictionary<string, TimeSpan>();

            //if (control.Controls.Count > processes.Count)
            //    ClearControlShowCase(control);

            while (control.Controls.Count > processes.Count)
            {
                lock (control)
                {
                    control.Controls.RemoveAt(control.Controls.Count - 1);
                }

            }

            int i = 0;
            foreach (KeyValuePair<string, TimeSpan> item in processes)
            {
                if (i >= control.Controls.Count)
                {
                    AddNewShowCase(control,
                    _processHandler.GetProcessName(item.Key),
                    item.Value,
                    _processHandler.GetPercentage(item.Key, _searchedDate),
                    _processHandler.GetProcessIcon(item.Key));
                }
                else
                {
                    UpdateScreenTimeCardInfo(control.Controls[i],
                    _processHandler.GetProcessName(item.Key),
                    item.Value,
                    _processHandler.GetPercentage(item.Key, _searchedDate),
                    _processHandler.GetProcessIcon(item.Key));

                }
                i++;

            }
        }

        private void UpdateAllShowCases()
        {
            Thread t1 = new Thread(() =>
            {
                while (!isClosed)
                {
                    UpdateShowCase(flowLayoutPanel1);
                    UpdateChart(cartesianChart1);
                    Thread.Sleep(1000);
                }
            });
            t1.IsBackground = true;
            t1.Start();
        }

        public void SetAnotherDayData(int addDays)
        {
            _searchedDate = _searchedDate.AddDays(addDays);

            bool isPreviousWeek = addDays < 0 &&
                _searchedDate.DayOfWeek == DayOfWeek.Sunday;

            bool isNextWeek = addDays > 0 &&
                _searchedDate.DayOfWeek == DayOfWeek.Monday;

            SetChartsStartData(isPreviousWeek || isNextWeek);
            SetSearchDateText();
        }

        public void SetSearchDateText()
        {
            DateTime today = DateTime.Today;
            //searchDateLabel.Text = (_searchedDate == today) ?
            //    "Сьогодні" +  $"{s}": $"{_searchedDate.ToString("")}"

            if (_searchedDate == today)
                searchDateLabel.Text = "Сьогодні";
            else if (_searchedDate == today.AddDays(-1))
                searchDateLabel.Text = "Учора";
            else
                searchDateLabel.Text = _culture.TextInfo
                    .ToTitleCase(_searchedDate
                    .ToString("dddd", _culture));

            searchDateLabel.Text += ", " +
                _searchedDate.ToString("d MMMM", _culture) + ": ";

            TimeSpan sum = _processHandler.GetSum(_searchedDate);
            if (sum.Hours > 0)
                searchDateLabel.Text += $"{sum.Hours} год ";

            searchDateLabel.Text += $"{sum.Minutes} хв";

        }

        public Form1()
        {
            SetOnWindowsStartup();
            isClosed = false;
            _dailyChartData = new ObservableCollection<ObservableValue>();
            _searchedDate = DateTime.Now.Date;
            _processHandler = new ProcessHandler();
            _culture = new CultureInfo("uk-UA");
            InitializeComponent();

            notifyIcon1.Text = this.Text;
            notifyIcon1.BalloonTipTitle = "App Notification";
            notifyIcon1.Visible = false;

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue400, // Основний колір
                Primary.Blue500, // Основний темний колір
                Primary.Blue200, // Основний світлий колір
                Accent.LightBlue200, // Вторинний колір
                TextShade.WHITE
            );

            this.SizeChanged += Form1_SizeChanged;

            flowLayoutPanel1.ControlAdded += FlowLayoutPanel1_ControlAdded;

            _processHandler.LoadProcesses();

            SetSearchDateText();

            SetChartsStartData(true);

            _processHandler.StartCounting();

            UpdateAllShowCases();
        }

        public void SetOnWindowsStartup()
        {
            if (DataLoader.SaveFileExists()) return;

            RegistryKey? reg = Registry.CurrentUser
                .OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run",
                true);

            if (reg != null && reg.GetValue("ScreenTime") == null)
            {
                reg.SetValue("ScreenTime", Application.ExecutablePath);
            }


        }

        private void FlowLayoutPanel1_ControlAdded(object? sender, ControlEventArgs e)
        {
            FixFlowLayout(flowLayoutPanel1);
        }

        private void FixFlowLayout(FlowLayoutPanel flowLayoutPanel)
        {
            if (flowLayoutPanel.Controls.Count == 0)
            {
                return;
            }

            int itemsCount = flowLayoutPanel.Controls.Count;
            Control firstElement = flowLayoutPanel.Controls[0];

            int widthCoefficient = (flowLayoutPanel.Width -
                firstElement.Margin.Left * 2 - SystemInformation.VerticalScrollBarWidth) /
                (firstElement.Width + firstElement.Margin.Left * 2 + SystemInformation.VerticalScrollBarWidth);


            int paddingCoefficient = Math.Min(itemsCount,
                widthCoefficient);

            paddingCoefficient = Math.Max(paddingCoefficient, 1);

            int scrollBarDependency = (flowLayoutPanel.VerticalScroll.Visible) ?
                SystemInformation.VerticalScrollBarWidth : 0;

            flowLayoutPanel.Padding = new Padding(
                (flowLayoutPanel.Width - (firstElement.Width + firstElement.Margin.Left) * paddingCoefficient - scrollBarDependency) / 2,
                0,
                0,
                0);

            //materialLabel1.Text = this.Size.ToString();
        }

        private void Form1_SizeChanged(object? sender, EventArgs e)
        {
            FixFlowLayout(flowLayoutPanel1);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
                notifyIcon1.Visible = true;
                //notifyIcon1.ShowBalloonTip(1000);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _processHandler.SaveProcesses();
            notifyIcon1.Dispose();
            Application.Exit();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            openToolStripMenuItem_Click(sender, e);
        }

        private void dateBackButton_Click(object sender, EventArgs e)
        {
            SetAnotherDayData(-1);
        }

        private void dateForwardButton_Click(object sender, EventArgs e)
        {
            SetAnotherDayData(1);
        }
    }
}