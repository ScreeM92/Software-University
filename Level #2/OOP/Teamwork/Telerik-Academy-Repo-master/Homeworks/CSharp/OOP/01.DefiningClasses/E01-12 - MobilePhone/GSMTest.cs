using System;

class GSMTest
{
    public static void Main()
    {
        //Console.Write("Enter number of phones: ");
        //int number = int.Parse(Console.ReadLine());
        //GSM[] phones = new GSM[number];

        //for (int i = 0; i < number; i++)
        //{
        //    Console.Write("Enter phone model: ");
        //    string model = Console.ReadLine();
        //    Console.Write("Enter phone manifacutrer: ");
        //    string manifacture = Console.ReadLine();
        //    Console.Write("Enter phone owner: ");
        //    string owner = Console.ReadLine();
        //    Console.Write("Enter phone price: ");
        //    string price = Console.ReadLine();
        //    Console.Write("Enter phone batter model: ");
        //    string batteryModel = Console.ReadLine();
        //    Console.Write("Enter phone battery idle hours: ");
        //    string idleHours = Console.ReadLine();
        //    Console.Write("Enter phone battery talk hours: ");
        //    string talkHours = Console.ReadLine();
        //    Console.Write("Enter phone display size: ");
        //    string displaySize = Console.ReadLine();
        //    Console.Write("Enter phone number of colors: ");
        //    string displayColors = Console.ReadLine();

        //    phones[i] = new GSM(model, manifacture, owner, double.Parse(price), batteryModel, int.Parse(idleHours), int.Parse(talkHours), double.Parse(displaySize), int.Parse(displayColors));
        //}

        //foreach (var item in phones)
        //{
        //    Console.WriteLine();
        //    item.GetInfo();
              //Console.WriteLine(item.ToString());
        //    Console.WriteLine();
        //}
     
     
        
        //---------------------------------------------------------------------------------------------------//
        //CallHistoryTest
        GSM mobile = new GSM("3310", "Nokia", "Some swedish guy", 100m, "ARhd34", 310, 140, 4.3f, 16000000, BatteryType.LiIon);
        Console.WriteLine(mobile.ToString());

        //mobile.GetInfo();

        mobile.AddCalls("12:50", 0894216738, 50, 21, 12, 2013);
        mobile.AddCalls("16:23", 0894216738, 120, 21, 12, 2013);
        mobile.AddCalls("18:32", 0894216738, 23, 24, 12, 2013);
        mobile.AddCalls("12:17", 0894216738, 180, 29, 12, 2013);

        //Get info for the calls
        Console.WriteLine();
        foreach (var item in mobile.callHistory)
        {
            Console.WriteLine(item.date + " " + item.dialedNumber + " " + item.duration + " " + item.Time);
        }

        //Print total price
        Console.WriteLine();
        Console.WriteLine("Total price: {0}", mobile.CalculateTotalBill(0.37m));

        //Delete longest call and print price again
        mobile.callHistory.Remove(mobile.callHistory[3]);
        
        Console.WriteLine();
        Console.WriteLine("Total price: {0}", mobile.CalculateTotalBill(0.37m));

        //Clear call history and print again
        mobile.callHistory.Clear();

        Console.WriteLine();
        foreach (var item in mobile.callHistory)
        {
            Console.WriteLine(item.date + " " + item.dialedNumber + " " + item.duration + " " + item.Time);
        }
    }
}
