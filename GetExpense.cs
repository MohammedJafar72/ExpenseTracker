using ExpenseTracker.Modals;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker
{
    internal class GetExpense
    {
        private static string? expenseLogDirectory;
        string? monthNameDirectory, yearNameDirectory, monthName, weekDayName;
        DayInfo dayInfo;
        public GetExpense()
        {
            dayInfo = new();
            DateTime today = DateTime.Today;

            weekDayName = CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(today.DayOfWeek);
            dayInfo.Day = today.Day;
            dayInfo.Month = today.Month;
            monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dayInfo.Month);
            dayInfo.Year = today.Year;

            expenseLogDirectory = "D:\\Expense Tracking Here\\";
        }

        internal void GetExpenseFunc(string expName, int expCost)
        {
            ExpenseInfo expenseInfo = new ExpenseInfo()
            {
                ExpId = new Guid(),
                ExpName = expName,
                ExpCost = expCost,
            };

            CreateDirectories();

            string txtFileName = Path.Combine(monthNameDirectory!, $"{dayInfo.Day}-{monthName}-{dayInfo.Year}.txt") + $"";
            if (!File.Exists(txtFileName))
            {
                File.Create(txtFileName).Close();

                string weekdayAndDate = $"{weekDayName}, {dayInfo.Day} {monthName}, {dayInfo.Year}\n\n";
                File.AppendAllText(txtFileName, weekdayAndDate);
            }

            string expEntry = $"ID: {expenseInfo.ExpId}\nExpense: {expenseInfo.ExpName}\nCost: {expenseInfo.ExpCost}\n" +
                $"__________________________________________\n";
            File.AppendAllText(txtFileName, expEntry);

        }

        private void CreateDirectories()
        {
            yearNameDirectory = Path.Combine(expenseLogDirectory!, Convert.ToString(dayInfo.Year));
            if (!Directory.Exists(yearNameDirectory))
                Directory.CreateDirectory(yearNameDirectory);

            monthNameDirectory = Path.Combine(yearNameDirectory!, monthName!);
            if (!Directory.Exists(monthNameDirectory))
                Directory.CreateDirectory(monthNameDirectory);
        }
    }
}
