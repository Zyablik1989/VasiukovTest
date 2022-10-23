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
            var TaskFabruaryEndDate = InsurancePolicy.GetEndingOfGivenMonth(TaskFabruaryDate);
            DisplayDate(TaskFabruaryEndDate);

            var CurrentYearFabruaryStart = new DateTime(year: DateTime.Now.Year, month: 2, day: 1);
            Console.WriteLine("Начало февраля текущего года");
            DisplayDate(CurrentYearFabruaryStart);

            var CurrentYearFabruaryEnd = InsurancePolicy.GetEndingOfGivenMonth(CurrentYearFabruaryStart);
            Console.WriteLine("Конец февраля текущего года");
            DisplayDate(CurrentYearFabruaryEnd);

            Console.ReadLine();
        }

        static void DisplayDate(DateTime date)
        {
            Console.WriteLine(date.ToString("G"));
        }
    }

    public class InsurancePolicy
    {
        readonly DateTime DateIssued;
        readonly int MonthsOfValidity;

        public InsurancePolicy(DateTime dateIssued, int monthsOfValidity)
        {
            DateIssued = dateIssued;
            MonthsOfValidity = monthsOfValidity;
        }

        public DateTime LastMomentOfValidity {
            get 
            {
                return GetEndingOfGivenMonth(DateIssued.AddMonths(MonthsOfValidity));
            } 
        }

        public bool IsValid(DateTime date)
        {
            if (date == DateTime.MinValue)
            {
                date = DateTime.Now;
            }

            var LastMomentOfEndMonth = LastMomentOfValidity;

            if (date >= DateIssued && date <= LastMomentOfEndMonth)
                return true;
            else
                return false;
        }

        internal static DateTime GetEndingOfGivenMonth(DateTime date)
        {
            return
                new DateTime(year: date.Year, month: date.Month, day: 1)
                .AddMonths(1)
                .AddMilliseconds(-1);
        }
    }
}
