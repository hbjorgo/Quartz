using System;

namespace HeboTech.Quartz
{
    public class CustomClock : ISystemClock
    {
        private Func<DateTimeOffset> timeFunc;

        public CustomClock()
        {
            timeFunc = () => DateTimeOffset.MinValue;
        }

        public CustomClock(DateTimeOffset time)
        {
            timeFunc = () => time;
        }

        public CustomClock(Func<DateTimeOffset> timeFunc)
        {
            if (timeFunc == null)
                throw new ArgumentNullException(nameof(timeFunc));

            this.timeFunc = timeFunc;
        }

        public CustomClock(DateTime time)
        {
            timeFunc = () => time;
        }

        public CustomClock(Func<DateTime> timeFunc)
        {
            if (timeFunc == null)
                throw new ArgumentNullException(nameof(timeFunc));

            this.timeFunc = () => timeFunc();
        }

        public DateTimeOffset UtcNow => timeFunc();

        /// <summary>
        /// Sets the current time. The func can either return a constant time, or a dynamic one (like DateTimeOffset.UtcNow).
        /// </summary>
        /// <param name="timeFunc">Func that returns the current time</param>
        public void Set(Func<DateTimeOffset> timeFunc)
        {
            this.timeFunc = timeFunc ?? throw new ArgumentNullException(nameof(timeFunc));
        }

        /// <summary>
        /// Sets the current (constant) time.
        /// </summary>
        /// <param name="time">The current (constant) time</param>
        public void Set(DateTimeOffset time)
        {
            timeFunc = () => time;
        }

        /// <summary>
        /// Sets the current time. The func can either return a constant time, or a dynamic one (like DateTime.UtcNow).
        /// </summary>
        /// <param name="timeFunc">Func that returns the current time</param>
        public void Set(Func<DateTime> timeFunc)
        {
            if (timeFunc == null)
                throw new ArgumentNullException(nameof(timeFunc));

            this.timeFunc = () => timeFunc();
        }

        /// <summary>
        /// Sets the current (constant) time.
        /// </summary>
        /// <param name="time">The current (constant) time</param>
        public void Set(DateTime time)
        {
            timeFunc = () => time;
        }
    }
}
