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
        public ExpenseType type;
        public int amount;
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
                if(IsMealExpenses(expense))
                    mealExpenses = GetMealExpensesAmount(expense);
                
                String mealOverExpensesMarker =
                    GetMealOverExpensesMarker(expense);

                Console.WriteLine(GetExpenseName(expense) + "\t" + expense.amount + "\t" + mealOverExpensesMarker);
                total += expense.amount;
            }

            Console.WriteLine("Meal expenses: " + mealExpenses);
            Console.WriteLine("Total expenses: " + total);
        }

        private static string GetMealOverExpensesMarker(Expense expense)
        {
            return expense.type == ExpenseType.DINNER && expense.amount > 5000 ||
                   expense.type == ExpenseType.BREAKFAST && expense.amount > 1000
                ? "X"
                : " ";
        }

        private static string GetExpenseName(Expense expense)
        {
            return expense.type switch
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
            => expense.amount;

        private static bool IsMealExpenses(Expense expense) =>
             expense.type == ExpenseType.DINNER || expense.type == ExpenseType.BREAKFAST;
        
    }
}