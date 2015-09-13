using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01School
{
    public class Disciplines
    {
        private string discName;
        private int numberLect;
        private List<Students> students;
        private string details;

        public string DiscName { get; set; }
        public int NumberLect { get; set; }
        public List<Students> Students { get; set; }
        public string Details { get; set; }

        public Disciplines(string discName, int numberLect, List<Students> students, string details=null)
        {
            this.DiscName = discName;
            this.NumberLect = numberLect;
            this.Students = students;
            this.Details = details;
        }
    }
}
