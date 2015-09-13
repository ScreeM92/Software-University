using System;

[AttributeUsage(AttributeTargets.Struct |
AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Enum | AttributeTargets.Method)]
public class VersionAttribute : System.Attribute
{
    public string Version { get; private set; }

    public VersionAttribute(string version)
    {
        this.Version = version;
    }

    
}

[VersionAttribute("2.3")]
public class Test
{

    static void Main()
    {
        Type type = typeof(Test);
        object[] allAttributes = type.GetCustomAttributes(false);

        foreach (VersionAttribute attr in allAttributes)
        {
            Console.WriteLine("Version = {0} ", attr.Version);
        }
    }
    

    
}


