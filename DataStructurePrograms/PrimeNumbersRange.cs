using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructurePrograms
{
    class PrimeNumbersRange<T> where T:IComparable
    {
        //Initialising array members
        public static int r = 0, ind = 0;
        // 2d - Array for prime numbers 
        public int[,] primeNumbers = new int[10, 100];

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
           
        }

        /// <summary>
        /// Print the ARRAY
        /// </summary>
        public void Print()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    if (primeNumbers[i, j] != 0)
                    {
                        Console.WriteLine(primeNumbers[i, j]);
                    }
                }
                Console.WriteLine("***************************************************");
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
