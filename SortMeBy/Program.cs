using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SortMeBy
{
    public class People
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public static List<People> GetPeople(string path)
        {
            List<People> valuesList = new List<People>();

            using (var f = new StreamReader(path))
            {
                string line = string.Empty;
                while ((line = f.ReadLine()) != null)
                {
                    var people = line.Split(',');
                    valuesList.Add(new People(people[0], people[1]));
                }
            }

            return valuesList;
        }

        public People(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

    }
    public class Program
    {
        static void Main(string[] args)
        {
            string filePath = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), (@"Data\99.txt"));
            RunSort(filePath);
        }

        public static void RunSort(string filePath)
        {

            var newList = People.GetPeople(filePath);

            newList = Sort(newList);

            foreach (var person in newList)
            {
                Console.WriteLine(" " + person.FirstName + " " + person.LastName);
            }
        }
        public static List<People> Sort(List<People> newList)
        {

            List<People> sortedList = new List<People>();
            sortedList = newList.OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToList();

            return sortedList;
        }
    }
}
