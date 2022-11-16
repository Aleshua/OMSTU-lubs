using Xunit;
using Moq;

namespace SpaceBattle.Lib.Test {
    public class MovementTest {
        [Fact]
        public void MoveTestPositive()
        {
            var movable = new Mock<IMovable>();
            movable.SetupProperty(m => m.Position, new Vector(12, 5));
            movable.SetupGet(m => m.Velocity).Returns(new Vector(-7, 3));

            var moveCommand = new MoveCommand(movable.Object);

            moveCommand.Execute();

            Assert.Equal(new Vector(5, 8), movable.Object.Position);
        }
        [Fact]
        public void UnreadablePositionTest() {
            var movable = new Mock<IMovable>();
            movable.SetupGet(m => m.Position).Throws<Exception>();
            movable.SetupGet(m => m.Velocity).Returns(new Vector(-7, 3));

            var move_command = new MoveCommand(movable.Object);
            Assert.Throws<Exception>(() => move_command.Execute());
        }
        [Fact]
        public void UnreadableVelocityTest() {
            var movable = new Mock<IMovable>();
            movable.SetupGet(m => m.Velocity).Returns(new Vector(12, 5));
            movable.SetupGet(m => m.Velocity).Throws<Exception>();

            var move_command = new MoveCommand(movable.Object);
            Assert.Throws<Exception>(() => move_command.Execute());
        }
        [Fact]
        public void ImmutablePositionTest() {
            var movable = new Mock<IMovable>();
            movable.SetupProperty(m => m.Position, new Vector(12, 5));
            movable.SetupSet(m => m.Position = It.IsAny<Vector>()).Throws<Exception>();
            movable.SetupGet<Vector>(m => m.Velocity).Returns(new Vector(-7, 3));

            var move_command = new MoveCommand(movable.Object);
            Assert.Throws<Exception>(() => move_command.Execute());
        }
        
    }
}
