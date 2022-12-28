using System;

using Xunit;
using Moq;

namespace SpaceBattle.Lib.Test {
    public class VectorTest {
        [Fact]
        public void ConstructorVectorTest() {
            var vector = new Vector(1, 2, 3);
            var vector2 = new Vector(1, 2, 3);

            Assert.True(vector2 == vector);
        }

        [Fact]
        public void EqualsVectorTest() {
            var vector = new Vector(1, 2, 3);
            var vector2 = new Vector(1, 2, 3);

            Assert.True(vector.Equals(vector2));
        }

        [Fact]
        public void VectorNullEqual()
        {
            var vector = new Vector(1, 2, 3);

            Assert.False(vector.Equals(null));
        }

        [Fact]
        public void GetHashCodeVectorTest() {
            var vector_hash1 = new Vector(1, 2, 3).GetHashCode();
            var vector_hash2 = new Vector(4, 5, 6).GetHashCode();

            Assert.True(vector_hash1 != vector_hash2);
        }

        [Fact]
        public void ToStringVectorTest() {
            var vector = new Vector(1, 2, 3);
            string StringVector = "Vector(1, 2, 3)";

            Assert.True(StringVector == vector.ToString());
        }

        [Fact]
        public void GetIndexVectorTest() {
            var vector = new Vector(1, 2, 3);

            Assert.True(1 == vector[0]);
        }

        [Fact]
        public void SetIndexVectorTest() {
            var vector = new Vector(1, 2, 3);

            vector[0] = 5;
            Assert.True(5 == vector[0]);
        }

        [Fact]
        public void AdditiveVectorTest1() {
            var vector1 = new Vector(1, 2, 3);
            var vector2 = new Vector(4, 5, 6);
            var vector_result = new Vector(5, 7, 9);

            Assert.True(vector1 + vector2 == vector_result);
        }

        [Fact]
        public void AdditiveVectorTest2(){
            var vector1 = new Vector(1, 2, 3);
            var vector2 = new Vector(4, 5, 6, 7);

            Assert.Throws<System.ArgumentException>(() => vector1 + vector2);
        }

        [Fact]
        public void AdditiveVectorTest3(){
            var vector1 = new Vector(1, 2, 3, 4);
            var vector2 = new Vector(5, 6, 7);

            Assert.Throws<System.ArgumentException>(() => vector1 + vector2);
        }

        [Fact]
        public void DifferenceVectorTest1() {
            var vector1 = new Vector(1, 2, 3);
            var vector2 = new Vector(4, 5, 6);
            var vector_result = new Vector(-3, -3, -3);

            Assert.True(vector1 - vector2 == vector_result);
        }

        [Fact]
        public void DifferenceVectorTest2(){
            var vector1 = new Vector(1, 2, 3);
            var vector2 = new Vector(4, 5, 6, 7);

            Assert.Throws<System.ArgumentException>(() => vector1 - vector2);
        }

        [Fact]
        public void DifferenceVectorTest3(){
            var vector1 = new Vector(1, 2, 3, 4);
            var vector2 = new Vector(5, 6, 7);

            Assert.Throws<System.ArgumentException>(() => vector1 - vector2);
        }

        [Fact]
        public void LessOperatorTest1(){
            var vector = new Vector(1, 2, 3);
            var vector2 = new Vector(1, 2, 3);

            Assert.False(vector < vector2);
        }

        [Fact]
        public void LessOperatorTest2(){
            var vector = new Vector(1, 2, 3, 4);
            var vector2 = new Vector(1, 2, 3);

            Assert.False(vector < vector2);
        }

        [Fact]
        public void LessOperatorTest3(){
            var vector = new Vector(0, 1, 2);
            var vector2 = new Vector(1, 2, 3);

            Assert.True(vector < vector2);
        }

        [Fact]
        public void LessOperatorTest4(){
            var vector = new Vector(0, 1, 2);
            var vector2 = new Vector(1, 2, 3, 4);

            Assert.True(vector < vector2);
        }

        [Fact]
        public void GreaterOperatorTest1(){
            var vector1 = new Vector(1, 2, 3);
            var vector2 = new Vector(1, 2, 3);

            Assert.False(vector1 > vector2);
        }

        [Fact]
        public void GreaterOperatorTest2(){
            var vector1 = new Vector(1, 2, 3, 4);
            var vector2 = new Vector(1, 2, 3);

            Assert.True(vector1 > vector2);
        }

        [Fact]
        public void GreaterOperatorTest3(){
            var vector1 = new Vector(1, 2, 3);
            var vector2 = new Vector(1, 2, 3, 4);

            Assert.False(vector1 > vector2);
        }

        [Fact]
        public void GreaterOperatorTest4(){
            var vector1 = new Vector(2, 3, 4);
            var vector2 = new Vector(1, 2, 3);

            Assert.True(vector1 > vector2);
        }

        [Fact]
        public void MultiplicationTest(){
            var vector = new Vector(1, 2, 3);

            Assert.True(3 * vector == new Vector(3, 6, 9));
        }

        [Fact]
        public void NotEqualTest1(){
            var vector = new Vector(1, 2, 3, 4);
            var vector2 = new Vector(1, 2, 3);

            Assert.True(vector != vector2);
        }

        [Fact]
        public void NotEqualTest2(){
            var vector = new Vector(1, 2, 3);
            var vector2 = new Vector(1, 2, 3, 4);

            Assert.True(vector != vector2);
        }

        [Fact]
        public void NotEqualTest3(){
            var vector = new Vector(1, 2, 3);
            var vector2 = new Vector(1, 2, 3);

            Assert.False(vector != vector2);
        }

        [Fact]
        public void NotEqualTest4(){
            var vector = new Vector(0, 1, 2);
            var vector2 = new Vector(1, 2, 3);

            Assert.True(vector != vector2);
        }

        [Fact]
        public void EqualTest1(){
            var vector = new Vector(1, 2, 3, 4);
            var vector2 = new Vector(1, 2, 3);

            Assert.False(vector == vector2);
        }

        [Fact]
       public void EqualTest2(){
            var vector = new Vector(1, 2, 3);
            var vector2 = new Vector(1, 2, 3, 4);

            Assert.False(vector == vector2);
        }

        [Fact]
        public void EqualTest3(){
            var vector = new Vector(1, 2, 3);
            var vector2 = new Vector(1, 2, 3);

            Assert.True(vector == vector2);
        }

        [Fact]
       public void EqualTest4(){
            var vector = new Vector(4, 2, 3);
            var vector2 = new Vector(1, 2, 3);

            Assert.False(vector == vector2);
        }
    }
}