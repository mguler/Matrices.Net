namespace Matrices.Net.Abstract
{
    public interface IMatrixOperator
    {
        IMatrix Operate(IMatrix left, double right);
        IMatrix Operate(IMatrix left, IMatrix right);
    }
}