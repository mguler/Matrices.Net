using Matrices.Net.Abstract;
using System.Collections.Generic;

namespace Matrices.Net.Impl.Transpoze 
{
    public class MatrixTranspozeDefaultImpl : IMatrixTranspoze
    {
        public IMatrix Transpoze(IMatrix matrix)
        {
            var result = new List<double[]>();
            var m = matrix.ToArray();

            for (var x = 0; x < m.Length; x++) {
                var row = new List<double>();
                for (var y = 0; y < m.Length; y++) {
                    var currentValue = m[y][x];
                    row.Add(currentValue);
                }
                result.Add(row.ToArray());
            }
            return new Matrix(result.ToArray());
        }
    }
}