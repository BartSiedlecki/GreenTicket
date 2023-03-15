namespace GreenTicket_WebAPI.Services.Helpers
{
    public class RandomDate
    {
        private Random random = new Random();

        public DateTime Date(DateTime? start = null, DateTime? end = null)
        {
            if (start.HasValue && end.HasValue && start.Value >= end.Value)
                throw new Exception("Start date must be less than end date!");

            DateTime min = start is null ? DateTime.Now.AddMonths(-6) : DateTime.MinValue;
            DateTime max = end is null ? DateTime.Now : DateTime.MinValue;

            TimeSpan timeSpan = max - min;

            byte[] bytes = new byte[8];
            random.NextBytes(bytes);

            long int64 = Math.Abs(BitConverter.ToInt64(bytes, 0)) % timeSpan.Ticks;

            TimeSpan newSpan = new TimeSpan(int64);

            return min + newSpan;
        }

    }
}
