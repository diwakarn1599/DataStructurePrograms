using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructurePrograms
{
    class CalendarWeek<T>
    {
        public CalendarWeek<T> next;
        public CalendarWeek<T> head;
        public int date;
        

        public CalendarWeek() { }
        public CalendarWeek(int date)
        {
            this.date = date;
           
            this.next = null;
        }
        /// <summary>
        /// Add objects to linked list
        /// </summary>
        /// <param name="temp"></param>
        public void InsertAtLast(CalendarWeek<T> temp)
        {
            if (head == null)
            {
                head = temp;
            }
            else
            {
                CalendarWeek<T> traverse = this.head;
                while (traverse.next != null)
                {
                    traverse = traverse.next;
                }
                traverse.next = temp;

            }
        }
        
       /// <summary>
       /// display linked list
       /// </summary>

        public void DisplayWeek()
        {
            CalendarWeek<T> temp = head;
            while (temp != null)
            {
                if (temp.date>0)
                {
                    if (temp.date < 10)
                    {
                        Console.Write($"  {temp.date } ");
                    }
                    else
                    {
                        Console.Write($"{temp.date}  ");
                    }
                    
                }
                else
                {
                    Console.Write("  ");
                    
                }

                

                temp = temp.next;
            }
            Console.WriteLine("\n");
        }
    }
}
