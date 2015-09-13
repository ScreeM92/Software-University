using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _02.StringDisperser
{
    public class StringDisperser : ICloneable, IEnumerable<char>, IComparable<StringDisperser>
    {
        private StringBuilder totalString;
        public StringDisperser(params string[] strings) 
        {
            this.totalString = new StringBuilder();
            foreach (var str in strings)
            {
                this.totalString.Append(str);
            }
        }

        public StringBuilder TotalString
        {
            get
            {
                return this.totalString;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("TotalString cannot be a null field!");
                }
                this.totalString = value;
            }
        }

        public override string ToString()
        {
            return this.TotalString.ToString() ;
        }

        public override bool Equals(object obj)
        {
            StringDisperser stringDisperser = obj as StringDisperser;
            if (stringDisperser == null)
            {
                return false;
            }
            return this.TotalString.ToString().Equals(stringDisperser.TotalString.ToString());
        }

        public static bool operator == (StringDisperser first, StringDisperser second)
        {
            return Object.Equals(first, second);
        }

        public static bool operator != (StringDisperser first, StringDisperser second)
        {
            return !Object.Equals(first, second);
        }

        public override int GetHashCode()
        {
            return this.TotalString.GetHashCode();
        }

        public object Clone()
        {
            StringDisperser newStringDisperser = this.MemberwiseClone() as StringDisperser;
            if (null == newStringDisperser)
            {
                throw new ArgumentNullException("Object can not be casted to type StringDisperser!");
            }

            newStringDisperser.TotalString = new StringBuilder().Append(this.TotalString.ToString());

            return newStringDisperser;
        }

        public int CompareTo(StringDisperser other)
        {
            return this.TotalString.ToString().CompareTo(other.TotalString.ToString());
        }

        public IEnumerator<char> GetEnumerator()
        {
            for (int i = 0; i < this.TotalString.Length; i++)
            {
                yield return this.TotalString[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
