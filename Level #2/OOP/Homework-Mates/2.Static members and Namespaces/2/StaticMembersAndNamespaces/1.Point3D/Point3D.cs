using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Point3D
{
    class Point3D
    {
        private double Xcoordinate;
        private double Ycoordinate;
        private double Zcoordinate;
        private static readonly Point3D startPoint;
        public Point3D(double Xcoordinate = 0.0, double Ycoordinate = 0.0, double Zcoordinate = 0.0)
        {
            this.xcoordinate = Xcoordinate;
            this.ycoordinate = Ycoordinate;
            this.zcoordinate = Zcoordinate;
        }
        static Point3D()
        {

            startPoint = new Point3D(0, 0, 0);
            Console.WriteLine("Center {0}", startPoint);
        }
        public static Point3D StartPoint
        {
            get
            {
                return Point3D.startPoint;
            }
        }
        public double xcoordinate
        {
            get
            {
                return this.Xcoordinate;
            }
            set
            {
                this.Xcoordinate = value;
            }
        }
        public double ycoordinate
        {
            get
            {
                return this.Ycoordinate;
            }
            set
            {
                this.Ycoordinate = value;
            }
        }
        public double zcoordinate
        {
            get
            {
                return this.Zcoordinate;
            }
            set
            {
                this.Zcoordinate = value;
            }
        }
        public override string ToString()
        {
            return string.Format("point: ({0},{1},{2})",
                this.Xcoordinate, this.Ycoordinate, this.Zcoordinate);
        }

    }
}
