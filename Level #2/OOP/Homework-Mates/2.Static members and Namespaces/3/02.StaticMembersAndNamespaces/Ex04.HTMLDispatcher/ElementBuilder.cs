namespace Ex04.HTMLDispatcher
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ElementBuilder
    {
        private StringBuilder firstElement = new StringBuilder();
        private StringBuilder secondElement = new StringBuilder();
        private StringBuilder thirdElement = new StringBuilder();

        public ElementBuilder(string elementType)
        {
            this.firstElement.Append("<");
            this.firstElement.Append(elementType + " ");
            this.secondElement.Append(">");
            this.thirdElement.Append("</" + elementType + ">");
        }

        public static StringBuilder operator *(ElementBuilder c1, int x)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < x; i++)
            {
                result.Append(c1);
            }

            return result;
        }

        public void AddAttribute(string attribute, string value)
        {
            this.firstElement.Append(attribute + "=\"" + value + "\" ");
        }

        public void AddContent(string value)
        {
            this.secondElement.Append(value);
        }

        public string Result(bool allTags)
        {
            StringBuilder result = new StringBuilder();
            this.firstElement = this.firstElement.Remove(this.firstElement.Length - 1, 1); // remove empty space

            if (allTags)
            {
                result.Append(this.firstElement);
                result.Append(this.secondElement);
                result.Append(this.thirdElement);
                return result.ToString();
            }
            else
            {
                result.Append(this.firstElement);
                result.Append(this.secondElement);
                return result.ToString();
            }
        }

        public override string ToString()
        {
            return this.Result(true);
        }
    }
}