using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanStudentWorker
{
    public abstract class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get { return this.firstName; }
            private set
            {
                if (value.Length < 3)
                {
                    throw new AggregateException("First name can not be less than three charachers.");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Last name can not be less than 3 charachtes.");
                }

                this.lastName = value;
            }
        }

        // override the ToString method
        public override string ToString()
        {
            return String.Format("{0} {1}", this.firstName, this.lastName);
        }
    }
    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get { return this.facultyNumber; }
            private set
            {
                if (value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentOutOfRangeException("Faculty Number",
                        "Faculty Number should be between 5-10 charachters long");
                }

                this.facultyNumber = value;
            }
        }

        // override the ToString() method
        public override string ToString()
        {
            return base.ToString() + String.Format(", Faculty Number: {0}", this.facultyNumber);
        }
    }
    public class Worker : Human
    {
        private decimal weekSalary;
        private byte workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, byte workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary
        {
            get { return this.weekSalary; }
            private set
            {
                if (value < 0 || value > 1000)
                {
                    throw new ArgumentOutOfRangeException("Week Salary",
                        "Week Salary should be a decimal number in  between 0 and 1000");
                }

                this.weekSalary = value;
            }
        }

        public byte WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
            private set
            {
                if (value > 12)
                {
                    throw new ArgumentOutOfRangeException("Work hours per day",
                        "Work hours per day can not be more than 12.");
                }

                this.workHoursPerDay = value;
            }
        }

        // define a method for calculation the payment per hour for a worker
        public decimal MoneyPerHour()
        {
            return this.WeekSalary / (this.WorkHoursPerDay * 5);
        }

        // override the ToString method
        public override string ToString()
        {
            return base.ToString() +
                String.Format(", Week Salary: {0}, WorkHours per/day: {1}, Money per/hour: {2:0.00}",
                this.WeekSalary, this.workHoursPerDay, this.MoneyPerHour());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
                     var studentsList = new List<Student>()
            {            
                new Student("Boris", "Chernev","sf123m0914"),
                new Student("Pesho", "Goshev","sf123m1014"),
                new Student("Minka", "Prodanova","sf122f1414"),
                new Student("Petya", "Fastykova","pl130f0414"),
                new Student("Misho", "Grozev","pl122m1114"),
                new Student("Grezdi", "Bliznakov","sf120m5614"),
                new Student("Tichinka", "Grudkova","sf124f0014"),
                new Student("Petyo", "Kiuchukov","sf112m0914"),
                new Student("Filipka", "Kiflarska","sf126f0114"),
                new Student("Tredafilka", "Nemska","pl133f1514"),
            };

            // sort the students by facultyNumber in descending order and print them 
           var studentsByFacNum = studentsList
               .OrderByDescending(st => st.FacultyNumber)
               .Select(st => st);

           foreach (var student in studentsByFacNum)
           {
               Console.WriteLine(student);
           }

           Console.WriteLine();

           // initialize a list of 10 workers
           var workersList = new List<Worker>()
            {
                new Worker("Gosho", "Peshev",200, 6),
                new Worker("Boika", "Goshova", 300, 8),
                new Worker("Pavlina", "Prokopieva",250, 8),
                new Worker("Kadaf", "Kadafov",360, 8),
               
            };

            //sort the students by payment per hour in descending order and print them
           var workersByPayment = workersList
               .OrderByDescending(wr => wr.MoneyPerHour())
               .Select(wr => wr);

           foreach (var worker in workersByPayment)
           {
               Console.WriteLine(worker);
           }

           Console.WriteLine();

           // mege the two list sort them by first and last name, and print them
           var mergedList = new List<Human>(studentsList.Count + workersList.Count);
           mergedList.AddRange(studentsList);
           mergedList.AddRange(workersList);

           var mergeListSortedByName = mergedList
               .OrderBy(hm => hm.FirstName)
               .ThenBy(hm => hm.LastName)
               .Select(hm => hm);

           foreach (var human in mergeListSortedByName)
           {
               Console.WriteLine(human);
           }
         
        
        }
    }
}
