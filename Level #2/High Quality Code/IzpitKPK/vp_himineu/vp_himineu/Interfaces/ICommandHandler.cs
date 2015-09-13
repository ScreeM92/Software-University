namespace VehicleParkSystem.Interfaces
{
    using System.Collections.Generic;

    public interface ICommandHandler
    {
        string Name { get; }
        IDictionary<string, string> Parameters { get; }
    }
}
