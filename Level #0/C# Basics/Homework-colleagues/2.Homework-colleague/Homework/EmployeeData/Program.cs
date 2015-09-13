using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeData
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName;
            string familyName;
            byte age;
            char gender;
            ulong idNumber;
            long uniqueEmpNumber; 

            firstName = "Stefan";
            familyName = "Metodiev";
            age = 36;
            gender ='m';
            idNumber = 8412261758;
            uniqueEmpNumber = 27560585;

            Console.WriteLine(" \t \t Personal Info:{0} {1}\n\n First Name: {0}\n Family Name: {1}\n Age: {2}\n Gender: {3}\n ID Number: {4}\n Employee Number: {5}"
                , firstName, familyName, age, gender, idNumber, 27560000 + uniqueEmpNumber);
            Console.ReadLine();
        }
    }
}
