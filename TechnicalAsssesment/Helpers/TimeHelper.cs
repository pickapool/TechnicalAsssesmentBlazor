namespace TechnicalAsssesment.Helpers
{
    public static class TimeHelper
    {
        public static double ConvertToHour(double minutes)
        {
            return minutes / 60.0;
        }
        public static string ConvertToHourFormat(double hour)
        {
            TimeSpan time = TimeSpan.FromHours(ConvertToHour(hour));
            return time.ToString(@"hh\:mm");
        }
    }
}
