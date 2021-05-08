using Matrices.Net.Abstract;
using System;

namespace Matrices.Net.Impl.Determinant
{
    public class DeterminantCalculatorSarrusImpl : IDeterminantCalculator
    {

        public double Calculate(IMatrix matrix)
        {
            if (matrix.Height != 3 || matrix.Width != 3)
            {
                throw new Exception("Matrix dimensions must be 3x3");
            }

            var result = 0.0;
            var m = matrix.ToArray();
            for (var x = 0; x < 2; x++)
            {
                var total = 1.0;
                var reverseTotal = 1.0;
                var y = 0;
                var x2 = x;
                for (y = 0, x2 = x; y < 3; x2++, y++)
                {
                    total *= m[y][x2 % 3];
                    reverseTotal *= m[y][2 - (x2 % 3)];
                }
                result += total - reverseTotal;
            }
            return result;
        }
    }
}