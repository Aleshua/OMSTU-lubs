// using System.Collections.Concurrent;

// namespace SpaceBattle.Lib {
//     public class CreateAndStartThreadStrategy : IStrategy{
//         public object Execute(params object[] args){
//             BlockingCollection<ICommand> queue = new BlockingCollection<ICommand>();

//             ActionCommand action = new ActionCommand(() => new EmptyCommand().Execute());

//             if (args.Length > 1) {
//                 action = (ActionCommand) args[1];
//             }

//             queue.Add(action);

//             ReceiverAdapter reciever = new ReceiverAdapter(queue);
//             SenderAdapter sender = new SenderAdapter(queue);
//             ServerThread serverThread = new ServerThread(reciever);

//             string id = (string)args[0];

//             return new CreateAndStartThreadCommand(id, reciever, sender, serverThread);
//         }
//     }
// }