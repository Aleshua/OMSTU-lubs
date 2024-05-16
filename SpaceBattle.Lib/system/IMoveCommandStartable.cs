using System;

namespace SpaceBattle.Lib {
    public interface IMoveCommandStartable
    {
        IUObject uObject { get; }
        Vector velocity { get; }
        Queue<ICommand> queue { get; }
    }
}
