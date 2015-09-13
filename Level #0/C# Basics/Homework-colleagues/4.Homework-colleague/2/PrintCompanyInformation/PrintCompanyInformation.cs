using System;

class PrintCompanyInformation
{
    static void Main()
    {
        Console.Write("Company name: ");
        string companyName = Console.ReadLine();
        if (companyName == "")
        {
            companyName = "(not given)";
        }
        Console.Write("Company address: ");
        string companyAddress = Console.ReadLine();
        if (companyAddress == "")
        {
            companyAddress = "(not given)";
        }
        Console.Write("Phone number: ");
        string phoneNumber = Console.ReadLine();
        if (phoneNumber == "")
        {
            phoneNumber = "(not given)";
        }
        Console.Write("Fax number: ");
        string faxNumber = Console.ReadLine();
        if (faxNumber == "")
        {
            faxNumber = "(not given)";
        }
        Console.Write("Web site: ");
        string webSite = Console.ReadLine();
        if (webSite == "")
        {
            webSite = "(not given)";
        }
        Console.Write("Manager first name:");
        string managerFirstName = Console.ReadLine();
        if (managerFirstName == "")
        {
            managerFirstName = "(not given)";
        }
        Console.Write("Manager last name:");
        string managerLastName = Console.ReadLine();
        if (managerLastName == "")
        {
            managerLastName = "(not given)";
        }
        Console.Write("Manager age:");
        string managerAge = Console.ReadLine();
        if (managerAge == "")
        {
            managerAge = "(not given)";
        }
        Console.Write("Manager phone:");
        string managerPhone = Console.ReadLine();
        if (managerPhone == "")
        {
            managerPhone = "(not given)";
        }
        Console.WriteLine("\n{0}\nAddress: {1}\nTel. {2}\nFax: {3}\nWeb site: {4}\nManager: {5} (age {6}, tel.{7})", companyName, companyAddress, phoneNumber, faxNumber, webSite, managerFirstName, managerLastName, managerAge, managerPhone);
    }
}