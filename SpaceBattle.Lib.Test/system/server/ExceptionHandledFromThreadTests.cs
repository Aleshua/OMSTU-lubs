using Hwdtech;
using Hwdtech.Ioc;
using Moq;

namespace SpaceBattle.Lib.Test{
    public class ExceptionHandledFromThreadTests
    {
        object scope;
        public ExceptionHandledFromThreadTests() {
            new InitScopeBasedIoCImplementationCommand().Execute(); 

            scope = IoC.Resolve<object>("Scopes.New", IoC.Resolve<object>("Scopes.Root"));
            IoC.Resolve<Hwdtech.ICommand>("Scopes.Current.Set", scope).Execute();

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
        }

        [Fact]
        public void ExceptionHandledFromThreadTest()
        {
            AutoResetEvent waitHandler = new AutoResetEvent(false);
            ActionCommand waitHandlerSet = new ActionCommand(() => {
                waitHandler.Set();
            });

            IoC.Resolve<ICommand>("Game.Threads.CreateAndStart", "1").Execute();

            IoC.Resolve<ICommand>("Game.Senders.Send", "1", waitHandlerSet).Execute();

            IoC.Resolve<ICommand>("Game.Senders.Send", "1", new ActionCommand(() => {
                IoC.Resolve<Hwdtech.ICommand>("Scopes.Current.Set", scope).Execute();
            })).Execute();

            IoC.Resolve<ICommand>("Game.Senders.Send", "1", new ActionCommand(() => {
                throw new Exception();
            })).Execute();

            IoC.Resolve<ICommand>("Game.Senders.Send", "1", IoC.Resolve<ICommand>("Game.Threads.HardStop", "1")).Execute();

            IoC.Resolve<ICommand>("Game.Senders.Send", "1", new ActionCommand(() => {
                throw new Exception();
            })).Execute();

            waitHandler.WaitOne();

            Assert.False(IoC.Resolve<IReceiver>("Game.Receivers.Data.Get", "1").IsEmpty());
        }

        [Fact]
        public void ExceptionHandledFromThreadActionTest()
        {
            AutoResetEvent waitHandler = new AutoResetEvent(false);
            ActionCommand waitHandlerSet = new ActionCommand(() => {
                waitHandler.Set();
            });

            IoC.Resolve<ICommand>("Game.Threads.CreateAndStart", "1").Execute();

            IoC.Resolve<ICommand>("Game.Senders.Send", "1", waitHandlerSet).Execute();

            IoC.Resolve<ICommand>("Game.Senders.Send", "1", new ActionCommand(() => {
                IoC.Resolve<Hwdtech.ICommand>("Scopes.Current.Set", scope).Execute();
            })).Execute();

            IoC.Resolve<ICommand>("Game.Senders.Send", "1", new EmptyCommand()).Execute();

            IoC.Resolve<ICommand>("Game.Senders.Send", "1", IoC.Resolve<ICommand>("Game.Threads.HardStop", "1", new ActionCommand(() => {
                throw new Exception();
            }))).Execute();

            IoC.Resolve<ICommand>("Game.Senders.Send", "1", new EmptyCommand()).Execute();

            waitHandler.WaitOne();

            Assert.False(IoC.Resolve<IReceiver>("Game.Receivers.Data.Get", "1").IsEmpty());
        }
 
    }
}