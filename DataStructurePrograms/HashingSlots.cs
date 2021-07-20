using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataStructurePrograms
{
    class HashingSlots<T> where T: IComparable
    {
        //intialize size of linkedlist
        public int size = 20;
        //initialize linkedlist
        public LinkedList<T>[] listItems = new LinkedList<T>[20];
        string output = string.Empty;

        //method to excute 
        public void CheckNumber()
        {
            string filePath = @"C:\Users\NARD'S IDEAPAD\source\repos\DataStructurePrograms\DataStructurePrograms\HashingList.txt";
            string fileContents = File.ReadAllText(filePath);
            string[] fileList = fileContents.Split(" ", StringSplitOptions.RemoveEmptyEntries); 

            foreach(string i in fileList)
            {
                T x = (T)Convert.ChangeType(i, typeof(T));
                Insert(x);
            }
            Display();
            //read input from the user
            Console.WriteLine("Enter the number to be searched:");
            int num = Convert.ToInt32(Console.ReadLine());
            T n = (T)Convert.ChangeType(num, typeof(T));
            //search element
            Search(n);
            Display();
            //write to file
            FileWrite(filePath);


        }

        //get position of linkedlist
        public int GetArrayPosition(T val)
        {
            int pos = Math.Abs( Convert.ToInt32(val) % 11);
            return pos;
        }
        //insert into hashtable
        public void Insert(T val)
        {
            int position = GetArrayPosition(val);
            LinkedList<T> linkedList = GetList(position);
            linkedList.AddLast(val);
        }
        //geting linked list for particular position
        public LinkedList<T> GetList(int pos)
        {
            LinkedList<T> list = listItems[pos];
            if (list == null)
            {
                list = new LinkedList<T>();
                listItems[pos] = list;
            }
            return list;
        }
        //search element for linked list
        public void Search(T val)
        {
            int pos = GetArrayPosition(val);
            LinkedList<T> linkedList = GetList(pos);
            if (linkedList == null)
            {
                Console.WriteLine("No elements found");
                return;
            }
            else
            {
                int flag = 0;
                foreach (T i in linkedList)
                {
                    if (i.CompareTo(val) == 0)
                    {
                        flag = 1;
                        break;
                    }

                }
                if(flag == 1)
                {
                    linkedList.Remove(val);
                    Console.WriteLine("Element found and removed");
                }
                else
                {
                   
                    Insert(val);
                    Console.WriteLine("Element Added");
                }
            }
        }
        //display elements from hashtable
        public void Display()
        {
            this.output = string.Empty;

            for (int i = 0; i < this.size; i++)
            {
                LinkedList<T> linkedList = listItems[i];
                if (linkedList == null)
                {
                    continue;
                }
                foreach (T val in linkedList)
                {
                    Console.WriteLine($"At {i} ---> {val}");
                    this.output += $" {val}"; 
                }

            }
            Console.WriteLine(output);
           
        }

        //method to write contents to file
        public void FileWrite(string filePath)
        {
            File.WriteAllText(filePath, this.output);
        }

    }
}
