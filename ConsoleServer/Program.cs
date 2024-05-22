using SpaceBattle.Lib;
using SpaceBattle.Lib.Test;
using Hwdtech;
using Hwdtech.Ioc;
class Program
{
    static void Main(string[] args)
    {
        new Hwdtech.Ioc.InitScopeBasedIoCImplementationCommand().Execute();

        var tds = new ThreadsDataStrategy();
        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Game.Threads.Data", (object[] args) => tds.Execute(args)).Execute();

        var rds = new ReceiversDataStrategy();
        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Game.Receivers.Data", (object[] args) => rds.Execute(args)).Execute();

        var sds = new SendersDataStrategy();
        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Game.Senders.Data", (object[] args) => sds.Execute(args)).Execute();

        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Game.Threads.Data.Set", (object[] args) => new ThreadsDataSetStrategy().Execute(args)).Execute();
        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Game.Threads.Data.Get", (object[] args) => new ThreadsDataGetStrategy().Execute(args)).Execute();

        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Game.Receivers.Data.Set", (object[] args) => new ReceiversDataSetStrategy().Execute(args)).Execute();
        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Game.Receivers.Data.Get", (object[] args) => new ReceiversDataGetStrategy().Execute(args)).Execute();

        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Game.Senders.Data.Set", (object[] args) => new SendersDataSetStrategy().Execute(args)).Execute();
        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Game.Senders.Data.Get", (object[] args) => new SendersDataGetStrategy().Execute(args)).Execute();

        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Game.Senders.Send", (object[] args) => new SendCommandStrategy().Execute(args)).Execute();

        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Game.Threads.CreateAndStart", (object[] args) => new CreateAndStartThreadStrategy().Execute(args)).Execute();

        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Game.Threads.HardStop", (object[] args) => new HardStopServerThreadStrategy().Execute(args)).Execute();

        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Game.Threads.SoftStop", (object[] args) => new SoftStopServerThreadStrategy().Execute(args)).Execute();

        var Strategy = new Mock<IStrategy>();
        Strategy.Setup(c => c.Execute());

        var StrategyStrategy = new Mock<IStrategy>();
        StrategyStrategy.Setup(s => s.Execute(It.IsAny<object[]>())).Returns(Strategy.Object);

        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Game.Exception.FindExceptionHandlerForCmd", (object[] args) => StrategyStrategy.Object.Execute(args)).Execute();

        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "StartServerCommand", (object[] args) => new ActionCommand(() => {
            new StartServerCommand((int) args[0]).Execute();
        })).Execute();
        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "StopServerCommand", (object[] args) => new ActionCommand(() => {
            new StopServerCommand((int) args[0]).Execute();
        })).Execute();
        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "CatchException", (object[] args) => new ActionCommand(() => {
            new HandlerCommand((string) args[0]).Execute();
        })).Execute();

        if (args[0] == "--thread")
        {
            Console.WriteLine("Starting . . .");
            int n_threads = int.Parse(args[1]);
            var server = new ConsoleServer(n_threads);
            server.Execute();
        }
        else
        {
            Console.WriteLine("No '--thread' argument specified.");
        }
    }
}
