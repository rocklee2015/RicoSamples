<Query Kind="Expression" />

//https://blog.csdn.net/wushang923/article/details/41015063

//==================

//1、Thread.Sleep 是同步延迟。 Task.Delay异步延迟。
//
//2、Thread.Sleep 会阻塞线程，Task.Delay不会。
//
//3、Thread.Sleep不能取消，Task.Delay可以

//注：反编译Task.Delay，基本上讲它就是个包裹在任务中的定时器。