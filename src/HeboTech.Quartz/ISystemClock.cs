using System;

namespace HeboTech.Quartz
{
    /// <summary>
    /// Abstracts the system clock to facilitate testing.
    /// </summary>
    public interface ISystemClock
    {
        /// <summary>
        /// Returns the current system time in UTC.
        /// </summary>
        DateTimeOffset UtcNow { get; }
    }
}
