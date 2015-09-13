namespace Problem_4.Generic_List_Version
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    [Version(1, 22)]

    public class Program
    {
        public static void Main()
        {
            Type typeProgram = typeof(Program);
            object[] allAttributesProgram = typeProgram.GetCustomAttributes(false);
            foreach (Problem_4.Generic_List_Version.VersionAttribute thisVersion in allAttributesProgram)
            {
                Console.WriteLine("This class (Program) has version: {0}.{1}", thisVersion.Major, thisVersion.Minor);
            }

            Type type = typeof(Problem_4.Generic_List_Version.GenericList<int>);
            object[] allAttributes = type.GetCustomAttributes(false);

            // VersionAttribute s = (VersionAttribute)allAttributes.Where(a => a is VersionAttribute);
            // Console.WriteLine(s.Major);
            for (int i = 0; i < allAttributes.Length; i++)
            {
                if (allAttributes[i] is VersionAttribute)
                {
                    VersionAttribute genericListVersion = (VersionAttribute)allAttributes[i];
                    Console.WriteLine("GenericList<T> has version: {0}.{1}", genericListVersion.Major, genericListVersion.Minor);
                }
            }
        }
    }
}
