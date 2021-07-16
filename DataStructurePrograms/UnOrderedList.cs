using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace DataStructurePrograms
{
    public class UnOrderedList<T> where T:IComparable
    {
        Node<T> head;

        public void UnorderList()
        {
            string filePath = @"C:\Users\NARD'S IDEAPAD\source\repos\DataStructurePrograms\DataStructurePrograms\Listitems.txt";
            string fileContents = File.ReadAllText(filePath);
            string[] fileList = fileContents.Split(" ");
            
            foreach(string i in fileList)
            {
                T x = (T)Convert.ChangeType(i, typeof(T));
                InsertAtLast(x);
            }
            Console.WriteLine("************ADDED ALL ELEMENTS************");

            
            Console.WriteLine("The content in the list is\n");
            Display();
            Console.WriteLine("\nEnter the word need to be searched in file:");
            string Word = Console.ReadLine();
            T findWord = (T)Convert.ChangeType(Word, typeof(T));

            //search word in linked list 
            Search(findWord);

            Console.WriteLine("\nThe content in the list is\n");
            Display();

            //write contents from linked list to file
            WriteToFile(filePath);
            Console.WriteLine("\nContents ADDED to the file");



        }
        public void OrderList()
        {
            string filePath = @"C:\Users\NARD'S IDEAPAD\source\repos\DataStructurePrograms\DataStructurePrograms\OrderListItems.txt";
            string fileContents = File.ReadAllText(filePath);
            string[] fileListString = fileContents.Split(" ");

            List<T> fileList = new List<T>();
            foreach(string i in fileListString)
            {
                T x = (T)Convert.ChangeType(i, typeof(T));
                fileList.Add(x);
            }

            foreach (T i in fileList)
            {
                
                InsertAtLast(i);
            }
            Console.WriteLine("************ADDED ALL ELEMENTS************");


            Console.WriteLine("The content in the list is\n");
            Display();
            Sort();
            Console.WriteLine("\nAfter Sorting");
            Display();
            Console.WriteLine("\nEnter the word need to be searched in file:");
            int Word =Convert.ToInt32(Console.ReadLine());
            T findWord = (T)Convert.ChangeType(Word, typeof(T));

            //search word in linked list 
            Search(findWord);
            Sort();

            Console.WriteLine("\nThe content in the list is\n");
            Display();

            //write contents from linked list to file
            WriteToFile(filePath);
            Console.WriteLine("\nContents ADDED to the file");



        }



        //method for insert at last
        public void InsertAtLast(T val)
        {
            Node<T> temp = new Node<T>(val);
            if (head == null)
            {
                this.head = temp;
            }
            else
            {
                Node<T> traverse = this.head;
                while (traverse.next != null)
                {
                    traverse = traverse.next;
                }
                traverse.next = temp;
            }

        }
        public void InsertBeginning(T val)
        {
            Node<T> temp = new Node<T>(val);
            if (head == null)
            {
                this.head = temp;
            }
            else
            {

                temp.next = this.head;
                this.head = temp;
            }

        }
        public void InsertMiddle(T val, int pos)
        {
            Node<T> addNode = new Node<T>(val);
            Node<T> temp = this.head;
            Node<T> prev = null;
            for (int i = 1; i < pos && temp != null; i++)
            {
                prev = temp;
                temp = temp.next;
            }
            prev.next = addNode;
            addNode.next = temp;


        }
        public void DeleteBeginning()
        {
            if (this.head != null)
            {
                Console.WriteLine("\nAfter Deletion:");
                this.head = this.head.next;
            }
            else
            {
                Console.WriteLine("No elements in the linked list");
            }
        }

        public void DeleteLast()
        {
            if (this.head != null)
            {
                Node<T> temp = this.head;

                while (temp.next.next != null)
                {
                    temp = temp.next;
                }
                temp.next = null;
                Console.WriteLine("\nAfter deletion:");
            }
            else
            {
                Console.WriteLine("No elements in the linked list");
            }

        }
        public void DeleteMiddle(T val)
        {
            if (this.head != null)
            {
                Node<T> temp = this.head;
                Node<T> prev = null;
                while (temp != null)
                {
                    
                    if ((temp.data).CompareTo(val) == 0)
                    {
                        prev.next = temp.next;
                        break;
                    }
                    prev = temp;
                    temp = temp.next;
                }
                Console.WriteLine("\nAfter deletion:");
            }
            else
            {
                Console.WriteLine("No elements in the linked list");
            }

        }

        public void Search(T val)
        {
            Node<T> temp = this.head;
            int count = 0, FlagsAttribute = 0;
            while (temp != null)
            {
                count++;
                if ((temp.data).CompareTo(val) == 0)
                {
                    FlagsAttribute = 1;
                    break;
                }
                temp = temp.next;
            }
            if (FlagsAttribute == 1)
            {
                Console.WriteLine("***********The  word found and deleted*********");
                DeleteMiddle(val);
            }
            else
            {
                Console.WriteLine("*****word not found and add**********");
                InsertAtLast(val);
            }
        }

        public void Sort()
        {
            Node<T> i;
            Node<T> j;
            T temp;
            for (i = this.head; i != null; i = i.next)
            {
                for (j = i.next; j != null; j = j.next)
                {
                    
                    if ((i.data).CompareTo(j.data) > 0)
                    {
                        temp = i.data;
                        i.data = j.data;
                        j.data = temp;
                    }
                }

            }
        }
        //method to display linkedlist
        public void Display()
        {
            Node<T> temp = this.head;
            
           
            while (temp != null)
            {
                if (temp.next != null)
                {
                    Console.Write($"{temp.data}-->");
                   
                }
                else
                {
                    Console.Write(temp.data);
                }

                temp = temp.next;
            }
            
          }
        public void WriteToFile(string filePath)
        {
            Node<T> temp = this.head;

            string res = string.Empty;
            while (temp != null)
            {
                if (temp.next != null)
                {
                    res = res + temp.data + " ";

                }
                else
                {
                    res = res + temp.data;
                }

                temp = temp.next;
            }
            
            //String output = new String(res);
            File.WriteAllText(filePath, res);
        }

        public int Size()
        {
            int count = 0;
            Node<T> temp = this.head;
            while (temp != null)
            {

                count++;
                temp = temp.next;
            }
            return count;
        }
    }
}
