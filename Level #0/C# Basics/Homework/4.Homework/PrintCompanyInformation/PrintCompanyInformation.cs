using System;
    class PrintCompanyInformation
    {
        static void Main()
        {
            Console.Write("Company name:");
            string companyName = Console.ReadLine();
            Console.Write("Company address:");
            string companyAddress = Console.ReadLine();
            Console.Write("Phone number:");
            string companyNumber = Console.ReadLine();
            Console.Write("Fax number:");
            string companyFax = Console.ReadLine();
            Console.Write("Web site:");
            string companySite = Console.ReadLine();
            Console.Write("Manager first name:");
            string managerName = Console.ReadLine();
            Console.Write("Manager last name:");
            string managerLastName = Console.ReadLine();
            Console.Write("Manager age:");
            int managerAge = int.Parse(Console.ReadLine());
            Console.Write("Manager phone:");
            string managerNumber = Console.ReadLine();
            Console.WriteLine("Company Name: {0}", companyName);
            Console.WriteLine("Company Address: {0}", companyAddress);
            Console.WriteLine("Company Number: {0}", companyNumber);
            Console.WriteLine("Company Fax: {0}", companyFax);
            Console.WriteLine("Company Website: {0}", companySite);
            Console.WriteLine("Manager : {0} {1}", managerName, managerLastName);            
            Console.WriteLine("Manager Age: {0}", managerAge);
            Console.WriteLine("Manager Number: {0}", managerNumber);
        }
    }

