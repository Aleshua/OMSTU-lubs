using System;

namespace SpaceBattle.Lib {

    public class Fraction {
        int numerator { get; set; }
        int denominator { get; set; }

        public Fraction(int n, int d = 1){
            int gcd = GCD(n, d);
            if ((double)n / d > 360){
                n /= gcd;
                d /= gcd;
                numerator = n % (360 * d);
                denominator = d;
            } else {
                numerator = n / gcd;
                denominator = d / gcd;
            }
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
            var item = obj as Fraction;

            if (item is null){
                return false;
            }
            return item.numerator == numerator && item.denominator == denominator;
        }
    }
}