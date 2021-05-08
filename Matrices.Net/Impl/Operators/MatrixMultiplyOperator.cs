using Matrices.Net.Abstract;
using System.Collections.Generic;

namespace Matrices.Net.Impl.Operators
{
    public class MatrixMultiplyOperator : IMatrixOperator
    {
        ////////////////////////////////////////////////////////////////////////////////////
        //         
        //  Cij =  Aij * right
        //
        ////////////////////////////////////////////////////////////////////////////////////       
        public IMatrix Operate(IMatrix left, double right)
        {

            var lm = left.ToArray();
            var result = new List<double[]>();

            for (var i = 0; i < lm.Length; i++)
            {
                var row = new List<double>();
                for (var j = 0; j < lm.Length; j++)
                {
                    var value = lm[i][j] * right;
                    row.Add(value);
                }
                result.Add(row.ToArray());
            }
            return new Matrix(result.ToArray());

        }

        ////////////////////////////////////////////////////////////////////////////////////
        //         ___ n
        //  Cij =  \__      Aik * Bkj
        //         /__ k=1 
        ////////////////////////////////////////////////////////////////////////////////////         
        public IMatrix Operate(IMatrix left, IMatrix right)
        {
            var lm = left.ToArray();
            var rm = right.ToArray();
            var result = new List<double[]>();

            for (var i = 0; i < lm.Length; i++)
            {
                var row = new List<double>();
                for (var j = 0; j < rm[i].Length; j++)
                {
                    var value = 0.0;
                    for (var k = 0; k < lm.Length; k++)
                    {
                        value += lm[i][k] * rm[k][j];
                    }
                    row.Add(value);
                }
                result.Add(row.ToArray());
            }
            return new Matrix(result.ToArray());
        }
    }
} 