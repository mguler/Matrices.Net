namespace Matrices.Net.Abstract
{
    public interface IMatrix
    {
        int Height { get; }
        int Width { get; }
        IMatrix CreateIdentical();
        double Determinant();
        IMatrix Inverse();
        IMatrix Transpoze();
        IMatrix Normalize();
        double[][] ToArray();
        IMatrix Substract(IMatrix matrix);
        IMatrix Add(IMatrix matrix);
        IMatrix Multiply(IMatrix matrix);
    }
}