using Matrices.Net.Abstract;
using System;

namespace Matrices.Net.Impl.Serialization
{

    public class MatrixSerializerDefaultImpl : IMatrixSerializer
    {
        public string Serialize(IMatrix matrix)
        {

            var m = matrix.ToArray();
            var longest = 0;
            var val = "";
            for (var y = 0; y < m.Length; y++)
            {
                for (var x = 0; x < m.Length; x++)
                {
                    val = "" + Math.Round((m[y][x] + double.Epsilon) * 100) / 100;
                    if (val.Length > longest)
                    {
                        longest = val.Length + 1;
                    }
                }
            }

            var result = "--" + this.Padleft("", (1 + (longest + 1) * m.Length) - 2) + "--\r\n";
            var end = result;
            for (var y = 0; y < m.Length; y++)
            {
                val = "| ";
                for (var x = 0; x < m.Length; x++)
                {
                    var current = Math.Round((m[y][x] + double.Epsilon) * 100) / 100;
                    val += this.Padleft(current + "", longest) + ",";
                }
                result = result + val.Substring(0, val.Length - 1) + " |\r\n";
            }

            return result + end;
        }

        private string Padleft(string val, int size, string chr = " ")
        {
            var s = val + "";
            while (s.Length < size) s = chr + s;
            return s;
        }
    }
}