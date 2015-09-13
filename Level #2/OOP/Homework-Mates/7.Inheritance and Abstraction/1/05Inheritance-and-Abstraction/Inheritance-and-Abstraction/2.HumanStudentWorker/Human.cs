using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.HumanStudentWorker
{
    abstract class Human
    {
        private string firstName;
        private string lastName;

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

    }
}
