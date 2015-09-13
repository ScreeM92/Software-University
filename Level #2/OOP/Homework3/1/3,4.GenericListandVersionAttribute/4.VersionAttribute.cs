using System;

    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface
        | AttributeTargets.Enum | AttributeTargets.Method, AllowMultiple = true)]
    public class VersionAttribute : System.Attribute
    {
        public int MinorVersion { get; private set; }
        public int MajorVersion { get; private set; }

        public VersionAttribute(int major, int minor)
        {
            this.MajorVersion = major;
            this.MinorVersion = minor;
        }

        public override string ToString()
        {
            return this.MajorVersion + "." + this.MinorVersion;
        }
    }
