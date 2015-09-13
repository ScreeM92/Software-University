using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    public class Student
    {
        public Student(string firstName, string lastName, int age, string facultyNumber, string phone, string email, IList<int> marks, int groupNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.FacultyNumber = facultyNumber;
            this.Phone = phone;
            this.Email = email;
            this.Marks = marks;
            this.GroupNumber = groupNumber;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string FacultyNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IList<int> Marks { get; set; }
        public int GroupNumber { get; set; }

        public override string ToString()
        {
            return string.Format(
                "{0} {1}, {2}, FN:{3}, Tel:{4}, Email:{5}, Marks:{6}, Group:{7}",
                this.FirstName,
                this.LastName,
                this.Age,
                this.FacultyNumber,
                this.Phone,
                this.Email,
                string.Join(", ", this.Marks),
                this.GroupNumber
                );
        }
    }
}
