using System;

struct Point3D
{
    //fields
    private int widthX;
    private int heightY;
    private int depthZ;
    private static readonly Point3D coordCenter = new Point3D(0, 0, 0);

    //constructors
    public Point3D(string toString): this()
    {
        this.widthX = int.Parse(toString.Substring(0, toString.IndexOf(",")));
        this.heightY = int.Parse(toString.Substring(toString.IndexOf(" ") + 1, toString.LastIndexOf(",") - toString.IndexOf(" ") - 1));
        this.depthZ = int.Parse(toString.Substring(toString.LastIndexOf(" ") + 1));
    }

    public Point3D(int width, int height, int depth):this()
    {
        this.widthX = width;
        this.heightY = height;
        this.depthZ = depth;
    }

    //properties
    public static Point3D CoordCenter
    {
        get { return coordCenter; }
    }

    public int DepthZ
    {
        get { return depthZ; }
        set { depthZ = value; }
    }

    public int HeightY
    {
        get { return heightY; }
        set { this.heightY = value; }
    }
    

    public int WidthX
    {
        get { return widthX; }
        set { this.widthX = value; }
    }
    
    //methods
    public override string ToString()
    {
        return string.Format("{0}, {1}, {2}",
            this.widthX, this.heightY, this.depthZ);
    }
}
