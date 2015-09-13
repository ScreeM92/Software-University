namespace VehicleParkSystem
{
    using System.Web.Script.Serialization;
    using System.Collections.Generic;
    using VehicleParkSystem.Interfaces;

    public class CommandHandler: ICommandHandler
    {
        public string Name { get; set; }
        public IDictionary<string, string> Parameters { get; set; }

        public CommandHandler(string str)
        {
            this.Name = str.Substring(0, str.IndexOf(' '));
            this.Parameters = new JavaScriptSerializer()
                .Deserialize<Dictionary<string, string>>(str.Substring(str.IndexOf(' ') + 1));
        }
    }
}















