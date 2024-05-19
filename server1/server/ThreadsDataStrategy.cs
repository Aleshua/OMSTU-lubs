// using System.Collections.Concurrent;
// using Hwdtech;

// namespace SpaceBattle.Lib{
//     public class ThreadsDataStrategy : IStrategy
//     {
//         public ConcurrentDictionary<String, ServerThread> ThreadsDomain;

//         public ThreadsDataStrategy() => ThreadsDomain = new ConcurrentDictionary<String, ServerThread>();

//         public object Execute(object[] args)
//         {
//         return ThreadsDomain;
//         }
//     }

//     public class ThreadsDataGetStrategy : IStrategy
//     {
//         public object Execute(params object[] args)
//         {
//             string id = (string) args[0];

//             return IoC.Resolve<ConcurrentDictionary<string, ServerThread>>("Game.Threads.Data")[id];
//         }
//     }

//     public class ThreadsDataSetStrategy : IStrategy
//     {
//         public object Execute(params object[] args)
//         {
//             string id = (string) args[0];
//             ServerThread thread = (ServerThread) args[1];

//             return new ThreadsDataSetCommand(id, thread);
//         }
//     }
// }