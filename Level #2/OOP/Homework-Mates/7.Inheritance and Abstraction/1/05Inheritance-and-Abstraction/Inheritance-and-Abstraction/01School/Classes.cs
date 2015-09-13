    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01School
{
    
    public class Classes
    {
        static void Main()
        {

        }
        private string uniqueTextIdent;
        private List<Teachers> teachers;
        private string details;

        private string UniqueTextIdent { get; set; }
        public string  Details { get; set; }
        public List<Teachers> Teachers { get; set; }
            
        public Classes(string uniqueTextIdent, List<Teachers> Teachers, string details = null) 
        {
            this.UniqueTextIdent = uniqueTextIdent;
            this.Teachers = teachers;
            this.Details = details;
        }
    }
}
