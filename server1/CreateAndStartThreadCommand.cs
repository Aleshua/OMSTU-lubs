// using Hwdtech;

// namespace SpaceBattle.Lib {
//     public class CreateAndStartThreadCommand : ICommand{
//         private string id;
//         private ReceiverAdapter receiver;
//         private SenderAdapter sender;
//         private ServerThread serverThread;

//         public CreateAndStartThreadCommand(string id, ReceiverAdapter receiver, SenderAdapter sender, ServerThread thread){
//             this.id = id;
//             this.receiver = receiver;
//             this.sender = sender;
//             this.serverThread = thread;
//         }

//         public void Execute(){
//             IoC.Resolve<ICommand>("Game.Receivers.Data.Set", id, receiver).Execute();
//             IoC.Resolve<ICommand>("Game.Senders.Data.Set", id, sender).Execute();
//             IoC.Resolve<ICommand>("Game.Threads.Data.Set", id, serverThread).Execute();

//             IoC.Resolve<ServerThread>("Game.Threads.Data.Get", id).Start();
//         }
//     }
// }