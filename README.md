### Forked from [MP3Martin/InputInterceptor-PersonalFork](https://github.com/MP3Martin/InputInterceptor-PersonalFork),  
- which added bool returns to  
	- [@0x2E757's InputInterceptor](https://github.com/0x2E757/InputInterceptor/), a C# wrapper for   
		- Francisco Lopes' mouse and keyboard [Interception API](https://www.oblita.com/interception.html)

#### This fork
- modified the [`CallbackAction` delegate](blob/master/InputInterceptor/Classes/Hook.cs#L13)
 to also pass numeric [`device`](blob/master/InputInterceptor/Classes/Hook.cs#L68),  
 enabling callbacks to selectively diverted devices.
- changed Initialize() to detect null bytes from missing/defective `interception_x*.dll`,  
  returning false, instead of crashing

#### This branch:&nbsp; `stripped`
- removes `install-interception.exe` and other stuff not needed for SimHub plugin
- requires [@oblitum's `Interception.zip`](https://github.com/oblitum/Interception/releases/latest) package to install or remove that driver
- removed redundant callback `context` argument

#### Note!
- A [WPF XAML](https://github.com/blekenbleu/WPF_XAML) app directly accessing this
 [`static class`](https://github.com/blekenbleu/InputIntercept/blob/stripped/InputInterceptor/InputInterceptor.cs#L17)
 [**crashes**](https://github.com/blekenbleu/InputIntercept/blob/3193937a7edbd6268ef19ec5ab6afa3079a4ac36/InputInterceptor/InputInterceptor.cs#L24)  
	- until delayed after [`InputInterceptor.Initialize()`](https://github.com/blekenbleu/InputIntercept/blob/3193937a7edbd6268ef19ec5ab6afa3079a4ac36/InputInterceptor/InputInterceptor.cs#L45)
	- That crash <i>did not</i> occur in a [console app](https://github.com/blekenbleu/InterceptMouse), go figure.
- [This *non-static* class](https://github.com/blekenbleu/InterceptMouse/blob/class/Intercept.cs) insulates using applications from crashing before `InputInterceptor.Initialize();`

### How-To
- `SetFilter(context, predicate, filter)`  
	- `context`, returned by `CreateContext()`, is information for known keyboards and/or mice;  
		attaching or releasing any will not be detected without re-running `CreateContext()`.  
	- `predicate` is a device filtering routine, taking `device` as an argument  
		and returning true if that device is interesting.  
		For example:&nbsp; `return (12 == device);` // second mouse  
		- Sadly, predicates must be C routines, not C# methods;  
			only `interception_is_mouse` and `interception_is_keyboard` are provided.  
			Predicating to a single device must be done in the callback.
	- `filter` is a keyboard or mouse event bitmask;&nbsp; see `Enums.cs`  
		For all events from a selected mouse, use `MouseFilter.All`.
