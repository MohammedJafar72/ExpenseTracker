namespace ExpenseTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GetExpense getExpense;
            while (true)
            {
                getExpense = new GetExpense();

                Console.Write("Expense Name: ");
                string expName = Convert.ToString(Console.ReadLine())!;
                Console.Write("Expense Cost: ");
                int expCost = Convert.ToInt32(Console.ReadLine())!;

                //if (expCost > 0 && String.IsNullOrEmpty(expName))
                    getExpense.GetExpenseFunc(expName, expCost);

                //---------------------------------------------------------------//
                Console.WriteLine("\n_______________________");
                Console.WriteLine("Press 'Q' to quit.\nPress any key to continue...");
                var quitToken = Console.ReadKey();
                if (quitToken.Key == ConsoleKey.Q)
                {
                    break;
                }
                else
                {

                }
            }
        }
    }
}
