using System;
using Xunit;
using Moq;

namespace SpaceBattle.Lib.Test {
    public class RotatementTest{
        [Fact]
        public void ChangeAngleTest() {
            var rotatable = new Mock<IRotatable>();
            rotatable.SetupProperty(m => m.Angle, 45);
            rotatable.SetupGet(m => m.AngleVelocity).Returns(90);

            var rotatecommand = new RotateCommand(rotatable.Object);

            rotatecommand.Execute();

            Assert.Equal(135, rotatable.Object.Angle);
        }

        [Fact]
        public void UnreadableAngleTest() {
            var rotatable = new Mock<IRotatable>();
            rotatable.SetupGet(m => m.Angle).Throws<Exception>();
            rotatable.SetupGet(m => m.AngleVelocity).Returns(90);

            var move_command = new RotateCommand(rotatable.Object);
            Assert.Throws<Exception>(() => move_command.Execute());
        }

        [Fact]
        public void UnreadableAngleVelocityTest() {
            var rotatable = new Mock<IRotatable>();
            rotatable.SetupGet(m => m.Angle).Returns(45);
            rotatable.SetupGet(m => m.AngleVelocity).Throws<Exception>();

            var move_command = new RotateCommand(rotatable.Object);
            Assert.Throws<Exception>(() => move_command.Execute());
        }

        [Fact]
        public void ImmutableAngleTest(){
            var rotatable = new Mock<IRotatable>();
            rotatable.SetupProperty(m => m.Angle, 45);
            rotatable.SetupGet(m => m.AngleVelocity).Returns(90);
            rotatable.SetupSet(m => m.Angle = It.IsAny<int>()).Throws<Exception>();   
            
            RotateCommand command = new RotateCommand(rotatable.Object);
            Assert.Throws<Exception>(() => command.Execute());
        }
    }
}