using System;
using Matrices.Net.Impl;

namespace Matrices.Net.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new double[][]{
                new double[]{ 5,3,2,2,3},
                new double[]{ 2,0,2,2,0},
                new double[]{ 0,2,5,1,1},
                new double[]{ 6,8,8,3,2},
                new double[]{ 1,4,1,4,3},
            };

            var matrix = new Matrix(array);
            System.Console.WriteLine("Matrix ;");
            System.Console.WriteLine(matrix);

            var identical = matrix.CreateIdentical();
            System.Console.WriteLine("Identical ;");
            System.Console.WriteLine(identical);

            var transposed = matrix.Transpoze();
            System.Console.WriteLine("Transposed ;");
            System.Console.WriteLine(transposed);

            //var normalized = matrix.Normalize();
            //System.Console.WriteLine("Normalized ;");
            //System.Console.WriteLine(normalized);

            var inverted = matrix.Inverse();
            System.Console.WriteLine("Inverted ;");
            System.Console.WriteLine(inverted);

            System.Console.ReadLine();
        }
    }
}
