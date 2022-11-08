using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    internal class AXIX : IBank
    {
        public void BankTransfer()
        {
            Console.WriteLine("AXIX Bank Bank Transfer");
        }
        public void CheckBalanace()
        {
            Console.WriteLine("AXIX Bank Check Balanace");
        }
        public void MiniStatement()
        {
            Console.WriteLine("AXIX Bank Mini Statement");
        }
        public void ValidateCard()
        {
            Console.WriteLine("AXIX Bank Validate Card");
        }
        public void WithdrawMoney()
        {
            Console.WriteLine("AXIX Bank Withdraw Money");
        }

    }
}
