namespace HeboTech.Quartz.Tests
{
    public class SystemClockTests
    {
        [Fact]
        public void UtcNow_returns_current_system_time()
        {
            // Arrange
            ISystemClock systemClock = new SystemClock();
            DateTimeOffset utcNow = DateTimeOffset.UtcNow;

            // Assert
            Assert.Equal(utcNow.UtcDateTime, systemClock.UtcNow.UtcDateTime, TimeSpan.FromSeconds(2));
        }

        [Fact]
        public void UtcNow_returns_time_in_Utc()
        {
            // Arrange
            ISystemClock systemClock = new SystemClock();

            // Assert
            Assert.Equal(TimeSpan.Zero, systemClock.UtcNow.Offset);
        }
    }
}