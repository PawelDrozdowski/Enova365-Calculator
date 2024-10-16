using Mono.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rekrutacja.Extensions
{
    public static class StringExtensions
    {
        public static int ConvertToInt(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return 0;
            string strOperation = str.Trim();
            int minusesAmount = strOperation.Count(x=>x == '-');
            if (minusesAmount > 1 || strOperation.IndexOf('-') > 0)//tylko do jednego minusa, na pozycji -1 (dla braku) lub 0 (po lewej)
                throw new ArgumentException($"Nie można zamienić podanej wartości na liczbę [{str}]. Usuń niepoprawnie wpisane minusy");
            strOperation = strOperation.Replace("-", "");
            if (strOperation.Any(x => !char.IsDigit(x)))
                throw new ArgumentException($"Nie można zamienić podanej wartości na liczbę [{str}]");

            strOperation = string.Join("", strOperation.Reverse().ToArray()); ;
            int output = 0;
            int position = 1;
            for (int i = 0; i < strOperation.Length; i++)
            {
                output += (strOperation[i] - 48) * position;//zamiana wartości znaku ASCII na int * pozyycja dziesiętna
                position *= 10;
            }
            output = minusesAmount == 1 ? -output : output;
            return output;
        }
    }
}
