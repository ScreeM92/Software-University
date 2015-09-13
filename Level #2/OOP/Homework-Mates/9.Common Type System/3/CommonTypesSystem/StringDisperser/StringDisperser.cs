using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class StringDisperser : IEnumerable<char>, IComparable<StringDisperser>, ICloneable
    {
        public StringDisperser(params string[] strings)
        {
            this.Strings = strings;
        }

        private string[] strings;

        public string[] Strings
        {
            get
            {
                return this.strings;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Strings", "Value cannot be null");
                }
                this.strings = value;
            }
        }

        public IEnumerator<char> GetEnumerator()
        {
            string strings = string.Join("", this.Strings);
            foreach (char c in strings)
            {
                yield return c;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override bool Equals(object obj)
        {
            StringDisperser secondDisperser = (StringDisperser)obj;
            if (secondDisperser == null)
            {
                return false;
            }
            if (!(secondDisperser.Strings.Equals(this.Strings)))
            {
                return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            return this.Strings.GetHashCode() ^ this.ToString().GetHashCode();
        }
        public override string ToString()
        {
            return string.Join(", ", this.Strings);
        }

        public static bool operator ==(StringDisperser first, StringDisperser second)
        {
            return StringDisperser.Equals(first, second);
        }

        public static bool operator !=(StringDisperser first, StringDisperser second)
        {
            return !(StringDisperser.Equals(first, second));
        }

        public object Clone()
        {
            return this.CloneStringDispenser();
        }

        public StringDisperser CloneStringDispenser()
        {
            List<string> strings = new List<string>();
            foreach (var str in this.Strings)
            {
                strings.Add(str);
            }
            return new StringDisperser(strings.ToArray());
        }

        public int CompareTo(StringDisperser otherDisperser)
        {
            string strings = string.Join("", this.Strings);
            string otherStrings = string.Join("", otherDisperser.Strings);
            if (string.Compare(strings, otherStrings) > 0)
            {
                return 1;
            }
            else if (string.Compare(strings, otherStrings) == 0)
            {
                return 0;
            }
            return -1;
        }
    }
  

