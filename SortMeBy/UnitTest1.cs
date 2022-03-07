using NUnit.Framework;
using System;
using System.IO;

namespace SortMeBy
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            string filePath = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), (@"Data\99.txt"));

            var newList = People.GetPeople(filePath);

            var column1 = newList[0].FirstName;
            var column2 = newList[0].LastName;
            Assert.AreEqual("John", column1);
            Assert.AreEqual("Doe", column2);

        }
        [Test]
        public void Test2()
        {
            string filePath = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), (@"Data\99.txt"));

            Assert.IsTrue(File.Exists(filePath));

        }

        [Test]
        public void Test3()
        {
            string filePath = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), (@"Data\Brooklyn99.txt"));

            Assert.IsFalse(File.Exists(filePath));

        }

        [Test]
        public void Test4()
        {
            string filePath = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), (@"Data\99.txt"));

            var newList = People.GetPeople(filePath);
            newList = Program.Sort(newList);

            var column1 = newList[0].FirstName;
            var column2 = newList[0].LastName;
            Assert.AreEqual("Alice", column1);
            Assert.AreEqual("Bob", column2);

        }

    }
}