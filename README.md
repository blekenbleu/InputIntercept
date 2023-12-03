### Forked from [MP3Martin/InputInterceptor-PersonalFork](https://github.com/MP3Martin/InputInterceptor-PersonalFork),  
which added bool returns to [0x2E757](https://github.com/0x2E757) @ https://github.com/0x2E757/InputInterceptor/  
C# wrapper for Francisco Lopes' mouse and keyboard [Interception API](https://www.oblita.com/interception.html)

This fork
- modified the [`CallbackAction` delegate](blob/master/InputInterceptor/Classes/Hook.cs#L13)
 to also pass numeric [`Context` and `device`](blob/master/InputInterceptor/Classes/Hook.cs#L68),  
 enabling callbacks to selectively divert devices.
- modified Initialize() to detect null bytes from missing/defective `interception_x*.dll`,  
 instead returning false

**Note!**
- A [WPF XAML](https://github.com/blekenbleu/WPF_XAML) app directly accessing this `static class`
 [crashes](https://github.com/blekenbleu/InputInterceptor-PersonalFork/blob/3193937a7edbd6268ef19ec5ab6afa3079a4ac36/InputInterceptor/InputInterceptor.cs#L24)  
	- until delayed after [`InputInterceptor.Initialize()`](https://github.com/blekenbleu/InputInterceptor-PersonalFork/blob/3193937a7edbd6268ef19ec5ab6afa3079a4ac36/InputInterceptor/InputInterceptor.cs#L45)
- This crash <i>did not</i> occur in a [console app](https://github.com/blekenbleu/InterceptMouse), go figure.
	- [This *non-static* class](https://github.com/blekenbleu/InterceptMouse/blob/class/Intercept.cs) insulates using applications from this `static class`.
