using Matrices.Net.Abstract;
using System;
using System.Collections.Generic;

namespace Matrices.Net.Impl.Inversion
{

    public class MatrixInversionBareissImpl : IMatrixInversion
    {

        public IMatrix Inverse(IMatrix matrix)
        {

            var m = matrix.ToArray();
            var i = matrix.CreateIdentical().ToArray();

            var next = new List<double[]>();
            var nexti = new List<double[]>();
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

                Console.WriteLine(new Matrix(m).ToString());
                Console.WriteLine(pivot);

                for (var y2 = 0; y2 < m.Length; y2++)
                {

                    if (y2 == y)
                    {
                        next.Add(m[y2]);
                        nexti.Add(i[y2]);
                        continue;
                    }
                    var row = new List<double>();
                    var rowi = new List<double>();

                    for (var x2 = 0; x2 < m.Length; x2++)
                    {

                        pivot = m[y][x];
                        var currentValue = m[y2][x2];
                        var rowValue = m[y2][x];
                        var colValue = m[y][x2];

                        var currentValuei = i[y2][x2];
                        var colValuei = i[y][x2];

                        var result = (pivot * currentValue - rowValue * colValue) / previousPivot;
                        var resulti = (pivot * currentValuei - rowValue * colValuei) / previousPivot;

                        row.Add(result);
                        rowi.Add(resulti);
                    }
                    next.Add(row.ToArray());
                    nexti.Add(rowi.ToArray());
                }
                m = next.ToArray();
                i = nexti.ToArray();
                next = new List<double[]>();
                nexti = new List<double[]>();
            }
            Console.WriteLine(new Matrix(m).ToString());
            Console.WriteLine(new Matrix(i).ToString());

            var determinant = m[m.Length - 1][m.Length - 1];
            if (determinant == 0)
            {
                throw new Exception("Cannot inverse the matrix when determinant is equals to zero");
            }
            return new Matrix(i);
        }
    }
}