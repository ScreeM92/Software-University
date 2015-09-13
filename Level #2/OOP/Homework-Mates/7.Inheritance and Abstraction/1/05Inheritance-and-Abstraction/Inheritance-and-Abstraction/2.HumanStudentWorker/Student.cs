using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.HumanStudentWorker
{
    class Student : Human
    {
        private string faultyNumber;

        public string  FaultNumber { get; set; }

        public Student(string firstName, string lastName, string faultyNumber) :base(firstName, lastName)
        {
            this.FaultNumber = faultyNumber;
        }

        public override string ToString()
        {
            string Students = string.Format("{0} {1} {2}", FirstName, LastName, FaultNumber);
            return Students.ToString();
        }
    }
}
