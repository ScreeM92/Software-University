/*A company has name, address, phone number, fax number, web site and manager. 
The manager has first name, last name, age and a phone number. 
Write a program that reads the information about a company and its manager and prints it back on the console.*/

using System;

class CompanyInfo
{
    static void Main(string[] args)
    {
        Console.Write("Company name: ");
        string company = Console.ReadLine();

        Console.Write("Company address: ");
        string companyAddress = Console.ReadLine();

        Console.Write("Phone number: ");
        string phoneNum = Console.ReadLine();

        Console.Write("Fax number: ");
        string faxNum = Console.ReadLine();

        Console.Write("Web site: ");
        string webSite = Console.ReadLine();

        Console.Write("Manager first name: ");
        string mFirstName = Console.ReadLine();

        Console.Write("Manager last name: ");
        string mLastName = Console.ReadLine();

        Console.Write("Manager age: ");
        byte mAge = byte.Parse(Console.ReadLine());

        Console.Write("Manager phone: ");
        string mPhone = Console.ReadLine();

        Console.WriteLine(company);
        Console.WriteLine("Address: {0}", companyAddress);
        Console.WriteLine("Tel. {0}", phoneNum);
        Console.WriteLine("Fax: {0}", faxNum);
        Console.WriteLine("Web Site: {0}", webSite);
        Console.WriteLine("Manager: {0} {1} (age: {2}, tel. {3})", mFirstName, mLastName, mAge, mPhone);
    }
}
