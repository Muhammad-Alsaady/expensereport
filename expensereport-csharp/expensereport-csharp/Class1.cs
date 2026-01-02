using System;
using System.Collections.Generic;

namespace expensereport_csharp
{
    public enum ExpenseType
    {
        Dinner, Breakfast, CarRental
    }

    public class Expense
    {
        public ExpenseType Type;
        public int Amount;
        
        public  string GetMealOverExpensesMarker()
        {
            return Type == ExpenseType.Dinner && Amount > 5000 ||
                   Type == ExpenseType.Breakfast && Amount > 1000
                ? "X"
                : " ";
        }
        
        public string GetExpenseName()
         => Type.ToString();
        public bool IsMealExpenses() =>
            Type is ExpenseType.Dinner or ExpenseType.Breakfast;
    }

    public class ExpenseReport
    {
        private int _total;
        private int _mealExpenses;

        public void PrintReport(List<Expense> expenses)
        {
            _total = 0;
            _mealExpenses = 0;

            LogReportHeader();
            
            foreach (Expense expense in expenses)
            {
                _mealExpenses = CalculateMealExpenses(expense, _mealExpenses); 
                _total += expense.Amount;
            }
            
            foreach (Expense expense in expenses)
            {
                PrintExpenseDetails(expense);
            }
            DisplayExpenseSummary(_mealExpenses, _total);
        }

        private static void DisplayExpenseSummary(int mealExpenses, int total)
        {
            Console.WriteLine("Meal expenses: " + mealExpenses);
            Console.WriteLine("Total expenses: " + total);
        }

        private static void PrintExpenseDetails(Expense expense)
        {
            Console.WriteLine(expense.GetExpenseName() + "\t" + expense.Amount + "\t" + expense.GetMealOverExpensesMarker());
        }

        private static void LogReportHeader() =>
            Console.WriteLine("Expenses " + DateTime.Now);
        
        private static int CalculateMealExpenses(Expense expense, int mealExpenses)
        {
            if (expense.IsMealExpenses())
                mealExpenses += expense.Amount;
            return mealExpenses;
        }
    }
}