using System;

namespace SpaceBattle.Lib {
    public interface IRotatable {
        public Fraction Angle {get; set;}
        public Fraction AngleVelocity {get;}
    }
}