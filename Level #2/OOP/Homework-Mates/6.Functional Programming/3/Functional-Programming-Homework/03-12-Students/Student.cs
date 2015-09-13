using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_12_Students
{
    class Student
    {
        private string firstName;
        private string lastName;
        private int age;
        private int facultyNumber;
        private string phone;
        private string email;
        private IList<int> marks;
        private int groupNumber;

        public Student(string firstName, string lastName, int age, int facultyNumber, string phone, string email,
             int groupNumber, params int[] marks)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.FacultyNumber = facultyNumber;
            this.Phone = phone;
            this.Email = email;
            this.Marks = marks.ToList();
            this.GroupNumber = groupNumber;
        }

        public string FirstName {
            get { return this.firstName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The first name cannot be null!", "First name");
                }
                this.firstName = value;
            }
            }

        public string LastName {
            get { return this.lastName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The last name cannot be null!", "Last name");
                }
                this.lastName = value;
            }
            }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The age cannot be negative", "Age");
                }
                this.age = value;
            }
        }

        public int FacultyNumber
        {
            get { return this.facultyNumber; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The faculty number cannot be negative!", "Faculty number");
                }
                this.facultyNumber = value;
            }
        }

        public string Phone
        {
            get { return this.phone; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The phone number cannot be null!", "Phone");
                }
                this.phone= value;
            }
        }

        public string Email
        {
            get { return this.email; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The email cannot be null!", "Email");
                }
                this.email = value;
            }
        }

        public IList<int> Marks
        {
            get { return this.marks; }
            set
            {
                foreach (var i in value)
                {
                    if (i < 2 || i > 6)
                    {
                        throw new ArgumentException("The marks must be between 2 and 6!", "Marks");
                    }
                }
                this.marks = value;
            }
        }

        public int GroupNumber {
            get { return this.groupNumber; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The group number cannot be negative!", "Group number");
                }
                this.groupNumber = value;
            }
            }

        public static string ConvertMarks(IList<int> marks)
        {
            return string.Join(", ", marks.Select(x => x.ToString()).ToArray());
        }

        public override string ToString()
        {
            var marskAsString = string.Join(", ", this.Marks.ToArray());
            return string.Format("{0} {1}\n age: {2}\n faculty number: {3}\n phone: {4}\n email: {5}\n group: {6}\n marks: {7}",
                this.FirstName, this.LastName, this.Age, this.FacultyNumber, this.Phone, this.Email, this.GroupNumber,
                marskAsString);
        }
    }
}
