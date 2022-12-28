using Hwdtech;
using Hwdtech.Ioc;

namespace SpaceBattle.Lib;

public class StartMoveCommand : ICommand{
    private IMoveCommandStartable startCommand;

    public StartMoveCommand(IMoveCommandStartable _startCommand){
        this.startCommand = _startCommand;
    }
    
    public void Execute(){
        IoC.Resolve<ICommand>("Object.SetProperty", startCommand.uObject, "velocity", startCommand.velocity).Execute();
        var moveCommand = IoC.Resolve<ICommand>("Command.Move", startCommand.uObject);
        IoC.Resolve<ICommand>("Queue.Push", startCommand.queue, moveCommand).Execute();
    }
}