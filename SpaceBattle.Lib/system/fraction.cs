using System;

namespace SpaceBattle.Lib {

    public class Fraction {
        int numerator { get; set; }
        int denominator { get; set; }

        public Fraction(int n, int d = 1){
            int gcd = GCD(n, d);
                numerator = n / gcd;
                denominator = d / gcd;
        }

        private int GCD(int x, int y){
            while (x != y)
            {
                if (x >= y)
                    x = x - y;
                else
                    y = y - x;
            }
            return x;
        }


        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            return new Fraction(f1.numerator * f2.denominator + f2.numerator * f1.denominator,
            f1.denominator * f2.denominator);
        }

        public override int GetHashCode(){
            return HashCode.Combine(numerator, denominator);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Fraction))
            {
                return false;
            }

            var item = (Fraction)obj;
            return item != null && item.numerator == this.numerator && item.denominator == this.denominator;
        }
    }
}