using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    internal class SBI : IBank
    {
        public void BankTransfer()
        {
            Console.WriteLine("SBI Bank Bank Transfer");
        }
        public void CheckBalanace()
        {
            Console.WriteLine("SBI Bank Check Balanace");
        }
        public void MiniStatement()
        {
            Console.WriteLine("SBI Bank Mini Statement");
        }
        public void ValidateCard()
        {
            Console.WriteLine("SBI Bank Validate Card");
        }
        public void WithdrawMoney()
        {
            Console.WriteLine("SBI Bank Withdraw Money");
        }

    }
}
