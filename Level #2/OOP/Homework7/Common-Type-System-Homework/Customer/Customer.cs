using System;
using System.Collections.Generic;

class Customer
{
    //first name, middle name and last name, ID (EGN), permanent address, mobile phone, e-mail, list of payments and customer type. 
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public int ID { get; set; }
    public string PermanentAddress { get; set; }
    public string MobilePhone { get; set; }
    public string Email { get; set; }
    public IList<Payment> payments { get; set; }
    public CustomerType type { get; set; }

    public Customer(string firstname, string middlename, string lastname, int id, string permanentaddress, string mobilephone, string email)
    {
        this.FirstName = firstname;
        this.MiddleName = middlename;
        this.LastName = lastname;
        this.ID = id;
        this.PermanentAddress = permanentaddress;
        this.MobilePhone = mobilephone;
        this.Email = email;
        this.payments = new List<Payment>();
    }

    public void AddPayment(Payment payment)
    {
        this.payments.Add(payment);

        var paymentsCount = this.payments.Count;

        if (paymentsCount == 1)
        {
            this.type = CustomerType.OneTime;
        }
        if (paymentsCount > 1 && paymentsCount <= 3)
        {
            this.type = CustomerType.Regular;
        }
        if (paymentsCount > 3 && paymentsCount <= 5)
        {
            this.type = CustomerType.Golden;
        }
        if (paymentsCount > 5)
        {
            this.type = CustomerType.Diamond;
        }
    }

     private bool Equals(Customer other)
    {
        return string.Equals(this.FirstName, other.FirstName) && string.Equals(this.MiddleName, other.MiddleName) && string.Equals(this.LastName, other.LastName)
            && string.Equals(this.ID, other.ID);
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
        return Equals((Customer) obj);
    }

    public override string ToString()
    {
        return string.Format("Firstname : {0}\nMiddlename : {1}\nLastname : {2}\nID : {3}\nPhone number : {4}\nAddress : {5}\nEmail : {6}\n{7}"
            , this.FirstName, this.MiddleName, this.LastName, this.ID, this.MobilePhone, this.PermanentAddress, this.Email, payments);
    }

    public override int GetHashCode()
    {
        int hashCode = this.FirstName.GetHashCode() +
            this.MiddleName.GetHashCode() +
            this.LastName.GetHashCode() +
            this.ID.GetHashCode() +
            (this.PermanentAddress ?? "").GetHashCode() +
            (this.MobilePhone ?? "").GetHashCode() +
            (this.Email ?? "").GetHashCode() +
            this.payments.GetHashCode() +
            this.type.GetHashCode();

        return hashCode;
    }

   public static bool operator == (Customer one, Customer two)
   {
       return one.FirstName == two.FirstName && one.MiddleName == two.MiddleName && one.LastName == two.LastName && one.ID == two.ID;
   }

   public static bool operator !=(Customer one, Customer two)
   {
        return one.FirstName != two.FirstName || one.MiddleName != two.MiddleName || one.LastName != two.LastName || one.ID != two.ID;
   }

   public object Clone()
   {
       var cloning = new Customer(this.FirstName, this.MiddleName, this.LastName, this.ID, this.PermanentAddress, this.MobilePhone, this.Email);

       cloning.payments = new List<Payment>();

       foreach (var payment in this.payments)
       {
           cloning.payments.Add(new Payment(payment.ProductName, payment.Price));
       }

       cloning.type = this.type;

       return cloning;
   }

   public int CompareTo(Customer other)
   {
       string first = this.ToString();
       string second = other.ToString();
       if (first.CompareTo(other) == 0)
       {
           return this.ID.CompareTo(other.ID);
       }
       return first.CompareTo(other);
   }
}