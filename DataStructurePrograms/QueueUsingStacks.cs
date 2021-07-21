using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructurePrograms
{
    class QueueUsingStacks<T> where T:IComparable
    {
        Node<T> topStackOne = null;
        Node<T> topStackTwo = null;

        /// <summary>
        /// Enqueue via stack 1 ----Dequeue via stack 2
        /// </summary>
        /// <param name="number"></param>
        public void Enqueue(int number)
        {
            // Push elements into stack
            PushFirstStack((T)Convert.ChangeType(10, typeof(T)));
            PushFirstStack((T)Convert.ChangeType(20, typeof(T)));
            PushFirstStack((T)Convert.ChangeType(30, typeof(T)));
            for (int i = 0; i < number; i++)
            {
                AddFirstStackToSecond(this.topStackOne);

            }
            Display();

        }
        /// <summary>
        /// dequeue 
        /// </summary>
        /// <param name="number"></param>
        public void Dequeue(int number)
        {
            for (int i = 0; i < number; i++)
            {
                Pop();

            }


        }
        /// <summary>
        /// push elements into first stack
        /// </summary>
        /// <param name="data"></param>
        public void PushFirstStack(T data)
        {
            Node<T> newNode = new Node<T>(data);
            if (this.topStackOne == null)
            {
                newNode.next = null;
            }
            else
            {
                newNode.next = this.topStackOne;
            }
            this.topStackOne = newNode;
        }

        /// <summary>
        /// add first stack to second stack
        /// </summary>
        /// <param name="top"></param>
        public void AddFirstStackToSecond(Node<T> top)
        {
            if (this.topStackOne == null)
            {
                Console.WriteLine("Empty Stack");
                return;
            }
            else
            {
                PushSecondStack(this.topStackOne.data);
            }
            this.topStackOne = this.topStackOne.next;
        }


        /// <summary>
        /// push elements to second stack
        /// </summary>
        /// <param name="data"></param>
        public void PushSecondStack(T data)
        {
            Node<T> newNode = new Node<T>(data);
            if (this.topStackTwo == null)
            {
                newNode.next = null;
            }
            else
            {
                newNode.next = this.topStackTwo;
            }
            this.topStackTwo = newNode;
        }
        /// <summary>
        /// pop from stack
        /// </summary>
        public void Pop()
        {
            if (this.topStackTwo == null)
            {
                Console.WriteLine("Empty Stack");
                return;
            }
            else
            {
                Console.WriteLine("Poped Queue " + this.topStackTwo.data);
            }
            this.topStackTwo = this.topStackTwo.next;
        }


        /// <summary>
        /// Display queue
        /// </summary>
        public void Display()
        {
            Node<T> temp = this.topStackTwo;
            while (temp != null)
            {
                Console.Write($"|__{temp.data}__|");
                temp = temp.next;
            }
            Console.WriteLine(" ");
        }



    }
}
