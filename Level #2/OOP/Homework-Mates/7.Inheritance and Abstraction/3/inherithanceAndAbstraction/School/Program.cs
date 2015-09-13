using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Classes
    {
        private string textIdentifier;
        private List<Teacher> teachers;
        private string details;

        public Classes(string textIdentifier, List<Teacher> teachers, string details = null)
        {
            this.TextIdentifier = textIdentifier;
            this.Teachers = teachers;
            this.Details = details;
        }

        public string TextIdentifier
        {
            get { return this.textIdentifier; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Classes's text identifier can not be an empty string ");
                }

                this.textIdentifier = value;
            }
        }

        public List<Teacher> Teachers
        {
            get { return new List<Teacher>(teachers); }
            private set { this.teachers = value; }
        }

        public string Details
        {
            get { return this.details; }
            private set
            {
                if (String.Empty == value)
                {
                    throw new ArgumentNullException("Details can not be an empty string");
                }

                this.details = value;
            }
        }
    }
    public class Disciplines
    {
        private string name;
        private int numOfLectures;
        private List<Student> students;
        private string details;

        public Disciplines(string name, int numOfLecturs, List<Student> students, string details = null)
        {
            this.Name = name;
            this.NumOfLectuers = numOfLectures;
            this.Students = students;
            this.Details = details;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name can not be an empty string");
                }

                if (value.Length < 3)
                {
                    throw new ArgumentException("Name can not be less than 3 charachters");
                }

                this.name = value;
            }
        }

        public int NumOfLectuers
        {
            get { return this.numOfLectures; }
            private set
            {
                this.numOfLectures = value;
            }
        }

        public List<Student> Students
        {
            get { return new List<Student>(this.students); }
            private set { this.students = value; }
        }

        public string Details
        {
            get { return this.details; }
            private set
            {
                if (String.Empty == value)
                {
                    throw new ArgumentNullException("Details can not be an empty string");
                }

                this.details = value;
            }
        }
    }
    public abstract class People
    {
        private string name;
        private string details;

        public People(string name, string details = null)
        {
            this.Name = name;
            this.Details = details;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name can not be an empty string");
                }

                if (value.Length < 3)
                {
                    throw new ArgumentException("Name can not be less than 3 charachters");
                }

                this.name = value;
            }
        }

        public string Details
        {
            get { return this.details; }
            private set
            {
                if (String.Empty == value)
                {
                    throw new ArgumentNullException("Details can not be an empty string");
                }

                this.details = value;
            }
        }
    }
    public class Student : People
    {
        private int classNumber;

        public Student(string name, int classNumber, string detials = null)
            : base(name, detials)
        {
            this.ClassNumber = classNumber;
        }



        public int ClassNumber
        {
            get { return this.classNumber; }
            private set
            {
                if (value.ToString().Length < 6 || value.ToString().Contains("-"))
                {
                    throw new ArgumentOutOfRangeException("ID should be a 6 digit number");
                }

                this.classNumber = value;
            }
        }

    }
    public class Teacher : People
    {
        private List<Disciplines> disciplines;

        public Teacher(string name, List<Disciplines> disciplines, string details = null)
            : base(name, details)
        {
            this.Disciplines = disciplines;
        }

        public List<Disciplines> Disciplines
        {
            get { return new List<Disciplines>(this.disciplines); }
            private set { this.disciplines = value; }
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentsList = new List<Student>
            {
                new Student("Pesho", 204014, "some details"),
                new Student("Gosho",234314),
                new Student("Maria",152314),
            };

            var disciplinesList = new List<Disciplines>
            {
                new Disciplines("OOP",140, studentsList, "some details"),
                new Disciplines("JavaScript", 100, studentsList),
                new Disciplines("Structures and Algorithms", 120, studentsList),
            };

            List<Teacher> teachersList = new List<Teacher>
            {
                new Teacher("Gosho", disciplinesList, "some details"),
                new Teacher("Ivan", disciplinesList),
                new Teacher("Stoyan",disciplinesList),
            };

            Classes firstClass = new Classes("OOP", teachersList, "some details");
        }
    }
}
