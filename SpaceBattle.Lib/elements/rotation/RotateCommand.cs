using System;

namespace SpaceBattle.Lib {
    public class RotateCommand : ICommand {
        private readonly IRotatable rotatable_;

        public RotateCommand(IRotatable rotatable) {
            rotatable_ = rotatable;
        }

        public void Execute() {
            rotatable_.Angle = rotatable_.Angle + rotatable_.AngleVelocity;
        }
    }
}