// using Hwdtech;

// namespace SpaceBattle.Lib {
//     public class HardStopServerThreadCommand : ICommand{
//         string id;
//         ActionCommand action_after_stop;

//         public HardStopServerThreadCommand(string _id, ActionCommand action){
//             id = _id;
//             action_after_stop = action;
//         }

//         public void Execute(){
//             ServerThread serverThread = IoC.Resolve<ServerThread>("Game.Threads.Data.Get", id);
//             if (serverThread.GetHashCode() == Thread.CurrentThread.GetHashCode()) {
//                 serverThread.Stop();
//                 action_after_stop.Execute();
//             } else{
//                 throw new Exception();
//             }
//         }
//     }
// }