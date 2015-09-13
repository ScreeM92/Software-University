using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    public interface IAccountable
    {
        decimal DepositMoney(decimal money);

        void WithdrawMoney(decimal money);

        decimal CalculateInterestRate(int months);
    }
}
