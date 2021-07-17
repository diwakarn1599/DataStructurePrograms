using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructurePrograms
{
    class BankingCashCounter<T> where T:IComparable
    {
        //Initialising front an rear of queue
        Node<T> front;
        Node<T> rear;
        int balance = 10000;

        //Methid for performing cash Counter operations
        public void CashCounter()
        {
            //list of persons to insert into the queue
            List<string> persons = new List<string> {"Person1", "Person2", "Person3", "Person4", "Person5" };
            foreach(string i in persons)
            {
                T x = (T)Convert.ChangeType(i, typeof(T));
                //insert into queue
                Enqueue(x);
            }
            //display queue after insertion
            Display();
            while (Size() > 0)
            {
                //while size of queue greater than 0 perform operation
                Operation();
                Display();
            }

        }
        public void Operation()
        {
            //ask user whether he needs to deposit or withdraw
            Console.WriteLine("\n1.Deposit\n2.Withdraw\n3.Exit\n4.Enter your option");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                //case for deposit
                case 1:
                    Console.WriteLine("Enter Amount to Deposit");
                    int amount = Convert.ToInt32(Console.ReadLine());
                    this.balance += amount;
                    Console.WriteLine($"Deposited {amount} to the bank");
                    Console.WriteLine($"Total Bank Balance --> {this.balance}");
                    //remove person from the queue after his operation performed
                    Dequeue();
                    break;
                //case for withdraw
                case 2:
                    
                    int amountWithdraw;
                    while (true)
                    {
                        Console.WriteLine("Enter Amount to Withdraw");
                        amountWithdraw = Convert.ToInt32(Console.ReadLine());
                        //Check whether balance is present or not
                        if (amountWithdraw > this.balance)
                        {
                            Console.WriteLine("Not Enough Money present");
                        }
                        else
                        {
                            this.balance -= amountWithdraw;
                            break;
                        }
                    }
                    Console.WriteLine($" Withdrawed {amountWithdraw} from the bank");
                    Console.WriteLine($"Total Bank Balance --> {this.balance}");
                    //remove person from the queue after his operation performed
                    Dequeue();
                    break;
                case 3:
                    //remove person from the queue if he wants to exit
                    Dequeue();
                    break;
            }
        }


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

        public void Dequeue()
        {
            if (this.front == null)
            {
                Console.WriteLine("Queue is Empty");
                return;
            }
            else
            {

                this.front = this.front.next;
                return;
            }

        }


        public void Display()
        {
            Console.WriteLine("\n");
            Node<T> temp = this.front;
            while (temp != null)
            {
                Console.Write($"|__{temp.data}__|");
                temp = temp.next;
            }
        }
        public int Size()
        {
            int count = 0;
            Node<T> temp = this.front;
            while (temp != null)
            {
                count++;
                temp = temp.next;
            }
            return count;
        }
    }
}
