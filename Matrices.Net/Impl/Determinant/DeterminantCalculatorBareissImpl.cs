using System;
using System.Collections.Generic;
using Matrices.Net.Abstract;

namespace Matrices.Net.Impl.Determinant
{
    public class DeterminantCalculatorBareissImpl : IDeterminantCalculator 
    {

        public double Calculate(IMatrix matrix)
        {
            var m = matrix.ToArray();
            var next = new List<double[]>();
            var y = 0;
            var x = 0;
            var pivot = 0.0;

            for (y = 0, x = 0; y < m.Length; x++, y++)
            {
                var previousPivot = pivot;
                if (y == 0)
                {
                    previousPivot = 1;
                }
                else
                {
                    previousPivot = pivot;
                }

                Console.WriteLine(m);
                Console.WriteLine(pivot);

                for (var y2 = 0; y2 < m.Length; y2++)
                {

                    if (y2 == y)
                    {
                        next.Add(m[y2]);
                        continue;
                    }
                    var row = new List<double>();

                    for (var x2 = 0; x2 < m.Length; x2++)
                    {

                        pivot = m[y][x];
                        var currentValue = m[y2][x2];
                        var rowValue = m[y2][x];
                        var colValue = m[y][x2];

                        var result = (pivot * currentValue - rowValue * colValue) / previousPivot;
                        row.Add(result);
                    }
                    next.Add(row.ToArray());
                }
                m = next.ToArray();
                next = new List<double[]>();
            }
            Console.WriteLine(m);
            return m[m.Length - 1][m.Length - 1];
        }


    } 
}