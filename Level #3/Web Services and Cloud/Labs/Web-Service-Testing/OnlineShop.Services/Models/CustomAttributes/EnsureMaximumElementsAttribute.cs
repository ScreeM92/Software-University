namespace OnlineShop.Services.Models.CustomAttributes
{
    using System.Collections;
    using System.ComponentModel.DataAnnotations;

    public class EnsureMaximumElementsAttribute : ValidationAttribute
    {
        private readonly int _maxElements;
        public EnsureMaximumElementsAttribute(int maxElements)
        {
            this._maxElements = maxElements;
        }

        public override bool IsValid(object value)
        {
            var list = value as IList;
            if (list != null)
            {
                return list.Count <= this._maxElements;
            }
            return false;
        }
    }
}