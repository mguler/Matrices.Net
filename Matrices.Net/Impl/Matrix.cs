using Matrices.Net.Abstract;
using Matrices.Net.Impl.Determinant;
using Matrices.Net.Impl.Inversion;
using Matrices.Net.Impl.Normalization;
using Matrices.Net.Impl.Operators;
using Matrices.Net.Impl.Serialization;
using Matrices.Net.Impl.Transpoze;

namespace Matrices.Net.Impl 
{
    public class Matrix : IMatrix
    {
        private double[][] _matrix;
        private readonly IDeterminantCalculator _determinantCalculator = new DeterminantCalculatorBareissImpl();
        private readonly IMatrixInversion _matrixInversion = new MatrixInversionBareissImpl();
        private readonly IMatrixTranspoze _matrixTranspoze = new MatrixTranspozeDefaultImpl();
        private readonly IMatrixNormalization _matrixNormalize = new MatrixNormalizationDefaultImpl();
        private readonly IMatrixSerializer _matrixSerializer = new MatrixSerializerDefaultImpl();
        private readonly IMatrixFactory _matrixFactory = new MatrixFactoryDefaultImpl();
        private readonly IMatrixOperator _matrixSumOperator = new MatrixSumOperator();
        private readonly IMatrixOperator _matrixSubtractOperator = new MatrixSubtractOperator();
        private readonly IMatrixOperator _matrixMultiplyOperator = new MatrixMultiplyOperator();

        public int Height => this._matrix.Length;
        public int Width => this._matrix.Length;

        public Matrix(double[][] array) 
        {
            this._matrix = array;
        }

        public IMatrix Inverse() 
        {
            var inverted = this._matrixInversion.Inverse(this);
            return inverted;
        }

        public IMatrix Transpoze() 
        {
            var transpozed = this._matrixTranspoze.Transpoze(this);
            return transpozed;
        }
        public IMatrix Normalize() 
        {
            var normalized = this._matrixNormalize.Normalize(this);
            return normalized;
        }
        public double Determinant()
        {
            var determinant = this._determinantCalculator.Calculate(this);
            return determinant;
        }
        public IMatrix CreateIdentical() 
        {
            var identical = this._matrixFactory.CreateIdentical(this._matrix.Length);
            return identical;
        }
        public double[][] ToArray()
        {
            return this._matrix;
        }
        public IMatrix Substract(IMatrix matrix)
        {
            var result = this._matrixSubtractOperator.Operate(this, matrix);
            return result;
        }
        public IMatrix Add(IMatrix matrix) 
        {
            var result = this._matrixSumOperator.Operate(this, matrix);
            return result;
        }
        public IMatrix Multiply(IMatrix matrix)
        {
            var result = this._matrixMultiplyOperator.Operate(this, matrix);
            return result;
        }

        public override string ToString()
        {
            var serialized = this._matrixSerializer.Serialize(this);
            return serialized;

        }
    }
}