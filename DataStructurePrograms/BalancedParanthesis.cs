using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructurePrograms
{
    class BalancedParanthesis<T> where T:IComparable
    {
        //initialising top node
        Node<T> top;

        //Method for performing operation
        public void CheckParanthesis()
        {
            //expression
            string Expression = "((5+6)";
            //convert it to string
            char[] expArray = Expression.ToCharArray();

            foreach(char i in expArray)
            {
                Console.WriteLine(i);
                if (i == '(')
                {
                    T x = (T)Convert.ChangeType(i, typeof(T));
                    //push into stack
                    Push(x);
                    Display();
                }
                else if (i == ')')
                {
                    //pop from stact
                    Pop();
                    Display();
                }
            }
            //validation whether expression is valid or not
           if(Size() > 0)
            {
                Console.WriteLine("Un Balanced Expression");
            }
            else
            {
                Console.WriteLine("Balanced Expression");
            }

        }

        //Method to push data
        public void Push(T data)
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

        //method to retreive top element of stack
        public void Peek()
        {
            if (this.top == null)
            {
                Console.WriteLine("Stack doesn't contains any value");
            }
            else
            {
                Console.WriteLine($"Top element of stack is {this.top.data}");
            }
        }
        //Method to retreive and remove top element of stack
        public void Pop()
        {
            if (this.top == null)
            {
                Console.WriteLine("Stack doesn't contains any value");
            }
            else
            {

                Console.WriteLine($"Popped element => {top.data}");
                top = top.next;
            }
        }
        //Display STack
        public void Display()
        {
            Node<T> temp = this.top;
            while (temp != null)
            {
                Console.WriteLine($"|__{temp.data}__|");
                temp = temp.next;
            }
        }
        public int Size()
        {
            int count = 0;
            Node<T> temp = this.top;
            while (temp != null)
            {
                count++;
                temp = temp.next;
            }
            return count;
        }
    }
}
