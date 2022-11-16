using System;

namespace SpaceBattle.Lib {
    public class MoveCommand : ICommand {
        private IMovable imovable_;

        public MoveCommand(IMovable imovable) {
            imovable_ = imovable;
        }

        public void Execute() {
            imovable_.Position = imovable_.Position + imovable_.Velocity;
        }
    }
}