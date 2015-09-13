using System;

class PrintCompanyInformation
{
    static void Main()
    {
        Console.Write("Company name: ");
        string companyName = Console.ReadLine();
        Console.Write("Company address: ");
        string companyAddress = Console.ReadLine();
        Console.Write("Company phone number: ");
        int phoneNumber = int.Parse(Console.ReadLine());
        Console.Write("Company fax number: ");
        int faxNumber = int.Parse(Console.ReadLine());
        Console.Write("Company web site: ");
        string webSite = Console.ReadLine();
        Console.Write("Manager: ");
        string manager = Console.ReadLine();

        Console.Write("Manager first name: ");
        string managerFirstName = Console.ReadLine();
        Console.Write("Manager last name: ");
        string managerLastName = Console.ReadLine();
        Console.Write("Manager age: ");
        int managerAge = int.Parse(Console.ReadLine());
        Console.Write("Manager phone number: ");
        int managerPhoneNumber = int.Parse(Console.ReadLine());

        Console.Clear();

        Console.WriteLine("Company name: " + companyName);
        Console.WriteLine("Address: " + companyAddress);
        Console.WriteLine("Phone number: " + phoneNumber);
        Console.WriteLine("Fax number: " + faxNumber);
        Console.WriteLine("Web site: " + webSite);
        Console.WriteLine("Manager: " + manager);
        Console.WriteLine();
        Console.WriteLine("First name: " + managerFirstName);
        Console.WriteLine("Last name: " + managerLastName);
        Console.WriteLine("Age: " + managerAge);
        Console.WriteLine("Phone number: " + managerPhoneNumber);

    }
}
