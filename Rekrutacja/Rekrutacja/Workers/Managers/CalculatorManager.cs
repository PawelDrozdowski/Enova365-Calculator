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
        //todo pozostałe operacje
        public static CalculatorResults GetCalculatorResults(Pkt1WorkerParametry parametry)
        {
            ThrowExceptionIfUnknownOperation(parametry);
            return new CalculatorResults
            {
                Wynik = parametry.A + parametry.B,
                DataObliczen = parametry.DataObliczen
            };
        }

        private static void ThrowExceptionIfUnknownOperation(Pkt1WorkerParametry parametry)
        {
            if (parametry.Operacja != "+")
                throw new Exception("Wersja próbna - można wybrać tylko operację: [+]");
        }
    }
}
