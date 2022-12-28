using Hwdtech;
using Hwdtech.Ioc;
using Moq;
using Xunit;

namespace SpaceBattle.Lib.Test {
    public class StartMoveCommandTest
    {
        public StartMoveCommandTest()
        {
            new InitScopeBasedIoCImplementationCommand().Execute();

            IoC.Resolve<Hwdtech.ICommand>("Scopes.Current.Set", IoC.Resolve<object>("Scopes.New", IoC.Resolve<object>("Scopes.Root"))).Execute();

            var mockCommand = new Mock<ICommand>();
            mockCommand.Setup(a => a.Execute());
            var regStrategy = new Mock<IStrategy>();
            regStrategy.Setup(_s => _s.Execute(It.IsAny<object[]>())).Returns(mockCommand.Object);

            IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Object.SetProperty", (object[] args) => regStrategy.Object.Execute(args)).Execute();
            IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Command.Move", (object[] args) => regStrategy.Object.Execute(args)).Execute();
            IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Queue.Push", (object[] args) => regStrategy.Object.Execute(args)).Execute();
        }

        [Fact]
        public void StartMoveCommandPos()
        {
            var moveStartable = new Mock<IMoveCommandStartable>();

            moveStartable.SetupGet(a => a.velocity).Returns(new Vector(1, 1)).Verifiable();
            moveStartable.SetupGet(a => a.uObject).Returns(new Mock<IUObject>().Object).Verifiable();
            moveStartable.SetupGet(a => a.queue).Returns(new Mock<Queue<ICommand>>().Object).Verifiable();
            ICommand startMoveCommand = new StartMoveCommand(moveStartable.Object);
            startMoveCommand.Execute();
            moveStartable.Verify();
        }

        [Fact]
        public void StartMoveCommandUnreadableVelocity()
        {
            var moveStartable = new Mock<IMoveCommandStartable>();

            moveStartable.SetupGet(a => a.velocity).Throws(new Exception()).Verifiable();
            moveStartable.SetupGet(a => a.uObject).Returns(new Mock<IUObject>().Object).Verifiable();
            moveStartable.SetupGet(a => a.queue).Returns(new Mock<Queue<ICommand>>().Object).Verifiable();
            ICommand startMoveCommand = new StartMoveCommand(moveStartable.Object);
            Assert.Throws<Exception>(() => startMoveCommand.Execute());
        }
        [Fact]
        public void StartMoveCommandUnreadableObject()
        {
            var moveStartable = new Mock<IMoveCommandStartable>();

            moveStartable.SetupGet(a => a.velocity).Returns(new Vector(1, 1)).Verifiable();
            moveStartable.SetupGet(a => a.uObject).Throws(new Exception()).Verifiable();
            moveStartable.SetupGet(a => a.queue).Returns(new Mock<Queue<ICommand>>().Object).Verifiable();
            ICommand startMoveCommand = new StartMoveCommand(moveStartable.Object);
            Assert.Throws<Exception>(() => startMoveCommand.Execute());
        }

        [Fact]
        public void StartMoveCommandUnreadableQueue()
        {
            var moveStartable = new Mock<IMoveCommandStartable>();

            moveStartable.SetupGet(a => a.velocity).Returns(new Vector(1, 1)).Verifiable();
            moveStartable.SetupGet(a => a.uObject).Returns(new Mock<IUObject>().Object).Verifiable();
            moveStartable.SetupGet(a => a.queue).Throws(new Exception()).Verifiable();
            ICommand startMoveCommand = new StartMoveCommand(moveStartable.Object);
            Assert.Throws<Exception>(() => startMoveCommand.Execute());
        }
    }
}
