namespace DistanceCalculatorRest.Client
{
    using System;
    using RestSharp;

    public class Calculator
    {
        public static void Main()
        {
            var client = new RestClient("http://localhost:10923");
            var request = new RestRequest("api/distance", Method.GET);
            request.AddParameter("startX", "5");
            request.AddParameter("startY", "5");
            request.AddParameter("endX", "10");
            request.AddParameter("endY", "10");

            var response = client.Execute(request);
            var content = response.Content;

            Console.WriteLine(content);
        }
    }
}