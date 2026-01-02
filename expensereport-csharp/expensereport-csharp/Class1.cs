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
        public void PrintReport(List<Expense> expenses)
        {
            int total = 0;
            int mealExpenses = 0;

            Console.WriteLine("Expenses " + DateTime.Now);
            
            foreach (Expense expense in expenses)
            {
                mealExpenses = CalculateMealExpenses(expense, mealExpenses); 
                Console.WriteLine(GetExpenseName(expense) + "\t" + expense.Amount + "\t" + GetMealOverExpensesMarker(expense));
                total += expense.Amount;
            }

            Console.WriteLine("Meal expenses: " + mealExpenses);
            Console.WriteLine("Total expenses: " + total);
        }

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
             expense.Type == ExpenseType.Dinner || expense.Type == ExpenseType.Breakfast;
        
    }
}