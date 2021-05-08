using Matrices.Net.Abstract;
using System.Collections.Generic;

namespace Matrices.Net.Impl.Determinant
{

    public class MatrixFactoryDefaultImpl : IMatrixFactory
    {
        public IMatrix CreateIdentical(int size)
        {
            var identicalMatrix = new List<double[]>();
            for (var y = 0; y < size; y++)
            {
                var row = new List<double>();
                for (var x = 0; x < size; x++)
                {
                    if (x == y)
                    {
                        row.Add(1);
                    }
                    else
                    {
                        row.Add(0);
                    }
                }
                identicalMatrix.Add(row.ToArray());
            }
            return new Matrix(identicalMatrix.ToArray());
        }
    }
}