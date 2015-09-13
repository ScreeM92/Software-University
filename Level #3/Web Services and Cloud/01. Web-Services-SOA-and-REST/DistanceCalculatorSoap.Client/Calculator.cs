namespace DistanceCalculatorSoap.Client
{
    using System;
    using System.ServiceModel;
    using ServiceReferenceCalculator;

    public class Calculator
    {
        public static void Main()
        {
            var client = new DistanceServiceClient();

            try
            {
                var distance = client.CalcDistance(new Point { X = 10, Y = 10 }, new Point { X = 15, Y = 15 });
                Console.WriteLine(distance);
                client.Close();
            } 
            catch (CommunicationException e) 
            { 
                client.Abort(); 
            } 
            catch (TimeoutException e) 
            { 
                client.Abort(); 
            } 
            catch (Exception e) 
            { 
                client.Abort(); 
            throw; 
            } 
        }
    }
}