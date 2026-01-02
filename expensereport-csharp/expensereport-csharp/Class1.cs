using System;
using System.Collections.Generic;

namespace expensereport_csharp
{
    public sealed record ExpenseType(string name, int limit, bool isMeal)
    {
        public readonly string Name = name;
        public readonly int Limit = limit;
        public readonly bool IsMeal = isMeal;

        public static readonly ExpenseType Dinner = new ExpenseType("Dinner", 5000, true);
        public static readonly ExpenseType Breakfast = new ExpenseType("Breakfast", 1000, true);
        public static readonly ExpenseType CarRental = new ExpenseType("CarRental", 0, false);
    }
    public class Expense
    {
        public ExpenseType Type;
        public int Amount;
        private int _mealExpenses;

        public string Name => Type.Name;
        private bool IsOverExpenses => Amount > Type.Limit;
        private bool IsMeal => Type.IsMeal;
        public int MealExpenses => IsMeal ? Amount : 0;
        public  string GetMealOverExpensesMarker()
        {
            return (Type == ExpenseType.Dinner || Type == ExpenseType.Breakfast) && IsOverExpenses
                ? "X"
                : " ";
        }
        
    }

    public class ExpenseReport
    {
        
        public void PrintReport(List<Expense> expenses)
        {
            int total = 0;
            int mealExpenses = 0;
            LogReportHeader();
            foreach (Expense expense in expenses)
            {
                mealExpenses += expense.MealExpenses; 
                total += expense.Amount;
            }
            foreach (Expense expense in expenses)
            {
                PrintExpenseDetails(expense);
            }
            DisplayExpenseSummary(mealExpenses, total);
        }

        private static void DisplayExpenseSummary(int mealExpenses, int total)
        {
            Console.WriteLine("Meal expenses: " + mealExpenses);
            Console.WriteLine("Total expenses: " + total);
        }

        private static void PrintExpenseDetails(Expense expense)
            => Console.WriteLine(expense.Name + "\t" + expense.Amount + "\t" + expense.GetMealOverExpensesMarker());
        
        private static void LogReportHeader() =>
            Console.WriteLine("Expenses " + DateTime.Now);
    }
}