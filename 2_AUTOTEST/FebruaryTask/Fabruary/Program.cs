using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabruary
{
    class Program
    {
        static readonly DateTime TaskFabruaryDate = new DateTime(2020, 2, 29);

        static void Main(string[] args)
        {
            Console.WriteLine("Изначальная дата из задачи");
            DisplayDate(TaskFabruaryDate);

            Console.WriteLine("Изначальная дата из задачи, конец месяца");
            var TaskFabruaryEndDate = GetEndingOfGivenMonth(TaskFabruaryDate);
            DisplayDate(TaskFabruaryEndDate);

            var CurrentYearFabruaryStart = new DateTime(year: DateTime.Now.Year, month: 2, day: 1);
            Console.WriteLine("Начало февраля текущего года");
            DisplayDate(CurrentYearFabruaryStart);

            var CurrentYearFabruaryEnd = GetEndingOfGivenMonth(CurrentYearFabruaryStart);
            Console.WriteLine("Конец февраля текущего года");
            DisplayDate(CurrentYearFabruaryEnd);


            Console.ReadLine();
        }

        static DateTime GetEndingOfGivenMonth(DateTime date)
        {
            return
                new DateTime(year: date.Year, month: date.Month, day: 1)
                .AddMonths(1)
                .AddMilliseconds(-1);
        }

        static void DisplayDate(DateTime date)
        {
            Console.WriteLine(date.ToString("G"));
        }
    }
}
