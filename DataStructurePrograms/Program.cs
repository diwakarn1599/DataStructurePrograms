﻿using System;

namespace DataStructurePrograms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Data Structure Programs");
            Console.WriteLine("*******************MENU*******************");
            Console.WriteLine("1.Unordered List\n2.Ordered List\n3.Balanced Paranthesis\n4.Cash Counter\n5.Palindrome Checker\n6.Hashing Slots\n7.Prime Number in Range\n8.Exit\nEnter Your Option");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    UnOrderedList<string> ul = new UnOrderedList<string>();
                    ul.UnorderList();
                    break;
                case 2:
                    UnOrderedList<int> ol = new UnOrderedList<int>();
                    ol.OrderList();
                    break;
                case 3:
                    BalancedParanthesis<char> bp = new BalancedParanthesis<char>();
                    bp.CheckParanthesis();
                    break;
                case 4:
                    BankingCashCounter<string> bcc = new BankingCashCounter<string>();
                    bcc.CashCounter();
                    break;
                case 5:
                    PalindromeChecker<char> pc = new PalindromeChecker<char>();
                    pc.CheckPalindrome();
                    break;
                case 6:
                    Console.WriteLine("Hashing SLots");
                    HashingSlots<string> hs = new HashingSlots<string>();
                    hs.CheckNumber();
                    break;
                case 7:
                    PrimeNumbersRange pnr = new PrimeNumbersRange();
                    pnr.FindPrimeInRange();
                    break;
                case 8:
                    Console.WriteLine("Exited");
                    break;
            }
           
            
        }
    }
}
