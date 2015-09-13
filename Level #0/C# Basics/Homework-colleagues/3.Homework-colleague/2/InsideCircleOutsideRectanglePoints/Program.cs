using System;



namespace InsideCircleOutsideRectanglePoints
{
    class Program
    {
        static void Main()
        {
            var circle = new
            {
                position = new { x = (double)1, y = (double)1},
                radius = (double)1.5};
            var point = new
            {
                x = double.Parse(Console.ReadLine()),
                y = double.Parse(Console.ReadLine())
            };
            var ract = new
            {
                top = (double)1,
                left = (double)-1,
                width = (double)6,
                height = (double)2
            };
            bool circleInCondition = Math.Sqrt(Math.Pow(point.x - circle.position.x, 2) + Math.Pow(point.y - circle.position.x, 2)) <= circle.radius;
            bool ractOutCondition = point.y > ract.top || point.y < ract.top - ract.height || point.x < ract.left || point.x > ract.left + ract.width;
            bool checkPoint = circleInCondition && ractOutCondition;

            Console.WriteLine(checkPoint ? "Yes" : "No");
        }
    }
}
