using System.Collections.Concurrent;
using System.Net;
using Hwdtech;
using Hwdtech.Ioc;
using Moq;
using SpaceBattle.Http;

namespace SpaceBattle.Lib.Test;

public class EndpointTests
{
    public EndpointTests()
    {
        new InitScopeBasedIoCImplementationCommand().Execute();
        IoC.Resolve<Hwdtech.ICommand>("Scopes.Current.Set", IoC.Resolve<object>("Scopes.New", IoC.Resolve<object>("Scopes.Root"))).Execute();

        var sds = new SendersDataStrategy();
        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Game.Senders.Data", (object[] args) => sds.Execute(args)).Execute();

        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Game.Senders.Data.Set", (object[] args) => new SendersDataSetStrategy().Execute(args)).Execute();
        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Game.Senders.Data.Get", (object[] args) => new SendersDataGetStrategy().Execute(args)).Execute();

        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Game.Senders.Send", (object[] args) => new SendCommandStrategy().Execute(args)).Execute();

        var command = new Mock<SpaceBattle.Lib.ICommand>();

        var CommandStrategy = new Mock<IStrategy>();
        CommandStrategy.Setup(c => c.Execute(It.IsAny<object[]>())).Returns(command.Object);

        var ThreadIDMock = new Mock<IStrategy>();
        ThreadIDMock.Setup(c => c.Execute(It.IsAny<object[]>())).Returns("asdfg");

        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Game.Message.Processor", (object[] args) => CommandStrategy.Object.Execute()).Execute();

        IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Game.GetThreadIDByGameID", (object[] args) => ThreadIDMock.Object.Execute()).Execute();
    }

    [Fact]
    public void EndpointTest_wArgs() {
        BlockingCollection<SpaceBattle.Lib.ICommand> queue = new BlockingCollection<SpaceBattle.Lib.ICommand>();
        var sender = new SenderAdapter(queue);

        IoC.Resolve<SpaceBattle.Lib.ICommand>("Game.Senders.Data.Set", "asdfg", sender).Execute();

        var message = new Message {
            CommandName = "fire",
            GameID = "asdfg",
            args = new Dictionary<string, string> {
                { "game item id", "548" }
            }
        };

        var messageProcessor = new MessageProcessor();

        var result = messageProcessor.ProcessMessage(message);

        Assert.Equal(HttpStatusCode.OK, result);
        Assert.Single(queue);
    }

    [Fact]
    public void EndpointTest_woArgs() {
        BlockingCollection<SpaceBattle.Lib.ICommand> queue = new BlockingCollection<SpaceBattle.Lib.ICommand>();
        var sender = new SenderAdapter(queue);

        IoC.Resolve<SpaceBattle.Lib.ICommand>("Game.Senders.Data.Set", "asdfg", sender).Execute();

        var message = new Message {
            CommandName = "fire",
            GameID = "asdfg",
        };

        var messageProcessor = new MessageProcessor();

        var result = messageProcessor.ProcessMessage(message);

        Assert.Equal(HttpStatusCode.OK, result);
        Assert.Single(queue);
    }
}
