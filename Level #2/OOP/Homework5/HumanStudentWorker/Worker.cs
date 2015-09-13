using System;

    class Worker : Human
    {
        private decimal weekSalary;
        private decimal workHoursPerDay;

        public Worker(string firstname, string lastname, decimal weekSalary, decimal workHoursPerDay)
            :base(firstname, lastname)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary
        {
            get
            {
                return this.weekSalary;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The week salary can not be negative");
                }
                this.weekSalary = value;
            }
        }

        public decimal WorkHoursPerDay 
        {
            get
            {
                return workHoursPerDay;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The work hours per day cat not be negative");
                }
                this.workHoursPerDay = value;
            }
        }

        public decimal MoneyPerHour()
        {
            decimal daySalary = this.WeekSalary / 5;
            decimal hourSalary = daySalary / WorkHoursPerDay;

            return hourSalary;
        }

        public override string ToString()
        {
            return string.Format("Firstname: {0}; Lastname: {1}; Week salary: {2}, Work hours per day: {3}", FirstName, LastName, WeekSalary, WorkHoursPerDay);
        }
    }

