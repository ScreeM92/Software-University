using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyHierarchy
{
    public class Customer : Person, ICustomer
    {
        private decimal netPurchaseAmount;

        public Customer(string firstName, string lastName, int id, decimal netPurchaseAmount)
            : base(firstName, lastName, id)
        {
            this.NetPurchaseAmount = netPurchaseAmount;
        }

        public decimal NetPurchaseAmount
        {
            get { return this.netPurchaseAmount; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Net Purchase Amount",
                        "Net Purchase Amount can not be a negative sum");
                }

                this.netPurchaseAmount = value;
            }
        }

        // override the ToString() method
        public override string ToString()
        {
            return base.ToString() + String.Format("Net Purchase Amount: {0.0:00}", this.netPurchaseAmount);
        }
    }
    public enum Department
    {
        Marketing,
        Sales,
        Accounting,
        Production,
    }
    public class Developer : RegularEmployee, IDeveloper
    {
        private List<Project> projectsList;

        public Developer(string firstname, string lastname, int id, decimal salary, Department department,
            List<Project> projectsList)
            : base(firstname, lastname, id, salary, department)
        {
            this.ProjectsList = projectsList;
        }

        public List<Project> ProjectsList
        {
            get { return this.projectsList; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Project List", "Project list can not be empty");
                }

                this.projectsList = value;
            }
        }

        // override the ToString() method
        public override string ToString()
        {
            StringBuilder projects = new StringBuilder();
            projects.AppendLine("List of projects:");

            foreach (var project in this.projectsList)
            {
                projects.AppendLine(project.ToString());
            }

            return base.ToString() + projects.ToString();
        }
    }
    public abstract class Employee : Person, IEmployee
    {
        private decimal salary;
        private Department department;

        public Employee(string firstname, string lastname, int id, decimal salary, Department department)
            : base(firstname, lastname, id)
        {
            this.Salary = salary;
            this.Department = department;
        }

        public decimal Salary
        {
            get { return this.salary; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Salary", "Salary can not be a negative sum.");
                }

                this.salary = value;
            }
        }

        public Department Department
        {
            get { return this.department; }
            set { this.department = value; }
        }

        // override the ToString() method
        public override string ToString()
        {
            return base.ToString() + String.Format(" Salary: {0:0.00}, Department: {1} ",
                this.salary, this.department);
        }
    }
    public interface ICustomer : IPerson
    {
        decimal NetPurchaseAmount { get; set; }
    }
    public interface IDeveloper : IRegularEmployee
    {
        List<Project> ProjectsList { get; set; }
    }
    public interface IEmployee : IPerson
    {
        Department Department { get; set; }
        decimal Salary { get; set; }
    }
    public interface IManager : IEmployee
    {
        List<Employee> EmployeeList { get; set; }
    }
    public interface IPerson
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        int Id { get; set; }
    }

    public interface IProject
    {
        string ProjectNam { get; set; }
        DateTime ProjectStart { get; set; }
        string Details { get; set; }
        ProjectState State { get; set; }

        void CloseProject();
    }
    public interface IRegularEmployee : IEmployee
    {
    }

    public interface ISales
    {
        string ProductName { get; set; }
        DateTime ProductDate { get; set; }
        decimal Price { get; set; }
    }
    public interface ISalesEmployee : IRegularEmployee
    {
        List<Sales> SalesList { get; set; }
    }
    public class Manager : Employee, IManager
    {
        private List<Employee> employeeList;

        public Manager(string firstname, string lastname, int id, decimal salary, Department departmen,
            List<Employee> employeeList)
            : base(firstname, lastname, id, salary, departmen)
        {
            this.EmployeeList = employeeList;
        }

        public List<Employee> EmployeeList
        {
            get { return new List<Employee>(this.employeeList); }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Employee List", "Employee List can not be empty.");
                }

                this.employeeList = new List<Employee>(value);
            }
        }

        // override the ToString() method
        public override string ToString()
        {
            StringBuilder employees = new StringBuilder();
            employees.AppendLine(" Employeses under command:");

            foreach (var employee in this.employeeList)
            {
                employees.AppendLine(employee.ToString());
            }

            return base.ToString() + employees.ToString();
        }
    }
    public abstract class Person : IPerson
    {
        private string firstName;
        private string lastName;
        private int id;

        public Person(string firstName, string lastName, int id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Id = id;
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("First name can not be less than three characters.");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Last name can not be less than three characters.");
                }

                this.lastName = value;
            }
        }

        public int Id
        {
            get { return this.id; }
            set
            {
                if (value < 1 || value > 1000)
                {
                    throw new ArgumentOutOfRangeException("ID", "ID shoul be in the range [1..1000]");
                }

                this.id = value;
            }
        }

        // override the ToString() method
        public override string ToString()
        {
            return String.Format("{0} {1}", this.firstName, this.lastName);
        }
    }
    public class Project
    {
        private string projectName;
        private DateTime projectStart;
        private string details;
        private ProjectState state;

        // define a constructor which creates an open project by default
        public Project(string projectName, DateTime projectStart, string details)
        {
            this.ProjectName = projectName;
            this.ProjectStart = projectStart;
            this.details = details;
        }

        public string ProjectName
        {
            get { return this.projectName; }
            protected set
            {
                if (value.Length < 1)
                {
                    throw new ArgumentException("Project name can not be less than 1 charachter");
                }

                this.projectName = value;
            }
        }

        public DateTime ProjectStart
        {
            get { return this.projectStart; }
            protected set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("ProjectStart can not be empty");
                }

                this.projectStart = value;
            }
        }

        public string Details
        {
            get { return this.details; }
            protected set
            {
                if (value.Length < 1)
                {
                    throw new ArgumentException("Details can not be less than 1 charachter");
                }

                this.details = value;
            }
        }

        public ProjectState State
        {
            get { return this.state; }
            protected set { this.state = ProjectState.Open; }
        }

        // define a method for closing a project
        public void CloseProject()
        {
            if (this.state == ProjectState.Open)
            {
                this.state = ProjectState.Closed;
            }
            else
            {
                Console.WriteLine("The project is already cloesd.");
            }
        }

        // override the ToString() method
        public override string ToString()
        {
            return string.Format("{0} Start date: {1}, Details: {2}, State: {3}",
                this.projectName, this.projectStart, this.details, this.state);
        }
    }

    public enum ProjectState
    {
        Open,
        Closed,
    }
    public abstract class RegularEmployee : Employee, IRegularEmployee
    {
        public RegularEmployee(string firstname, string lastname, int id, decimal salary, Department department)
            : base(firstname, lastname, id, salary, department)
        {
        }

        // override the ToString() method
        public override string ToString()
        {
            return base.ToString();
        }
    }
    public class Sales : ISales
    {
        private string productName;
        private DateTime productDate;
        private decimal price;

        public Sales(string productName, DateTime productDate, decimal price)
        {
            this.ProductName = productName;
            this.ProductDate = productDate;
            this.Price = price;
        }

        public string ProductName
        {
            get { return this.productName; }
            set
            {
                if (value.Length < 2)
                {
                    throw new ArgumentOutOfRangeException("Product Name",
                        "Product Name can not be less thand 2 characters");
                }

                this.productName = value;
            }
        }

        public DateTime ProductDate
        {
            get { return this.productDate; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Product Date",
                        "Product Date can not be empty");
                }

                this.productDate = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Product Price",
                        "Product Price can not be a negative sum.");
                }

                this.price = value;
            }
        }

        // override the ToString() method
        public override string ToString()
        {
            return String.Format(" {0} from: {1}, price: {2:0.00}", this.productName, this.productDate, this.price);
        }
    }
    public class SalesEmployee : RegularEmployee, IRegularEmployee
    {
        private List<Sales> salesList;

        public SalesEmployee(string firstname, string lastname, int id, decimal salary, Department department,
            List<Sales> salesList)
            : base(firstname, lastname, id, salary, department)
        {
            this.SalesList = salesList;
        }

        public List<Sales> SalesList
        {
            get { return new List<Sales>(this.salesList); }
            set
            {
                if (value == null)
                {
                    throw new ArgumentOutOfRangeException("Sales", "Sales list can not be empty");
                }

                this.salesList = new List<Sales>(value);
            }
        }

        // override the ToString() method
        public override string ToString()
        {
            StringBuilder sales = new StringBuilder();
            sales.AppendLine("Sales made:");

            foreach (var sale in salesList)
            {
                sales.AppendLine(sale.ToString());
            }

            return base.ToString() + sales.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Sales dairy = new Sales("Milk", new DateTime(2014, 10, 1), 2.50m);
            Sales chocolate = new Sales("Chocolate", new DateTime(2014, 10, 1), 1.80m);
            Sales meat = new Sales("Meat", new DateTime(2014, 10, 1), 4.80m);
            Sales vegitables = new Sales("Vegitables", new DateTime(2014, 10, 1), 3.80m);
            Sales books = new Sales("C# Programming", new DateTime(2014, 10, 2), 9.90m);
            Sales laptop = new Sales("Toshiba Satelite", new DateTime(2014, 10, 2), 999.90m);
            Sales beer = new Sales("Stolichno tymno", new DateTime(2014, 10, 3), 1.75m);
            Sales whiskey = new Sales("Jameson", new DateTime(2014, 10, 3), 29.50m);

            // create several Sales lists
            var foodSales = new List<Sales>();
            foodSales.Add(dairy);
            foodSales.Add(chocolate);
            foodSales.Add(meat);
            foodSales.Add(vegitables);

            var otherSales = new List<Sales>();
            otherSales.Add(books);
            otherSales.Add(laptop);
            otherSales.Add(beer);
            otherSales.Add(whiskey);

            // create several projects
            Project CSharp = new Project("Accounting system", new DateTime(2014, 9, 15), "N/A");
            Project Java = new Project("Booking system", new DateTime(2014, 5, 13), "N/A");
            Project PHP = new Project("Database Center", new DateTime(2014, 8, 20), "N/A");
            Project JavaScript = new Project("On-line games", new DateTime(2014, 7, 28), "N/A");
            Project HTML_CSS = new Project("A fancy web-site", new DateTime(2014, 8, 8), "N/A");

            //create several projects lists
            var webPoejcts = new List<Project>();
            webPoejcts.Add(HTML_CSS);
            webPoejcts.Add(JavaScript);
            webPoejcts.Add(Java);

            var otherProjects = new List<Project>();
            otherProjects.Add(CSharp);
            otherProjects.Add(PHP);

            // create several employes of typep SalesEmployee
            RegularEmployee foodSalesEmployee = new SalesEmployee("Ivan", "Ivanov", 100, 1000, Department.Sales, foodSales);
            RegularEmployee othersSalesEmployee = new SalesEmployee("Dragan", "Peshev", 97, 1400, Department.Sales, otherSales);

            // create several developer employees
            RegularEmployee webDeveloper = new Developer("Maria", "Mainova", 333, 1800, Department.Marketing, webPoejcts);
            RegularEmployee appDevelooper = new Developer("Gosho", "Topciev", 666, 2800, Department.Production, otherProjects);

            // create several list of regular employess
            var otherEmployees = new List<Employee>();
            otherEmployees.Add(foodSalesEmployee);
            otherEmployees.Add(othersSalesEmployee);

            var programmerEmployees = new List<Employee>();
            programmerEmployees.Add(webDeveloper);
            programmerEmployees.Add(appDevelooper);

            // create several managers
            Employee programmingManager = new Manager("Muncho", "Gunchev", 1, 5000, Department.Sales, programmerEmployees);
            Employee accountingManager = new Manager("Iskra", "Gringo", 2, 4000, Department.Accounting, otherEmployees);

            //createa a list of managers and print them
            var managers = new List<Person>();
            managers.Add(programmingManager);
            managers.Add(accountingManager);

            foreach (var manager in managers)
            {
                Console.WriteLine(manager);
            }

        }
    }
}
