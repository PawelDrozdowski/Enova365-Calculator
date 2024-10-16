using Rekrutacja.Workers.Models;
using Soneta.Business;
using Soneta.Kadry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rekrutacja.Workers.Managers
{
    internal class ContextManager
    {
        public Context Cx { get; set; }
        public ContextManager(Context Cx)
        {
            this.Cx = Cx;
        }
        public void ModifyEmployeesData(Pracownik[] employees, CalculatorResults calculatorResults)
        {
            using (Session session = this.Cx.Login.CreateSession(false, false, "ModyfikacjaPracownika"))
            {
                //Otwieramy Transaction aby można było edytować obiekt z sesji
                using (ITransaction trans = session.Logout(true))
                {
                    //Aktualizujemy wszystkich zaznaczonych pracowników
                    for (int i = 0; i < employees.Length; i++)
                    {
                        //Pobieramy obiekt z Nowo utworzonej sesji
                        var sessionEmployee = session.Get(employees[i]);
                        ModifyEmployeeData(sessionEmployee, calculatorResults);
                    }
                    //Zatwierdzamy zmiany wykonane w sesji
                    trans.CommitUI();
                }
                //Zapisujemy zmiany
                session.Save();
            }
        }

        private void ModifyEmployeeData(Pracownik sessionEmployee, CalculatorResults results)
        {
            //Features - są to pola rozszerzające obiekty w bazie danych, dzięki czemu nie jestesmy ogarniczeni to kolumn jakie zostały utworzone przez producenta
            sessionEmployee.Features["DataObliczen"] = results.DataObliczen;
            sessionEmployee.Features["Wynik"] = results.Wynik;
        }

        public Pracownik[] GetSelectedEmployees()
        {
            Pracownik[] employees = null;
            if (this.Cx.Contains(typeof(Pracownik[])))
            {
                employees = (Pracownik[])this.Cx[typeof(Pracownik[])];
            }

            return employees;
        }
    }
}
