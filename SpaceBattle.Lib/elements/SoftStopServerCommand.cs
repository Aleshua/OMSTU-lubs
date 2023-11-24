using Hwdtech;

namespace SpaceBattle.Lib {
    public class SoftStopServerThreadCommand : ICommand{
        string id;
        ActionCommand action_after_stop;

        public SoftStopServerThreadCommand(string _id, ActionCommand action){
            id = _id;
            action_after_stop = action;
        }

        public void Execute(){
            ServerThread serverThread = IoC.Resolve<ServerThread>("Game.Threads.Domain.Get", id);
            
            if (serverThread.GetHashCode() == Thread.CurrentThread.GetHashCode()) {
                serverThread.UpdateBehaviour(() => {
                    if (serverThread.IsEmpty()) {
                        serverThread.Stop();
                        action_after_stop.Execute();
                    }
                    else {
                        serverThread.HandleCommand();
                    }
                });
            } else{
                throw new Exception();
            }
        }
    }
}