using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructurePrograms
{
    class PrimeNumbersRange
    {
        //Initialising array members
        public static int r = 0, ind = 0;
        // 2d - Array for prime numbers 
        public int[,] primeNumbers = new int[10, 100];
        public int[,] AnagramNumbers = new int[10, 100];
        public int[,] notAnagramNumbers = new int[10, 100];

        /// <summary>
        /// Find prime in range
        /// </summary>
        public void FindPrimeInRange()
        {
            int start = 0, end = 1000, count = 0;
            
            for (int i = start + 1; i <= end; i++)
            {
                if(count > 100)
                {
                    count = 0;
                    ind = 0;
                    r++;
                }
               
                if (FindPrime(i))
                {
                    primeNumbers[r, ind] = i;
                    ind++;
                }
                count++;
            }
            Console.WriteLine("Prime numbers in range");
            Print(primeNumbers);
            FindAnagram();
            Console.WriteLine("Anagram numbers in range");
            Print(AnagramNumbers);
            Console.WriteLine("Not Anagram numbers in range");
            Print(notAnagramNumbers);
        }

        /// <summary>
        /// Print the ARRAY
        /// </summary>
        public void Print(int[,] twoDArray)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    if (twoDArray[i, j] != 0)
                    {
                        Console.WriteLine(twoDArray[i, j]);
                    }
                }
                Console.WriteLine("***************************************************");
            }
        }

        public void FindAnagram()
        {
            int ind = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    if (primeNumbers[i, j] != 0 && primeNumbers[i, j] > 10)
                    {
                        char[] charArr = primeNumbers[i, j].ToString().ToCharArray();
                        Array.Sort(charArr);
                        string str1 = new String(charArr);
                        int firstNum = Convert.ToInt32(str1);
                        int secondNum = 0,k;
                        for(k = j + 1; k < 100; k++)
                        {
                            char[] charArr1 = primeNumbers[i, k].ToString().ToCharArray();
                            Array.Sort(charArr1);
                            string str2 = new String(charArr1);
                            secondNum = Convert.ToInt32(str2);
                            if (firstNum == secondNum)
                            {
                                break;
                            }
                        }
                        if (firstNum == secondNum)
                        {
                            AnagramNumbers[i, ind++] = primeNumbers[i, j];
                            AnagramNumbers[i, ind++] = primeNumbers[i, k];

                        }
                       
                    }
                }
               
            }
            int flag;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    flag = 0;
                    if (primeNumbers[i, j] != 0)
                    {
                        for (int p = 0; p < 10 && flag!=1; p++)
                        {
                            for(int q = 0; q < 100; q++)
                            {
                                if (primeNumbers[i, j] == AnagramNumbers[p, q])
                                {
                                    flag = 1;
                                    break;
                                }
                            }
                        }
                        if (flag == 0)
                        {
                            notAnagramNumbers[i, j] = primeNumbers[i, j];
                            
                        }
                    }
                }
                
            }


        }
        /// <summary>
        /// Find number whether prime or not
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public bool FindPrime(int i)
        {
            bool isPrime = false;
                if (i == 1)
                {
                    isPrime = false;
                }
                else if (i == 2)
                {
                    isPrime = true;
                }
                else if (i % 2 != 0)
                {
                    int f = 0;
                    for (int j = 3; j * j <= i; j++)
                    {
                        if (i % j == 0)
                        {
                            f = 1;
                            break;
                        }
                    }
                    if (f != 1)
                    {
                    isPrime = true;
                    }
                }
            return isPrime;
         }
    }
}
