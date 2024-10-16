using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rekrutacja.Workers.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Rekrutacja.Workers.Template.TemplateWorker;

namespace Rekrutacja.Tests
{
    [TestClass]
    public class CalculatorManagerTests
    {
        [TestMethod]
        public void Should_Return_Correct_Add_Operation()
        {
            //Arrange
            Tuple<int, Pkt1WorkerParametry>[] testData = {
            new Tuple<int, Pkt1WorkerParametry>(5,
                new Pkt1WorkerParametry(null)
                {
                    DataObliczen = new DateTime(2024, 10, 16),
                    A = 2,
                    B = 3,
                    Operacja = "+"
                }){
            },
            new Tuple<int, Pkt1WorkerParametry>(-5,
                new Pkt1WorkerParametry(null)
                {
                    DataObliczen = new DateTime(2024, 10, 16),
                    A = -2,
                    B = -3,
                    Operacja = "+"
                }){
            }
        };

            List<double> results = new List<double>();
            //Act
            foreach (var data in testData)
            {
                results.Add(CalculatorManager.GetCalculatorResults(data.Item2).Wynik);
            }

            //Assert
            Assert.AreEqual(testData.Length, results.Count);
            for (int i = 0; i < testData.Length; i++)
            {
                Assert.AreEqual(testData[i].Item1, (int)results[i]);
            }
        }
    }
}
