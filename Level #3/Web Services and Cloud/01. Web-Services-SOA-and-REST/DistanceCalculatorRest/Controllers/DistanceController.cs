namespace DistanceCalculatorRest.Controllers
{
    using System;
    using System.Web.Http;
    using Models;

    public class DistanceController : ApiController
    {
        public IHttpActionResult Get(int startX, int startY, int endX, int endY)
        {
            var startPoint = new Point(startX, startY);
            var endPoint = new Point(endX, endY);
            var horizontalDistance = Math.Pow(startPoint.X - endPoint.X, 2);
            var verticalDistance = Math.Pow(startPoint.Y - endPoint.Y, 2);
            var distance = Math.Sqrt(horizontalDistance + verticalDistance);

            return this.Ok(new { Distance = distance });
        }
    }
}