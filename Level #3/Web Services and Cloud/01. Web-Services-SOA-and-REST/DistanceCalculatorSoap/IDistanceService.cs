namespace DistanceCalculatorSoap
{
    using System.Runtime.Serialization;
    using System.ServiceModel;

    [ServiceContract]
    public interface IDistanceService
    {

        [OperationContract]
        double CalcDistance(Point startPoint, Point endPoint);
    }

    [DataContract]
    public class Point
    {
        private int x;

        private int y;


        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        [DataMember]
        public int X {
            get { return this.x; }
            set { x = value; } 
        }

        [DataMember]
        public int Y {
            get { return this.y; }
            set { this.y = value; }
        }
    }
}