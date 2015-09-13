using System;

namespace _01.Point3D
{
    class Point3D
    {
        private double x;
        private double y;
        private double z;
        private static readonly double startingPoint = 0;

        public double X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }
        public double Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }
        public double Z
        {
            get
            {
                return this.z;
            }
            set
            {
                this.z = value;
            }
        }
        public static double StartingPoint
        {
            get
            {
                return startingPoint;
            }
        }

        public Point3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public override string ToString()
        {
            return "X = " + this.X + "\nY = " + this.Y + "\nZ = " + this.Z;
        }
    }
}
