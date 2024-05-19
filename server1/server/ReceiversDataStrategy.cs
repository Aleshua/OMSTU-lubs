// using System.Collections.Concurrent;
// using Hwdtech;

// namespace SpaceBattle.Lib{
//     public class ReceiversDataStrategy : IStrategy
//     {
//         public ConcurrentDictionary<String, ReceiverAdapter> ReceiversDomain;

//         public ReceiversDataStrategy() => ReceiversDomain = new ConcurrentDictionary<String, ReceiverAdapter>();

//         public object Execute(object[] args)
//         {
//             return ReceiversDomain;
//         }
//     }

//     public class ReceiversDataGetStrategy : IStrategy
//     {
//         public object Execute(params object[] args)
//         {
//             string id = (string) args[0];

//             var dict = IoC.Resolve<ConcurrentDictionary<string, ReceiverAdapter>>("Game.Receivers.Data");
//             return dict[id];
//         }
//     }

//     public class ReceiversDataSetStrategy : IStrategy
//     {
//         public object Execute(params object[] args)
//         {
//             string id = (string) args[0];
//             ReceiverAdapter Receiver = (ReceiverAdapter) args[1];

//             return new ReceiversDataSetCommand(id, Receiver);
//         }
//     }
// }