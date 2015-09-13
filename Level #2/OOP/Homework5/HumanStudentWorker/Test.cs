using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class Test
    {
        static void Main()
        {
            IList<Student> students = new List<Student>()
            {
                new Student("Mihail", "Nikov", "12343456"),
                new Student("Iliq", "Pavlov", "6789410"),
                new Student("Gihail", "Mikov", "1223456"),
                new Student("Aliq", "Ravlov", "6783910"),
                new Student("Cihail", "Pikov", "124143456"),
                new Student("Rliq", "Ravlov", "6728910"),
                new Student("Gyihail", "Vikov", "22123456"),
                new Student("Bliq", "Gavlov", "56781910"),
                new Student("Aihail", "Tikov", "5412123456"),
                new Student("Zlatan", "Davlov", "267318910"),
            };

            //students.OrderBy(s => s.FacultyNumber).ToList().ForEach(s => Console.WriteLine(s.ToString()));

            IList<Worker> workers = new List<Worker>()
            {
                new Worker("Dancho", "Iglikov", 250, 5),
                new Worker("Gancho", "Rglikov", 450, 8),
                new Worker("Pancho", "Vglikov", 1250, 3),
                new Worker("Rancho", "Rglikov", 2250, 5),
                new Worker("Tancho", "Aglikov", 3250, 4),
                new Worker("Erncho", "Tglikov", 2150, 9),
                new Worker("Pancho", "Jglikov", 50, 11),
                new Worker("Rencho", "Kglikov", 5250, 4),
                new Worker("Vencho", "Vlikov", 330, 1),
                new Worker("Pencho", "Rlikov", 440, 12)
            };

            //workers.OrderByDescending(s => s.MoneyPerHour()).ToList().ForEach(s => Console.WriteLine(s.ToString()));

            List<Human> humans = new List<Human>();

            humans.AddRange(students);
            humans.AddRange(workers);

            humans.OrderBy(h => h.FirstName).ThenBy(h => h.LastName).ToList().ForEach(h => Console.WriteLine(h.ToString())); 
        }    
    }

