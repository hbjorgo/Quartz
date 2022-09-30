# Quartz
[![CI](https://github.com/hbjorgo/Quartz/workflows/CI/badge.svg)](https://github.com/hbjorgo/Quartz)
[![Nuget](https://img.shields.io/nuget/v/hebotech.Quartz)](https://www.nuget.org/packages/HeboTech.Quartz)
[![Nuget](https://img.shields.io/nuget/dt/HeboTech.Quartz)](https://www.nuget.org/packages/HeboTech.Quartz)

Quartz is a C# library that abstracts the system clock to facilitate testing.

Feedback is very much welcome and please request features 🙂

## Usage
Install as NuGet package:
```shell
dotnet add package HeboTech.Quartz
```

Example usage in production code in ASP.NET Core
```csharp
// Set up during application startup
builder.Services.AddSingleton<ISystemClock, SystemClock>();
```
Example usage in classes
```csharp
// Use in classes
public class MyService
{
    private readonly ISystemClock _systemClock;

    public MyService(ISystemClock systemClock)
    {
        _systemClock = systemClock;
    }

    public int ReturnCurrentYear()
    {
        return _systemClock.UtcNow.Year;
    }
}
```


Example usage when running unit tests
```csharp
//Arrange
DateTime startTime = new DateTime(1970, 1, 1);
CustomClock systemClock = new CustomClock(startTime);
MyService myService = new MyService(systemClock);

// Act
int currentYear = myService.ReturnCurrentYear();

// Assert
Assert.Equal(1970, currentYear);

// Set a new time
DateTime newTime = new DateTime(2022, 1, 1);
TimeService.Set(newTime);

// Continue testing ...
```
