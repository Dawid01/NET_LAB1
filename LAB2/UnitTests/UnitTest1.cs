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
            List<int> sizes = new List<int>() { 10, 20, 30, 40, 50 };
            foreach (int n in sizes)
            {
                Assert.AreEqual(n, new Problem(n, 10).items.Count);
            }
            Assert.Pass();
        }
        
        [Test]
        public void TestMethodForStaticResult()
        {
            Result result = new Problem(10, 1).Solve(50);
            Assert.AreEqual(18, result.totalValue);
            Assert.AreEqual(17, result.totalWeight);
            Assert.Pass();
        }
        
    }
}