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
            Console.WriteLine(GetExpenseName(expense) + "\t" + expense.Amount + "\t" + GetMealOverExpensesMarker(expense));
        }

        private static void LogReportHeader() =>
            Console.WriteLine("Expenses " + DateTime.Now);
        

        private static int CalculateMealExpenses(Expense expense, int mealExpenses)
        {
            if (IsMealExpenses(expense))
                mealExpenses += expense.Amount;
            return mealExpenses;
        }

        private static string GetMealOverExpensesMarker(Expense expense)
        {
            return expense.Type == ExpenseType.Dinner && expense.Amount > 5000 ||
                   expense.Type == ExpenseType.Breakfast && expense.Amount > 1000
                ? "X"
                : " ";
        }

        private static string GetExpenseName(Expense expense)
        {
            return expense.Type switch
            {
                ExpenseType.Dinner => "Dinner",
                ExpenseType.Breakfast => "Breakfast",
                ExpenseType.CarRental => "Car Rental",
                _ => HandleUnknownExpenseType()
            };
        }

        private static string HandleUnknownExpenseType()
        {
            throw new ArgumentOutOfRangeException();
        }

        private static int GetMealExpensesAmount( Expense expense)
            => expense.Amount;

        private static bool IsMealExpenses(Expense expense) =>
             expense.Type is ExpenseType.Dinner or ExpenseType.Breakfast;
        
    }
}