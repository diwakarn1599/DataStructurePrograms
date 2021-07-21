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
        public T[,] primeNumbers = new T[10, 100];
        public T[,] AnagramNumbers = new T[10, 100];
        public T[,] notAnagramNumbers = new T[10, 100];
        Node<T> top = null;
        Node<T> front;
        Node<T> rear;
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
                    primeNumbers[r, ind] = (T)Convert.ChangeType(i, typeof(T));
                    ind++;
                }
                count++;
            }
            //Console.WriteLine("Prime numbers in range");
            //Print(primeNumbers);
            FindAnagram();
            Console.WriteLine("Anagram numbers in range");
            Print(AnagramNumbers);
            //Console.WriteLine("Anagrams in reverse order");
            //DisplayList();
            Console.WriteLine("Anagrams in Queue order");
            DisplayQueue();

        }

        /// <summary>
        /// Print the ARRAY
        /// </summary>
        public void Print(T[,] twoDArray)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    if (twoDArray[i, j].CompareTo((T)Convert.ChangeType(0, typeof(T)))> 0)
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
                    if (primeNumbers[i, j].CompareTo((T)Convert.ChangeType(0, typeof(T))) > 0)
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
                            //Insert(primeNumbers[i, j]);
                            //Insert(primeNumbers[i, k]);
                            Enqueue(primeNumbers[i, j]);
                            Enqueue(primeNumbers[i, k]);

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
                    if (primeNumbers[i, j].CompareTo((T)Convert.ChangeType(0, typeof(T)))>0)
                    {
                        for (int p = 0; p < 10 && flag!=1; p++)
                        {
                            for(int q = 0; q < 100; q++)
                            {
                                if (primeNumbers[i, j].CompareTo(AnagramNumbers[p, q])==0)
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

        /// <summary>
        /// insert into stack
        /// </summary>
        /// <param name="data"></param>
        public void Insert(T data)
        {
            Node<T> temp = new Node<T>(data);
            if (this.top == null)
            {
                temp.next = null;
            }
            else
            {
                temp.next = this.top;
            }
            this.top = temp;
        }
        /// <summary>
        /// display stack
        /// </summary>
        public void DisplayList()
        {
            Node<T> temp = this.top;
            while (temp != null)
            {
                Console.WriteLine($"|__{temp.data}__|");
                temp = temp.next;
            }
        }
        /// <summary>
        /// insert into queue
        /// </summary>
        /// <param name="val"></param>
        public void Enqueue(T val)
        {
            Node<T> temp = new Node<T>(val);
            if (this.front == null)
            {

                this.front = temp;
                this.rear = temp;
                temp.next = null;
            }
            else
            {
                this.rear.next = temp;
                this.rear = temp;
            }
        }
        /// <summary>
        /// display queue
        /// </summary>
        public void DisplayQueue()
        {
            Console.WriteLine("\n");
            Node<T> temp = this.front;
            while (temp != null)
            {
                Console.Write($"|__{temp.data}__|");
                temp = temp.next;
            }
        }
    }
}
