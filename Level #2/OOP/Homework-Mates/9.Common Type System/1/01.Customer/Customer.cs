using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Customer
{
    class Customer : ICloneable, IComparable<Customer>
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private long id;
        private string permanentAddress;
        private string mobilePhone;
        private string email;
        private List<Payment> payments;
        private CustomerType type;

        public Customer(string firstName, string middleName, string lastName, long id, string permanentAddress, 
            string mobilePhone, string email, List<Payment> payments, CustomerType type) 
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.ID = id;
            this.PermanentAddress = permanentAddress;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Payments = payments;
            this.type = type;

        }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public long ID { get; set; }
        public string PermanentAddress { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public IList<Payment> Payments { get; private set; }
        public CustomerType Type { get; private set; }

        public override int GetHashCode()
        {
            string hashCode = this.FirstName + this.LastName + this.MiddleName + this.ID;
            return hashCode.GetHashCode();
        }

        public override string ToString()
        {
            string customerString = string.Format(
                "ID: {0}, Name: {1} {2}, payments: {3}",
                this.ID,
                this.FirstName,
                this.LastName,
                string.Join(", ", this.Payments));

            return customerString;
        }

        public override bool Equals(object obj)
        {
            Customer customer = obj as Customer;
            if (customer == null)
            {
                return false;
            }

            if (customer.ID == this.ID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator == (Customer firstCustomer, Customer secondCustomer)
        {
            return Object.Equals(firstCustomer, secondCustomer);
        }

        public static bool operator !=(Customer firstCustomer, Customer secondCustomer)
        {
            return !Object.Equals(firstCustomer, secondCustomer);
        }

        public object Clone()
        {
            Customer newCustomer = this.MemberwiseClone() as Customer;
            if (null == newCustomer)
            {
                throw new ArgumentNullException("Object can not be casted to type Customer!");
            }

            newCustomer.Payments = new List<Payment>(this.Payments.Count);
            foreach (var payment in this.Payments)
            {
                newCustomer.Payments.Add(payment.Clone() as Payment);
            }

            return newCustomer;
        }

        public int CompareTo(Customer other)
        {
            string thisFullName = this.FirstName + " " + this.MiddleName + " " + this.LastName;
            string otherFullName = other.FirstName + " " + other.MiddleName + " " + other.LastName;

            if (thisFullName.CompareTo(otherFullName) != 0)
            {
                return thisFullName.CompareTo(otherFullName);
            }
            else
            {
                return this.ID.CompareTo(other.ID);
            }
        }
    }
}
