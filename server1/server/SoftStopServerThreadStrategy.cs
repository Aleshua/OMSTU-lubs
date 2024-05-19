// using Hwdtech;

// namespace SpaceBattle.Lib {
//     public class SoftStopServerThreadStrategy : IStrategy{
//         public object Execute(params object[] args){
//             ActionCommand action = new ActionCommand(() => new EmptyCommand().Execute());
//             string id = (string)args[0];
//             if (args.Length > 1) {
//                 action = (ActionCommand)args[1];
//             }

//             return new SoftStopServerThreadCommand(id, action);
//         }
//     }
// }