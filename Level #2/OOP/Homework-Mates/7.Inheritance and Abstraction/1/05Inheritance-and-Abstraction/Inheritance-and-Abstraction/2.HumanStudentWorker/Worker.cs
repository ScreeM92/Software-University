using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.HumanStudentWorker
{
    class Worker :Human
    {
        private double weekSalary;
        private double hoursPerDay;

        public double WeekSalary { get; set; }
        public double HoursPerDay { get; set; }

        public Worker(string firstName, string lastName, double weekSalary, double hoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.HoursPerDay = hoursPerDay;
        }

        public double MoneyPerHour()
        {
            return ((this.WeekSalary / 5) / this.HoursPerDay);
        }

        public override string ToString()
        {
            string worker = string.Format("{0}, {1}, dailyhours: {2}, weeklySalary: {3}", FirstName, LastName, HoursPerDay, WeekSalary);
            return worker.ToString();
        }

    }
}
