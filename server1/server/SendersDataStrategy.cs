// using System.Collections.Concurrent;
// using Hwdtech;

// namespace SpaceBattle.Lib{
//     public class SendersDataStrategy : IStrategy
//     {
//         public ConcurrentDictionary<String, SenderAdapter> sendersDomain;

//         public SendersDataStrategy() => sendersDomain = new ConcurrentDictionary<String, SenderAdapter>();

//         public object Execute(object[] args)
//         {
//             return sendersDomain;
//         }
//     }

//     public class SendersDataGetStrategy : IStrategy
//     {
//         public object Execute(params object[] args)
//         {
//             string id = (string) args[0];

//             var dict = IoC.Resolve<ConcurrentDictionary<string, SenderAdapter>>("Game.Senders.Data");
//             return dict[id];
//         }
//     }

//     public class SendersDataSetStrategy : IStrategy
//     {
//         public object Execute(params object[] args)
//         {
//             string id = (string) args[0];
//             SenderAdapter sender = (SenderAdapter) args[1];

//             return new SendersDataSetCommand(id, sender);
//         }
//     }
// }