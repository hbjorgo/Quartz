namespace HeboTech.Quartz.Tests
{
    public class CustomClockTests
    {
        [Fact]
        public void Default_constructor_initialize_with_DateTimeOffset_min_value()
        {
            ISystemClock customClock = new CustomClock();

            Assert.Equal(DateTimeOffset.MinValue, customClock.UtcNow);
        }

        [Fact]
        public void Setting_custom_DateTimeOffset_through_constructor_returns_the_custom_time()
        {
            DateTimeOffset time = new(2022, 1, 1, 0, 0, 0, TimeSpan.Zero);
            ISystemClock customClock = new CustomClock(time);

            Assert.Equal(time, customClock.UtcNow);
        }

        [Fact]
        public void Setting_custom_DateTimeOffset_func_through_constructor_returns_the_custom_time()
        {
            DateTimeOffset time = new(2022, 1, 1, 0, 0, 0, TimeSpan.Zero);
            ISystemClock customClock = new CustomClock(() => time);

            Assert.Equal(time, customClock.UtcNow);
        }

        [Fact]
        public void Setting_custom_DateTime_through_constructor_returns_the_custom_time()
        {
            DateTime time = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            ISystemClock customClock = new CustomClock(time);

            Assert.Equal(time, customClock.UtcNow);
        }

        [Fact]
        public void Setting_custom__DateTime_func_through_constructor_returns_the_custom_time()
        {
            DateTime time = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            ISystemClock customClock = new CustomClock(() => time);

            Assert.Equal(time, customClock.UtcNow);
        }

        [Fact]
        public void Set_DateTimeOffset_returns_the_custom_time()
        {
            DateTimeOffset time = new(2022, 1, 1, 0, 0, 0, TimeSpan.Zero);
            CustomClock customClock = new CustomClock();
            customClock.Set(time);

            Assert.Equal(time, customClock.UtcNow);
        }

        [Fact]
        public void Set_DateTimeOffset_func_returns_the_custom_time()
        {
            DateTimeOffset time = new(2022, 1, 1, 0, 0, 0, TimeSpan.Zero);
            CustomClock customClock = new CustomClock();
            customClock.Set(() => time);

            Assert.Equal(time, customClock.UtcNow);
        }

        [Fact]
        public void Set_DateTime_returns_the_custom_time()
        {
            DateTime time = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            CustomClock customClock = new CustomClock();
            customClock.Set(time);

            Assert.Equal(time, customClock.UtcNow);
        }

        [Fact]
        public void Set_DateTime_func_returns_the_custom_time()
        {
            DateTime time = new(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            CustomClock customClock = new CustomClock();
            customClock.Set(() => time);

            Assert.Equal(time, customClock.UtcNow);
        }
    }
}
