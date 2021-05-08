using Matrices.Net.Abstract;

namespace Matrices.Net.Impl.Normalization {


    public class MatrixNormalizationDefaultImpl : IMatrixNormalization {

    public IMatrix Normalize(IMatrix matrix)
        {
            var m = matrix.ToArray();
            var max = 0.0;

            for (var i = 0; i < m.Length; i++) {
                var rt = 0.0;
                for (var j = 0; j < m.Length; j++) {
                    rt += m[i][j];
                }
                if (rt > max) {
                    max = rt;
                }
            }

            for (var j = 0; j < m.Length; j++) {
                var ct = 0.0;
                for (var i = 0; i < m.Length; i++) {
                    ct += m[i][j];
                }
                if (ct > max) {
                    max = ct;
                }
            }


            for (var i = 0; i < m.Length; i++) {
                var rt = 0;
                for (var j = 0; j < m.Length; j++) {
                    m[i][j] = m[i][j] / max;
                }
            }

            return new Matrix(m);

        }
    }
}