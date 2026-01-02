using System;
using System.Collections.Generic;

namespace expensereport_csharp
{
    public enum ExpenseType
    {
        DINNER, BREAKFAST, CAR_RENTAL
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
                if (IsMealExpenses(expense))
                    total += expense.Amount; //GetMealExpensesAmount(expense);
                Console.WriteLine(GetExpenseName(expense) + "\t" + expense.Amount + "\t" + GetMealOverExpensesMarker(expense));
                total += expense.Amount;
            }

            Console.WriteLine("Meal expenses: " + mealExpenses);
            Console.WriteLine("Total expenses: " + total);
        }

        private static string GetMealOverExpensesMarker(Expense expense)
        {
            return expense.Type == ExpenseType.DINNER && expense.Amount > 5000 ||
                   expense.Type == ExpenseType.BREAKFAST && expense.Amount > 1000
                ? "X"
                : " ";
        }

        private static string GetExpenseName(Expense expense)
        {
            return expense.Type switch
            {
                ExpenseType.DINNER => "Dinner",
                ExpenseType.BREAKFAST => "Breakfast",
                ExpenseType.CAR_RENTAL => "Car Rental",
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
             expense.Type == ExpenseType.DINNER || expense.Type == ExpenseType.BREAKFAST;
        
    }
}