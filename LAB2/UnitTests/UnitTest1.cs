using System.Collections.Generic;
using KnapsackProblem;
using NUnit.Framework;

namespace UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestMethodCountElement()
        {
            //Czy liczba przedmiotów w problemie jest zgodna z oczekiwaną liczbą.
            List<int> sizes = new List<int>() { 10, 20, 30, 40, 50 };
            foreach (int n in sizes)
            {
                Assert.AreEqual(n, new Problem(n, 10).items.Count);
            }
        }

        [Test]
        public void TestMethodResultIsNotEmpty()
        {
            //Czy wynikowa lista przedmiotów w rozwiązaniu nie jest pusta.
            List<int> sizes = new List<int>() { 10, 20, 30, 40, 50 };
            foreach (int n in sizes)
            {
                Result result = new Problem(n, 10).Solve(50);
                Assert.IsNotNull(result);
                Assert.IsNotEmpty(result.items);
            }
        }

        [Test]
        public void TestMethodForStaticResult()
        {
            //Czy wynik jest zgodny z oczekiwanym wynikiem dla określonej instancji problemu.
            Result result = new Problem(10, 1).Solve(50);
            Assert.AreEqual(38, result.totalValue);
            Assert.AreEqual(50, result.totalWeight);
        }

        [Test]
        public void TestMethodAtLeastOneItemFits()
        {
            //Czy w wyniku znajduje się co najmniej jeden przedmiot, który pasuje do plecaka.
            Problem problem = new Problem(5, 1);
            problem.items = new List<Item>()
            {
                new Item(10, 10),
                new Item(20, 30),
                new Item(5, 5),
                new Item(15, 20),
                new Item(25, 40)
            };
            Result result = problem.Solve(50);

            Assert.IsTrue(result.items.Count > 0);
        }

        [Test]
        public void TestMethodNoItemFits()
        {
            //Czy w przypadku, gdy żaden przedmiot nie pasuje do plecaka, zwracane jest puste rozwiązanie.
            Problem problem = new Problem(5, 1);
            problem.items = new List<Item>()
            {
                new Item(20, 30),
                new Item(15, 25),
                new Item(25, 35),
                new Item(30, 40),
                new Item(40, 50)
            };
            Result result = problem.Solve(5);

            Assert.IsEmpty(result.items);
        }

        [Test]
        public void TestMethodItemOrderInfluencesSolution()
        {
            //Czy kolejność przedmiotów wpływa na znalezione rozwiązanie.
            Problem problem1 = new Problem(5, 1);
            problem1.items = new List<Item>()
            {
                new Item(10, 10),
                new Item(20, 30),
                new Item(5, 5),
                new Item(15, 20),
                new Item(25, 40)
            };
            Problem problem2 = new Problem(5, 1);
            problem2.items = new List<Item>()
            {
                new Item(25, 40),
                new Item(5, 5),
                new Item(15, 20),
                new Item(20, 30),
                new Item(10, 10)
            };

            Result result1 = problem1.Solve(50);
            Result result2 = problem2.Solve(50);

            Assert.AreEqual(result1.totalValue, result2.totalValue);
            Assert.AreEqual(result1.totalWeight, result2.totalWeight);
        }

        [Test]
        public void TestMethodCorrectnessForSpecificInstance()
        {
            Problem problem = new Problem(5, 1);
            problem.items = new List<Item>()
            {
                new Item(10, 10),
                new Item(20, 30),
                new Item(5, 5),
                new Item(15, 20),
                new Item(25, 40)
            };

            Result result = problem.Solve(50);

            Assert.AreEqual(30, result.totalValue); 
            Assert.AreEqual(35, result.totalWeight); 
        }
    }
}
