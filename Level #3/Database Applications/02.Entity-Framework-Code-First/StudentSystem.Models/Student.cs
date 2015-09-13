namespace StudentSystem.Models
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Build.Framework;

    public class Student
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime? BirthDay { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }
    }
}