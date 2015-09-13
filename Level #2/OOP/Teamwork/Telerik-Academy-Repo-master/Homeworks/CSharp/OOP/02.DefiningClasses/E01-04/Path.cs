using System;
using System.Collections.Generic;

class Path
{
    private List<Point3D> points = new List<Point3D>();

    public List<Point3D> Points
    {
        get { return this.points; }
        set { this.points = value; }
    }
}