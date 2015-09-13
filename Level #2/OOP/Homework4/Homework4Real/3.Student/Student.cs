using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Class_Student
{
    class Student
    {
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        public int FacultyNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<int> Marks { get; set; }
        public int GroupNumber { get; set; }
        public string GroupName { get; set; }

        public Student(string firstName, string lastName, int age, int factualyNumber,
            string phone, string email, List<int> marks, int groupNumber, string groupName)
        {
            this.FirstName = firstName;
            this.Lastname = lastName;
            this.Age = age;
            this.FacultyNumber = factualyNumber;
            this.Phone = phone;
            this.Email = email;
            this.Marks = marks;
            this.GroupNumber = groupNumber;
            this.GroupName = groupName;
        }

        public override string ToString()
        {
            string marks = String.Join(", ", this.Marks);
            string result =
                String.Format("Student: {0} {1},\nAge: {2} \nFactualy number: {3}, \nPhone: {4}, \nEmail: {5}, \nMarks: ({6}), \nGroup number: {7}\nGroup name: {8}\n",
                this.FirstName, this.Lastname, this.Age, this.FacultyNumber, this.Phone, this.Email,
                marks, this.GroupNumber, this.GroupName);

            return result;
        }
    }
}