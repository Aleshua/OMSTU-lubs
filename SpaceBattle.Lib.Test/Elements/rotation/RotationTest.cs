using System;
using Xunit;
using Moq;

namespace SpaceBattle.Lib.Test {
    public class RotatementTest{
        [Fact]
        public void ChangeAngleTest() {
            var rotatable = new Mock<IRotatable>();
            rotatable.SetupProperty(m => m.Angle, new Fraction(45));
            rotatable.SetupGet(m => m.AngleVelocity).Returns(new Fraction(90));

            var rotatecommand = new RotateCommand(rotatable.Object);

            rotatecommand.Execute();

            Assert.Equal(new Fraction(135), rotatable.Object.Angle);
        }

        [Fact]
        public void UnreadableAngleTest() {
            var rotatable = new Mock<IRotatable>();
            rotatable.SetupGet(m => m.Angle).Throws<Exception>();
            rotatable.SetupGet(m => m.AngleVelocity).Returns(new Fraction(90));

            var move_command = new RotateCommand(rotatable.Object);
            Assert.Throws<Exception>(() => move_command.Execute());
        }

        [Fact]
        public void UnreadableAngleVelocityTest() {
            var rotatable = new Mock<IRotatable>();
            rotatable.SetupGet(m => m.Angle).Returns(new Fraction(45));
            rotatable.SetupGet(m => m.AngleVelocity).Throws<Exception>();

            var move_command = new RotateCommand(rotatable.Object);
            Assert.Throws<Exception>(() => move_command.Execute());
        }

        [Fact]
        public void ImmutableAngleTest(){
            var rotatable = new Mock<IRotatable>();
            rotatable.SetupProperty(m => m.Angle, new Fraction(45));
            rotatable.SetupGet(m => m.AngleVelocity).Returns(new Fraction(90));
            rotatable.SetupSet(m => m.Angle = It.IsAny<Fraction>())
                     .Callback<Fraction>(angle => throw new Exception());   
            
            RotateCommand command = new RotateCommand(rotatable.Object);
            Assert.Throws<Exception>(() => command.Execute());
        }
    }
}