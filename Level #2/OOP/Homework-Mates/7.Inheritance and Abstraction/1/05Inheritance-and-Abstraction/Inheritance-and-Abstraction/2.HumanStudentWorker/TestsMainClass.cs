using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.HumanStudentWorker
{
    class TestsMainClass
    {
        static void Main()
        {
            Student pesho = new Student("pesho", "petrov", "20144567");
            Student gosho = new Student("gosho", "georgiev", "20141730");
            Student misho = new Student("misho", "mishev", "20142589");
            Student ganka = new Student("ganka", "gancheva", "20146547");
            Student sanya = new Student("sanya", "mincheva", "20145285");
            Student ivan = new Student("ivan", "ivanov", "20145687");
            Student dimitar = new Student("dimitar", "dimitrov", "20143698");
            Student damyan = new Student("damyan", "damyanov", "20149634");
            Student mihail = new Student("mihail", "petrov", "20147415");
            Student doncho = new Student("doncho", "donchev", "20145612");

            List<Student> students = new List<Student>()
            {
                pesho,
                gosho,
                misho,
                ganka,
                sanya,
                ivan,
                dimitar, 
                damyan,
                mihail,
                doncho
            };

            Worker kosta = new Worker("kosta", "kostadinov", 282, 8);
            Worker sancho = new Worker("sancho", "pansa", 382, 6.5);
            Worker penka = new Worker("penka", "kostadinova", 243, 4.75);
            Worker dimitrichka = new Worker("dimitrichka", "doynova", 152, 2.75);
            Worker darina = new Worker("darina", "stamatova", 182, 5.5);
            Worker zlatomir = new Worker("zlatomir", "zlatev", 242, 7.5);
            Worker petar = new Worker("petar", "donchev", 482, 6);
            Worker pencho = new Worker("pencho", "kubadinski", 578, 9);
            Worker marko = new Worker("marko", "totev", 439, 8);
            Worker kostadin = new Worker("kostadin", "haralambov", 658, 9);

            List<Worker> workers = new List<Worker>()
            {
                kosta,
                sancho,
                penka,
                dimitrichka,
                darina,
                zlatomir,
                petar,
                pencho,
                marko,
                kostadin
            };

            var studentSorting = students.OrderBy(student => student.FaultNumber).Select(student => student);

            foreach (var item in studentSorting)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine("Workers Sorting now: \n");

            var workersDescening = workers.OrderByDescending(w => w.MoneyPerHour()).Select(w => w);

            foreach (var item in workersDescening)
            {
                Console.WriteLine(item + string.Format(", hourly rate: {0:N2}", item.MoneyPerHour()));
            }
            Console.WriteLine();
            Console.WriteLine("Sorting Humans \n");

            List<Human> humans = new List<Human>();

            humans.AddRange(students);
            humans.AddRange(workers);

            var humanSorting = humans.OrderBy(h => h.FirstName).ThenBy(h => h.LastName).Select(s => s);
            
            foreach (var item in humanSorting)
            {
                Console.WriteLine(item);
            }
        }
    }
}
