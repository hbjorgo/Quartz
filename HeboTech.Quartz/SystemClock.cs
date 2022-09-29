using System;

namespace HeboTech.Quartz
{
    public class SystemClock : ISystemClock
    {
        public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
    }
}
