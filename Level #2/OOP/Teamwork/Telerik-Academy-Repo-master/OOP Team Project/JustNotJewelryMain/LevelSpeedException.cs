using System;
using System.Linq;

namespace JustNotJewelryMain
{
    public class LevelSpeedException : ApplicationException
    {
        public LevelSpeedException() : base() { }
        public LevelSpeedException(string message) : base(message) { }
        public LevelSpeedException(string message, Exception e) : base(message, e) { }

        private string strInfo;
        public string ErrorInfo
        {
            get
            {
                return strInfo;
            }

            set
            {
                strInfo = value;
            }
        }
    }
}
