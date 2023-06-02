namespace Bookkeeper.Model
{
    public class UnixTimestampConverter
    {
        public static DateTime UnixTimestampToDateTime(int date)
        {
            // The code in this method is from the following source:
            // https://stackoverflow.com/a/250400/16747568

            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(date).ToLocalTime();
            return dateTime;
        }

        public static int DateTimeToUnixTimestamp(DateTime date)
        {
            return (int)date.ToUniversalTime().Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        }
    }
}
