using System;

class EmployeeData
{
    static void Main()
    {
        Console.Title = "Employee Data";

        string firstName = "Ivan";
        string lastName = "Ivanov"; 
        byte age = 25; 
        char gender = 'm'; 
        long id = 123455678; 
        uint uniqNum = 12345678u; 

        Console.WriteLine("\nEmployee: {0} {1} | Age: {2} | Gender: {3} \n"
            + "Employee ID: {4} | Unique number: {5} \n", firstName, lastName, age, gender, id, uniqNum);
    }
}