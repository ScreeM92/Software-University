namespace Ex03.Paths
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using StaticMembersAndNamespaces;

    public class TestProgram
    {
        public static void Main()
        {
            Path3D testPath = new Path3D();
            testPath.AddPoint(0, 3.78, 5);
            testPath.AddPoint(7, 3, 1);
            testPath.AddPoint(9, 4, 1);

            Storage.Save3DPointsPath(testPath, "SavedPoint.txt");
            Path3D newPath = Storage.Load3DPointsPath("SavedPoint.txt");
            Console.WriteLine(newPath[0]);
        }
    }
}
