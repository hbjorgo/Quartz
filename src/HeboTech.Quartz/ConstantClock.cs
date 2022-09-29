using System;

namespace HeboTech.Quartz
{
    public class ConstantClock : ISystemClock
    {
        private Func<DateTimeOffset> timeFunc;

        public ConstantClock()
        {
            timeFunc = () => DateTime.MinValue;
        }

        public ConstantClock(DateTimeOffset time)
        {
            timeFunc = () => time;
        }

        public ConstantClock(Func<DateTimeOffset> timeFunc)
        {
            this.timeFunc = timeFunc ?? throw new ArgumentNullException(nameof(timeFunc));
        }

        public ConstantClock(DateTime time)
        {
            timeFunc = () => time;
        }

        public ConstantClock(Func<DateTime> timeFunc)
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
    }
}
