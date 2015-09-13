namespace StudentSystem.DbContext.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentSystemContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
            this.ContextKey = "StudentSystem.DbContext.StudentSystemContext";
        }

        protected override void Seed(StudentSystemContext context)
        {
            if (context.Students.Any())
            {
                return;
            }

            ICollection<Student> students = new HashSet<Student>();
            ICollection<Course> courses = new HashSet<Course>();
            ICollection<Homework> homeworks = new HashSet<Homework>();
            ICollection<Resource> resources = new HashSet<Resource>();

            var ivan = new Student
            {
                Id = 1,
                Name = "Ivan",
                RegistrationDate = DateTime.Now,
                BirthDay = new DateTime(1990, 2, 15)
            };

            var pesho = new Student
            {
                Id = 2,
                Name = "Pesho",
                RegistrationDate = DateTime.Now,
                BirthDay = new DateTime(1990, 2, 15)
            };

            var stefan = new Student
            {
                Id = 3,
                Name = "Stefan",
                RegistrationDate = DateTime.Now,
                BirthDay = new DateTime(1990, 2, 15)
            };

            var phpCourse = new Course
            {
                Id = 1,
                Name = "PHP basics",
                Description = "Some description",
                StartDate = new DateTime(2015, 2, 15),
                EndDate = new DateTime(2015, 3, 6),
                Price = 50
            };

            var javaCourse = new Course
            {
                Id = 2,
                Name = "Java basics",
                Description = "Some description",
                StartDate = new DateTime(2015, 3, 10),
                EndDate = new DateTime(2015, 3, 22),
                Price = 60
            };

            var oopCourse = new Course
            {
                Id = 3,
                Name = "OOP",
                Description = "Some description",
                StartDate = new DateTime(2015, 3, 27),
                EndDate = new DateTime(2015, 4, 20),
                Price = 100
            };

            var javaHomework = new Homework
            {
                Id = 1,
                Content = "Java Homework",
                ContentType = ContentType.Zip,
                SubmissionDate = DateTime.Now,
                Student = ivan,
                Course = javaCourse
            };

            var phpHomework = new Homework
            {
                Id = 2,
                Content = "PHP Homework",
                ContentType = ContentType.Pdf,
                SubmissionDate = DateTime.Now,
                Student = pesho,
                Course = phpCourse
            };

            var oopHomework = new Homework
            {
                Id = 3,
                Content = "OOP Homework",
                ContentType = ContentType.Zip,
                SubmissionDate = DateTime.Now,
                Student = stefan,
                Course = oopCourse
            };

            var documentResource = new Resource
            {
                Id = 1,
                Name = "Document",
                ResourceType = ResourceType.Document,
                Url = "www.google.bg",
                Course = oopCourse
            };

            var presentationResource = new Resource
            {
                Id = 2,
                Name = "Presentation",
                ResourceType = ResourceType.Presentation,
                Url = "www.google.bg",
                Course = phpCourse
            };

            var videoResource = new Resource
            {
                Id = 3,
                Name = "Video",
                ResourceType = ResourceType.Video,
                Url = "www.google.bg",
                Course = javaCourse
            };

            ivan.Courses.Add(phpCourse);
            phpCourse.Students.Add(ivan);
            ivan.Courses.Add(oopCourse);
            oopCourse.Students.Add(ivan);
            stefan.Courses.Add(phpCourse);
            phpCourse.Students.Add(stefan);
            pesho.Courses.Add(javaCourse);
            javaCourse.Students.Add(pesho);

            students.Add(ivan);
            students.Add(pesho);
            students.Add(stefan);

            homeworks.Add(javaHomework);
            homeworks.Add(phpHomework);
            homeworks.Add(oopHomework);

            courses.Add(phpCourse);
            courses.Add(javaCourse);
            courses.Add(oopCourse);

            resources.Add(documentResource);
            resources.Add(presentationResource);
            resources.Add(videoResource);

            foreach (var student in students)
            {
                context.Students.Add(student);
            }

            foreach (var course in courses)
            {
                context.Courses.Add(course);
            }

            foreach (var resource in resources)
            {
                context.Resources.Add(resource);
            }

            foreach (var homework in homeworks)
            {
                context.Homeworks.Add(homework);
            }

            context.SaveChanges();
        }
    }
}