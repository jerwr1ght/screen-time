namespace ScreenTime
{
    internal static class Program
    {
        public static int FixDayOfWeek(int day) => 
            (day == 0) ? 7 : day;

        public static DateTime[] GetStartToEndDateTimes(DateTime date, 
            int weekCoefficient)
        {
            date = date.Date;

            DateTime startDate = date
            .AddDays(1 -
            Program.FixDayOfWeek((int)date.DayOfWeek) + 7 * weekCoefficient);

            DateTime endDate = startDate.AddDays(6);

            return new DateTime[] {startDate,endDate};

        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}