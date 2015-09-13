using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StaticMembersAndNamespaces;

namespace Ex03.Paths
{
    public class Path3D
    {
        private List<Point3D> pointsIn3D = new List<Point3D>();

        public int Count
        {
            get { return this.pointsIn3D.Count; }
            private set { }
        }

        public Point3D this[int index]
        {
            get { return this.pointsIn3D[index]; }
            private set { }
        }

        public void AddPoint(double x, double y, double z)
        {
            pointsIn3D.Add(new Point3D(x, y, z));
        }
    }
}
