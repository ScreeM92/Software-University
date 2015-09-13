﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer
{
    public class Customer: ICloneable, IComparable<Customer>
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private string id;
        private string permanentAddress;
        private string mobilePhone;
        private string email;
        private IList<Payment> payments;
        private CustomerType type;

        public Customer(string firstName, string middleName, string lastName, string id,
                        string permanentAddress, string mobilePhone, string email,
                        IList<Payment> payments, CustomerType type)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Id = id;
            this.PermanentAddress = permanentAddress;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Payments = payments;
            this.Type = type;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                Utilities.ValidateString(value, "First name");
                this.firstName = value;
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
                Utilities.ValidateString(value, "Middle name");
                this.middleName = value;
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
                Utilities.ValidateString(value, "Last name");
                this.lastName = value;
            }
        }

        public string Id
        {
            get
            {
                return this.id;
            }
            set
            {
                Utilities.ValidateString(value, "ID");
                this.id = value;
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
                Utilities.ValidateString(value, "Permanent address");
                this.permanentAddress = value;
            }
        }

        public string MobilePhone
        {
            get
            {
                return this.mobilePhone;
            }
            set
            {
                Utilities.ValidateString(value, "Mobile phone");
                this.mobilePhone = value;
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
                Utilities.ValidateString(value, "Email");
                this.email = value;
            }
        }

        public IList<Payment> Payments
        {
            get
            {
                return this.payments;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Payments", "Value cannot be null");
                }
                this.payments = value;
            }
        }

        public CustomerType Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        public override int GetHashCode()
        {
            string hashCode = this.FirstName + this.LastName + this.MiddleName + this.Id;
            return hashCode.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Customer customer = obj as Customer;
            // check obj is customer 
            if (customer == null)
            {
                return false;
            }

            if (this.Id == customer.Id)
            {
                return true;
            }

            return false;
        }

        public static bool operator ==(Customer customer, Customer otherCustomer)
        {
            return Object.Equals(customer, otherCustomer);
        }

        public static bool operator !=(Customer customer, Customer otherCustomer)
        {
            return !Object.Equals(customer, otherCustomer);
        }

        public object Clone()
        {
            Customer newCustomer = this.MemberwiseClone() as Customer;
            if (newCustomer == null)
            {
                throw new ArgumentNullException("Object can't be casted to customer type!");
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
            string thisFullName = string.Format("{0} {1} {2}", this.FirstName, this.MiddleName, this.LastName);
            string otherFullName = string.Format("{0} {1} {2}", other.FirstName, other.MiddleName, other.LastName);

            if (thisFullName.CompareTo(otherFullName) != 0)
            {
                return thisFullName.CompareTo(otherFullName);
            }
            else
            {
                return this.Id.CompareTo(other.Id);
            }
        }

        public override string ToString()
        {
            string customeTorString = string.Format(
                "ID: {0}, Name: {1} {2}, \npayments: \n{3}",
                this.Id,
                this.FirstName,
                this.LastName,
                string.Join("", this.Payments));

            return customeTorString;
        }
    }
}
