namespace _02_BankOfKurtovoKonare
{
    public class IndividualCustomer : Customer, ICustomer
    {
        public IndividualCustomer(string name)
            : base(name)
        {
            this.Name = name;
        }
    }
}
