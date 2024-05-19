// using Hwdtech;

// namespace SpaceBattle.Lib {
//     public class ServerThread {
//         Thread thread;
//         IReceiver queue;
//         bool stop = false;
//         Action behaviour;

//         public void Stop() => stop = true;

//         public void Start() => thread.Start();

//         internal void HandleCommand()
//         {
//             var cmd = queue.Receive();
//             try{cmd.Execute();}
//             catch(Exception e){
//                 IoC.Resolve<IStrategy>("Game.Exception.FindExceptionHandlerForCmd").Execute(cmd, e);
//             }
//         }
//         public ServerThread(IReceiver queue)
//         {
//             this.queue = queue;
//             behaviour = () =>
//             {
//                 HandleCommand();
//             };

//             thread = new Thread(() =>
//             {
//                 while (!stop)
//                     behaviour();
//             });
//         }

//         internal void UpdateBehaviour(Action newBehaviour)
//         {
//             behaviour = newBehaviour;

//         }
//         public void Execute()
//         {
//             thread.Start();
//         }

//         public int GetThreadHash()
//         {
//             return thread.GetHashCode();
//         }

//         public bool IsEmpty(){
//             return queue.IsEmpty();
//         }

        
//     }
// }