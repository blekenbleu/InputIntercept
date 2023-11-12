### Forked from [MP3Martin/InputInterceptor-PersonalFork](https://github.com/MP3Martin/InputInterceptor-PersonalFork),  
which added bool returns to [0x2E757](https://github.com/0x2E757) @ https://github.com/0x2E757/InputInterceptor/  
C# wrapper for Francisco Lopes' mouse and keyboard [Interception API](https://www.oblita.com/interception.html)

This fork modified the [`CallbackAction` delegate](blob/master/InputInterceptor/Classes/Hook.cs#L13)
 to pass also numeric [`device`](blob/master/InputInterceptor/Classes/Hook.cs#L64),  
enabling callbacks to selectively divert devices.

