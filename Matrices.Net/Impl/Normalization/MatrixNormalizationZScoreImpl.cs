using Matrices.Net.Abstract;
using System;

namespace Matrices.Net.Impl.Normalization
{

    public class MatrixNormalizationZScoreImpl : IMatrixNormalization
    {

        public IMatrix Normalize(IMatrix matrix)
        {
            var m = matrix.ToArray();

            //j column i row 
            for (var j = 0; j < m.Length; j++)
            {
                var µ = 0.0;
                var s = 0.0;
                for (var i = 0; i < m.Length; i++)
                {
                    µ += m[i][j] / m.Length;
                }

                for (var i = 0; i < m.Length; i++)
                {
                    s += Math.Sqrt(Math.Pow(m[i][j] - µ, 2) / m.Length - 1);
                }

            }
            return new Matrix(m);
        }
    }
} 