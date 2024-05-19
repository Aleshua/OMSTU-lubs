// using System.Collections.Concurrent;
// using Hwdtech;

// namespace SpaceBattle.Lib{
//     public class ReceiversDataSetCommand : ICommand
//     {
//         private string id;
//         private ReceiverAdapter Receiver;
//         public ReceiversDataSetCommand(string id, ReceiverAdapter Receiver)
//         {   
//             this.id = id;
//             this.Receiver = Receiver;
//         }
//         public void Execute()
//         {
//             IoC.Resolve<ConcurrentDictionary<string, ReceiverAdapter>>("Game.Receivers.Data")[id] = Receiver;
//         }
//     }

//     public class ThreadsDataSetCommand : ICommand
//     {   
//         private string id;
//         private ServerThread thread;
//         public ThreadsDataSetCommand(string id, ServerThread thread)
//         {   
//             this.id = id;
//             this.thread = thread;
//         }
//         public void Execute()
//         {
//             IoC.Resolve<ConcurrentDictionary<string, ServerThread>>("Game.Threads.Data")[id] = thread;
//         }
//     }

//     public class SendersDataSetCommand : ICommand
//     {
//         private string id;
//         private SenderAdapter sender;
//         public SendersDataSetCommand(string id, SenderAdapter sender)
//         {   
//             this.id = id;
//             this.sender = sender;
//         }
//         public void Execute()
//         {
//             IoC.Resolve<ConcurrentDictionary<string, SenderAdapter>>("Game.Senders.Data")[id] = sender;
//         }
//     } 
// }