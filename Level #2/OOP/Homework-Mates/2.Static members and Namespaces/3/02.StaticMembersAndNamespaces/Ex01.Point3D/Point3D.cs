namespace StaticMembersAndNamespaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Point3D
    {
        private double x;
        private double y;
        private double z;

        public static Point3D StartingPoint
        {
            get
            {
                return new Point3D(0, 0, 0);
            }
        }

        public Point3D(double x, double y, double z)
        {
            this.PointX = x;
            this.PointY = y;
            this.PointZ = z;
        }

        public double PointX
        {
            get { return this.x; }
            private set { this.x = value; }
        }

        public double PointY
        {
            get { return this.y; }
            private set { this.y = value; }
        }

        public double PointZ
        {
            get { return this.z; }
            private set { this.z = value; }
        }

        public override string ToString()
        {
            return string.Format("Point3D({0}, {1}, {2})", this.PointX, this.PointY, this.PointZ);
        }
    }
}
