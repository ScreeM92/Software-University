using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01School
{
    public abstract class People
    {

        private string name;
        private string details;

        public string Name { get; set; }
        public string Details { get; set; }

        public People(string name, string details = null)
        {
            this.Name = name;
            this.Details = details;
        }
    }
}
