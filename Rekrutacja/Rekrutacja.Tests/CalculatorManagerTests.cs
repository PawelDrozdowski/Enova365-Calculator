using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rekrutacja.Workers.Enums;
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
            Tuple<int, Pkt1WorkerParametry>[] testData =
            {
                new Tuple<int, Pkt1WorkerParametry>(5,
                    new Pkt1WorkerParametry(null)
                    {
                        DataObliczen = new DateTime(2024, 10, 16),
                        A = 2,
                        B = 3,
                        Operacja = "+"
                    }
                ),
                new Tuple<int, Pkt1WorkerParametry>(-5,
                    new Pkt1WorkerParametry(null)
                    {
                        DataObliczen = new DateTime(2024, 10, 16),
                        A = -2,
                        B = -3,
                        Operacja = "+"
                    }
                )
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
                    }),
                new Tuple<int, Pkt1WorkerParametry>(1,
                    new Pkt1WorkerParametry(null)
                    {
                        DataObliczen = new DateTime(2024, 10, 16),
                        A = -2,
                        B = -3,
                        Operacja = "-"
                    }),
                new Tuple<int, Pkt1WorkerParametry>(6,
                    new Pkt1WorkerParametry(null)
                    {
                        DataObliczen = new DateTime(2024, 10, 16),
                        A = 2,
                        B = 3,
                        Operacja = "*"
                    }),
                new Tuple<int, Pkt1WorkerParametry>(0,
                    new Pkt1WorkerParametry(null)
                    {
                        DataObliczen = new DateTime(2024, 10, 16),
                        A = 2,
                        B = 0,
                        Operacja = "*"
                    }),
                new Tuple<int, Pkt1WorkerParametry>(1,
                    new Pkt1WorkerParametry(null)
                    {
                        DataObliczen = new DateTime(2024, 10, 16),
                        A = 3,
                        B = 3,
                        Operacja = "/"
                    }),
                new Tuple<int, Pkt1WorkerParametry>(-2,
                    new Pkt1WorkerParametry(null)
                    {
                        DataObliczen = new DateTime(2024, 10, 16),
                        A = 7,
                        B = -3,
                        Operacja = "/"
                    })
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
            catch (Exception) { Assert.Fail(); }
        }

        [TestMethod]
        public void Should_Return_Correct_Area()
        {
            //Arrange
            Tuple<int, Pkt2WorkerParametry>[] testData = {
                new Tuple<int, Pkt2WorkerParametry>(6,
                    new Pkt2WorkerParametry(null)
                    {
                        DataObliczen = new DateTime(2024, 10, 16),
                        A = 2,
                        B = 3,
                        Figura = Figura.Prostokąt
                    }),
                new Tuple<int, Pkt2WorkerParametry>(7,
                    new Pkt2WorkerParametry(null)
                    {
                        DataObliczen = new DateTime(2024, 10, 16),
                        A = 2,
                        B = 7,
                        Figura = Figura.Trójkąt
                    }),
                new Tuple<int, Pkt2WorkerParametry>(78,
                    new Pkt2WorkerParametry(null)
                    {
                        DataObliczen = new DateTime(2024, 10, 16),
                        A = 5,
                        B = 0,
                        Figura = Figura.Koło
                    }),
                new Tuple<int, Pkt2WorkerParametry>(4,
                    new Pkt2WorkerParametry(null)
                    {
                        DataObliczen = new DateTime(2024, 10, 16),
                        A = 2,
                        B = 2,
                        Figura = Figura.Kwadrat
                    })
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
        public void Should_Throw_Exception_If_Illegal_Square()
        {
            //Arrange
            Pkt2WorkerParametry testData = new Pkt2WorkerParametry(null)
            {
                DataObliczen = new DateTime(2024, 10, 16),
                A = 5,
                B = 6,
                Figura = Figura.Kwadrat
            };

            //Act
            try
            {
                CalculatorManager.GetCalculatorResults(testData);
                Assert.Fail(); // If it gets to this line, no exception was thrown
            }
            catch (ArgumentException) { }
            catch (Exception) { Assert.Fail(); }
        }
        [TestMethod]
        public void Should_Throw_Exception_If_Non_Positive_Dimensions()
        {
            //Arrange
            Pkt2WorkerParametry testData = new Pkt2WorkerParametry(null)
            {
                DataObliczen = new DateTime(2024, 10, 16),
                A = 0,
                B = 0,
                Figura = Figura.Prostokąt
            };

            //Act
            try
            {
                CalculatorManager.GetCalculatorResults(testData);
                Assert.Fail(); // If it gets to this line, no exception was thrown
            }
            catch (ArgumentException) { }
            catch (Exception) { Assert.Fail(); }
        }
        [TestMethod]
        public void Should_Throw_Exception_If_Non_Positive_Dimensions_Circle()
        {
            //Arrange
            Pkt2WorkerParametry testData = new Pkt2WorkerParametry(null)
            {
                DataObliczen = new DateTime(2024, 10, 16),
                A = 4,
                B = 0,
                Figura = Figura.Koło
            };

            //Act
            try
            {
                CalculatorManager.GetCalculatorResults(testData);
                Assert.Fail(); // If it gets to this line, no exception was thrown
            }
            catch (ArgumentException) { }
            catch (Exception) { Assert.Fail(); }
        }
    }
}
