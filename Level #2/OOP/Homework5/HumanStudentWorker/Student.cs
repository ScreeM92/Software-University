using System;

    class Student : Human
    {
        private string facultyNumber;

        public Student(string firstname, string lastname, string facultyNumber)
            :base(firstname, lastname)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get
            {
                return facultyNumber;
            }
            set
            {
                if (value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentException("The length of faculty number have to be 5-10 letters/digits");
                }
                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Firstname: {0}, Lastname: {1}, Faculty number: {2}", this.FirstName, this.LastName, this.FacultyNumber);
        }
    }

