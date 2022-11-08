// See https://aka.ms/new-console-template for more information
using Abstraction;
using Microsoft.VisualBasic;

Console.WriteLine("Transiction doing SBI bank");

var sbi = BAnkFactory.GetBankObject("SBI");



sbi.BankTransfer();
sbi.MiniStatement();
sbi.CheckBalanace();
sbi.WithdrawMoney();
sbi.ValidateCard();



Console.WriteLine("\nTransaction doing AXIX Bank");

var AXIX = BAnkFactory.GetBankObject("AXIX"); 

AXIX.ValidateCard();
AXIX.WithdrawMoney();
AXIX.CheckBalanace();
AXIX.BankTransfer();
AXIX.MiniStatement();
Console.ReadLine();










