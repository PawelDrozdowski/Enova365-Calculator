using Rekrutacja.Workers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Rekrutacja.Workers.Template.TemplateWorker;

namespace Rekrutacja.Workers.Managers
{
    public class CalculatorManager
    {
        public static CalculatorResults GetCalculatorResults(Pkt1WorkerParametry parametry)
        {
            ThrowExceptionIfIllegalOperation(parametry.Operacja, parametry.B);

            double wynik = 0;
            switch (parametry.Operacja)
            {
                case "+":
                    wynik = parametry.A + parametry.B;
                    break;
                case "-":
                    wynik = parametry.A - parametry.B;
                    break;
                case "*":
                    wynik = parametry.A * parametry.B;
                    break;
                case "/":
                    wynik = parametry.A / parametry.B;
                    break;
            }

            return new CalculatorResults
            {
                Wynik = wynik,
                DataObliczen = parametry.DataObliczen
            };
        }

        private static void ThrowExceptionIfIllegalOperation(string operation, int b)
        {
            string[] legalValues = new string[] { "+", "-", "/", "*" };
            if (!legalValues.Any(x => x == operation))
                throw new Exception($"Nieznana operacja [{operation}]");
            if (operation == "/" && b == 0)
                throw new ArgumentException("Nie można dzielić przez zero");
        }
    }
}
