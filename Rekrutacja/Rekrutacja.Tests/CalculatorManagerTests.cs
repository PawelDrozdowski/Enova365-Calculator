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

        [TestMethod]
        public void Should_Return_Correct_Other_Operations()
        {
            //Arrange
            Tuple<int, Pkt1WorkerParametry>[] testData = {
            new Tuple<int, Pkt1WorkerParametry>(-1,
                new Pkt1WorkerParametry(null)
                {
                    DataObliczen = new DateTime(2024, 10, 16),
                    A = 2,
                    B = 3,
                    Operacja = "-"
                }){
            },
            new Tuple<int, Pkt1WorkerParametry>(1,
                new Pkt1WorkerParametry(null)
                {
                    DataObliczen = new DateTime(2024, 10, 16),
                    A = -2,
                    B = -3,
                    Operacja = "-"
                }){
            },
            new Tuple<int, Pkt1WorkerParametry>(6,
                new Pkt1WorkerParametry(null)
                {
                    DataObliczen = new DateTime(2024, 10, 16),
                    A = 2,
                    B = 3,
                    Operacja = "*"
                }){
            },
            new Tuple<int, Pkt1WorkerParametry>(0,
                new Pkt1WorkerParametry(null)
                {
                    DataObliczen = new DateTime(2024, 10, 16),
                    A = 2,
                    B = 0,
                    Operacja = "*"
                }){
            },
            new Tuple<int, Pkt1WorkerParametry>(1,
                new Pkt1WorkerParametry(null)
                {
                    DataObliczen = new DateTime(2024, 10, 16),
                    A = 3,
                    B = 3,
                    Operacja = "/"
                }){
            },
            new Tuple<int, Pkt1WorkerParametry>(-2,
                new Pkt1WorkerParametry(null)
                {
                    DataObliczen = new DateTime(2024, 10, 16),
                    A = 7,
                    B = -3,
                    Operacja = "/"
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

        [TestMethod]
        public void Should_Throw_Exception_If_Divide_By_Zero()
        {
            //Arrange
            Pkt1WorkerParametry testData = new Pkt1WorkerParametry(null)
            {
                DataObliczen = new DateTime(2024, 10, 16),
                A = -2,
                B = 0,
                Operacja = "/"
            };

            //Act
            try
            {
                CalculatorManager.GetCalculatorResults(testData);
                Assert.Fail(); // If it gets to this line, no exception was thrown
            }
            catch (ArgumentException) {  }
            catch (Exception ex) { Assert.Fail(); }
            
        }
    }
}
