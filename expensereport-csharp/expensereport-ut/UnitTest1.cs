using System;
using System.Collections.Generic;
using System.IO;
using expensereport_csharp;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            // Arrange
            var expenses = new List<Expense>
            {
                new Expense { Type = ExpenseType.Dinner, Amount = 6000 },
                new Expense { Type = ExpenseType.Breakfast, Amount = 800 },
                new Expense { Type = ExpenseType.CarRental, Amount = 15000 },
                new Expense { Type = ExpenseType.Breakfast, Amount = 1200 }
            };

            var report = new ExpenseReport();

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            report.PrintReport(expenses);

            // Assert
            string output = stringWriter.ToString();

            string expected =
                $@"Expenses {DateTime.Now}
Dinner	6000	X
Breakfast	800	 
Car Rental	15000	 
Breakfast	1200	X
Meal expenses: 8000
Total expenses: 23000
";

            Assert.AreEqual(Normalize(expected), Normalize(output));
        }

        private static string Normalize(string input)
            => input.Replace("\r\n", "\n").Trim();
        }
}

/*
 Expenses 1/2/2026 11:03:56 AM
Dinner	6000	X
Breakfast	800	 
Car Rental	15000	 
Breakfast	1200	X
Meal expenses: 1200
Total expenses: 23000
 */