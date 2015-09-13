using System;

class Worker : Human
{
    public decimal WeekSalary { get; private set; }
    public int WorkHoursPerDay { get; private set; }

    public Worker(decimal weekSalary, int workHoursPerDay, string firstName, string lastName)
        : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    public decimal MoneyPerHour()
    {   
        int allHours = this.WorkHoursPerDay * 5;
        decimal result = this.WeekSalary / allHours;
        return result;
    }

    public override string GetName()
    {
        return this.FirstName + " " + this.LastName;
    }
}
