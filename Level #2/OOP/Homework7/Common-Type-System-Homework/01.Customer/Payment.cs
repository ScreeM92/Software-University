class Payment
{
    private string productName;
    private decimal productPrice;
    public Payment(string productName, decimal productPrice)
    {
        this.ProductName = productName;
        this.ProductPrice = ProductPrice;
    }

    public string ProductName 
    { 
        get
        {
            return this.productName;
        }
        set
        {
            if (Validation.IsValidString(value))
            {
                this.productName = value;
            }
        }
    }

    public decimal ProductPrice 
    {
        get
        {
            return this.productPrice;
        }
        set
        {
             //if (Validation.IsValidDecimal(value))
             //{
                this.productPrice = value;
            // }
        }
    }
    public override string ToString()
    {
        return base.ToString() + string.Format("Product name : {1}\nProduct price : {2}", this.productName, this.productPrice);
    }
}