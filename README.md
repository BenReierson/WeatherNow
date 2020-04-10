# WeatherNow

A single-page iOS and Android app to display the weather in your current location.

Built using Xamarin Forms, on an MVVM architecture, with UI layout in XAML. 

Completed April 2020 to demonstrate understanding of tools and architecture. 

Limitations
- Requires location permission to display weather
- Hard-coded apikey limited to 1k calls/day
- Only displays temp in celcius

Frameworks and libraries used
- C# 8 (nullable enabled)
- Xamarin Forms
- Xamarin Essentials
- Json.Net
- Nunit
- MVVMHelpers
- Moq
- OpenWeatherMap API (free key embedded)

Patterns and features showcased
- Model-View-ViewModel (MVVM)
- Themeing (light/dark)
- IOC
- Highly modular and testable code
- Unit tests with mock services/data (not comprehensive)
- Fully shared cross-platform codebase

Patterns I often use but are intentionally not included
- automated dependency injection
- viewmodel-based navigation
- http caching and retry/resilience (ex. akavache, polly)
- logging and analytics
- environment configuration
