using ICSharpCode.NRefactory.TypeSystem.Implementation;
using Rekrutacja.Extensions;
using Rekrutacja.Workers.Enums;
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
        public static CalculatorResults GetCalculatorResults(Pkt3WorkerParametry parametry)
        {
            var parsed = new Pkt2WorkerParametry(parametry.Context)
            {
                A = parametry.A.ConvertToInt(),
                B = parametry.B.ConvertToInt(),
                DataObliczen = parametry.DataObliczen,
                Figura = parametry.Figura,
            };
            return GetCalculatorResults(parsed);//brudne, ale wystarczające na potrzeby demonstracji
        }

        public static CalculatorResults GetCalculatorResults(Pkt2WorkerParametry parametry)
        {
            ThrowExceptionIfIllegalShape(parametry.Figura, parametry.A, parametry.B);

            double wynik = 0;
            switch (parametry.Figura)
            {
                case Figura.Kwadrat:
                    wynik = parametry.A * parametry.B;
                    break;
                case Figura.Prostokąt:
                    wynik = parametry.A * parametry.B;
                    break;
                case Figura.Trójkąt:
                    wynik = parametry.A * parametry.B / 2;
                    break;
                case Figura.Koło:
                    wynik = parametry.A * parametry.A * Math.PI;
                    break;
            }

            return new CalculatorResults
            {
                Wynik = (int)wynik,
                DataObliczen = parametry.DataObliczen
            };
        }

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

        private static void ThrowExceptionIfIllegalShape(Figura figura, int a, int b)
        {
            if (figura == Figura.Koło && a < 1)
                throw new ArgumentException("Minimalna długość A to 1. B jest ignorowane dla koła");
            if (figura != Figura.Koło && (a < 1 || b < 1))
                throw new ArgumentException("Minimalna długość A lub B to 1");
            if (figura == Figura.Kwadrat & a != b)
                throw new ArgumentException("Kwadrat musi mieć równe boki");
        }
    }
}
