using Matrices.Net.Abstract;
using System;
using System.Collections.Generic;

namespace Matrices.Net.Impl.Operators 
{
    public class MatrixSubtractOperator : IMatrixOperator
    {

        public IMatrix Operate(IMatrix left, double right) => throw new NotImplementedException();
        ////////////////////////////////////////////////////////////////////////////////////
        //         
        //  Cij =  Aij + Bij
        //
        ////////////////////////////////////////////////////////////////////////////////////    
        public IMatrix Operate(IMatrix left, IMatrix right) {
            var lm = left.ToArray();
            var rm = right.ToArray();
            var result = new List<double[]>();

            for (var i = 0; i < lm.Length; i++) {
                var row = new List<double>();
                for (var j = 0; j < lm.Length; j++) {
                    var value = lm[i][j] - rm[i][j];
                    row.Add(value);
                }
                result.Add(row.ToArray());
            }
            return new Matrix(result.ToArray());
        }
    } 
}