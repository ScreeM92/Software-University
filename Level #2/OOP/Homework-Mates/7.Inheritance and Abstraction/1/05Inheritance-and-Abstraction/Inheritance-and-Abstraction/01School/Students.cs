using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01School
{
    public class Students :People
    {
        
        private int uniqueClassNum;

       
        public int UniqueClassNum { get; set; }

        public Students(string name, int uniqueClassNum, string details = null) :base(name, details)
        {
            
            this.UniqueClassNum = uniqueClassNum;
        }

    }
}
