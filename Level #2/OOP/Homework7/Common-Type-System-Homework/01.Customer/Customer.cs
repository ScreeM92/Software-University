using System.Collections.Generic;
class Customer
{
    private string firstName;
    private string middleName;
    private string lastName;
    private string id;
    private string permanentAddress;
    private string phoneNumber;
    private string email;
    private List<Payment> payments;
    public Customer(string firstName, string middleName, string lastName, string id, string permanentAddress,
        string phoneNumber, string email)
    {
        this.FirstName = firstName;
        this.MiddleName = middleName;
        this.LastName = lastName;
        this.ID = id;
        this.PermanentAddress = permanentAddress;
        this.PhoneNumber = phoneNumber;
        this.Email = email;
        this.Payments = new List<Payment>();
    }
    public string FirstName
    {
        get
        {
            return this.firstName;
        }
        set
        {
            if (Validation.IsValidString(value))
            {
                this.firstName = value;
            }
        }
    }

    public string MiddleName
    {
        get
        {
            return this.middleName;
        }
        set
        {
            if (Validation.IsValidString(value))
            {
                this.middleName = value;
            }
        }
    }

    public string LastName
    {
        get
        {
            return this.lastName;
        }
        set
        {
            if (Validation.IsValidString(value))
            {
                this.lastName = value;
            }
        }
    }

    public string ID
    {
        get
        {
            return this.id;
        }
        set
        {
            if (Validation.IsValidString(value))
            {
                this.id = value;
            }
        }
    }

    public string PermanentAddress
    {
        get
        {
            return this.permanentAddress;
        }
        set
        {
            if (Validation.IsValidString(value))
            {
                this.permanentAddress = value;
            }
        }
    }

    public string PhoneNumber
    {
        get
        {
            return this.phoneNumber;
        }
        set
        {
            if (Validation.IsValidString(value))
            {
                this.phoneNumber = value;
            }
        }
    }

    public string Email
    {
        get
        {
            return this.email;
        }
        set
        {
            if (Validation.IsValidString(value))
            {
                this.email = value;
            }
        }
    }

    public List<Payment> Payments
    {
        get
        {
            return this.payments;
        }
        set
        {
            this.payments = value;
        }
    }
    public CustomerType CustomerType { get; set; }
    public void AddPayment(Payment payment)
    {
        this.Payments.Add(payment);
        var paymetsCount = this.Payments.Count;
        if (paymetsCount <= 1)
        {
            this.CustomerType = CustomerType.OneTime;
        }

        if (paymetsCount >= 2)
        {
            this.CustomerType = CustomerType.Regular;
        }

        if (paymetsCount >= 5)
        {
            this.CustomerType = CustomerType.Golden;
        }

        if (paymetsCount >= 8)
        {
            this.CustomerType = CustomerType.Diamond;
        }
    }
    private bool Equals(Customer other)
    {
        return string.Equals(FirstName, other.FirstName) && string.Equals(MiddleName, other.MiddleName) &&
            string.Equals(LastName, other.LastName) && string.Equals(ID, other.ID);
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
        {
            return false;
        }
        if (obj.GetType() != this.GetType())
        {
            return false;
        }
        return Equals((Customer)obj);
    }
    public override int GetHashCode()
    {
        int hashCode = this.FirstName.GetHashCode() +
            this.MiddleName.GetHashCode() +
            this.LastName.GetHashCode() +
            this.ID.GetHashCode() +
            (this.PermanentAddress ?? "").GetHashCode() +
            (this.PhoneNumber ?? "").GetHashCode() +
            (this.Email ?? "").GetHashCode() +
            this.Payments.GetHashCode() +
            this.CustomerType.GetHashCode();

        return hashCode;
    }
    public static bool operator ==(Customer first, Customer second)
    {
        return first.firstName == second.firstName && first.middleName == second.middleName && first.lastName == second.lastName &&
            first.id == second.id;
    }
    public static bool operator !=(Customer first, Customer second)
    {
        return first.firstName != second.firstName || first.middleName != second.middleName || first.lastName != second.LastName ||
            first.id != second.id;
    }
    public override string ToString()
    {
        return string.Format("Firstname : {0}\nMiddlename : {1}\nLastname : {2}\nID : {3}\nPhone number : {4}\nAddress : {5}\nEmail : {6}\n{7}"
            , this.firstName, this.middleName, this.lastName, this.id, this.phoneNumber, this.permanentAddress, this.email, Payments);
    }
    public object Clone()
        {
            var cloning = new Customer(this.FirstName, this.MiddleName, this.LastName,
            this.ID, this.PermanentAddress, this.Email, this.PhoneNumber);

            cloning.Payments = new List<Payment>();
            foreach (var payment in this.Payments)
            {
                cloning.Payments.Add(new Payment(payment.ProductName, payment.ProductPrice));
            }
            cloning.CustomerType = this.CustomerType;

            return cloning;
        }
    public int CompareTo(Customer other)
        {
            string fullNameThisCustomer = this.ToString();
            string fullNameOtherCustomer = other.ToString();
            if (fullNameThisCustomer.CompareTo(fullNameOtherCustomer) == 0)
            {
                return this.ID.CompareTo(other.ID);
            }
            return fullNameThisCustomer.CompareTo(fullNameOtherCustomer);
        }
}