using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
namespace DataStructurePrograms
{
    class Calendar
    {
        static int year, month; 
        static int[,] calendar = new int[6, 7];
        private static DateTime date;
        // Queue for storing weekobjects
        public static Queue<CalendarWeek<Calendar>> weekQueue = new Queue<CalendarWeek<Calendar>>();
      
        public void FindCalendar()
        {
            Console.Write("Enter the year? ");
            year = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the month in number 1-12: ");
            month = Convert.ToInt32(Console.ReadLine());
            date = new DateTime(year, month, 1);
           
            GetCalendar();
            PrintCalendar();
            Console.WriteLine("\n*****************************Display calendar using queue*****************************");
            DisplayCalendarUsingQueue();
        }
        /// <summary>
        /// method to find and store calendar in 2d array
        /// </summary>
        public void GetCalendar()
        {
            int days = DateTime.DaysInMonth(year, month);
            int currentDay = 1;
            var dayOfWeek = (int)date.DayOfWeek;
            for (int i = 0; i < calendar.GetLength(0); i++)
            {
                CalendarWeek<Calendar> cal = new CalendarWeek<Calendar>();
                for (int j = 0; j < calendar.GetLength(1) && currentDay - dayOfWeek + 1 <= days; j++)
                {
                    if (i == 0 && month > j)
                    {
                        calendar[i, j] = 0;
                    }
                    else
                    {
                        calendar[i, j] = currentDay - dayOfWeek + 1;
                        //create object and implement in linked list
                        CalendarWeek<Calendar> calenderObjects = new CalendarWeek<Calendar>(calendar[i, j]);
                        cal.InsertAtLast(calenderObjects);
                        currentDay++;
                    }
                    
                }
                //add object into queue
                weekQueue.Enqueue(cal);
            }
        }

        /// <summary>
        /// Method to print calendar
        /// </summary>
        public void PrintCalendar()
        {
            Console.WriteLine($"{CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month)} {year}");
            Console.WriteLine("Mon Tue Wed Thu Fri Sat Sun");

            for (int i = 0; i < calendar.GetLength(0); i++)
            {
                for (int j = 0; j < calendar.GetLength(1); j++)
                {
                    if (calendar[i, j] > 0)
                    {
                        
                        if (calendar[i, j] < 10)
                        {
                            Console.Write($" {calendar[i, j]}  ");
                        }
                        else
                        {
                            Console.Write($"{calendar[i, j]}  ");
                        }
                    }
                    else
                    {
                        Console.Write("   ");
                    }
                }
                Console.WriteLine("");
            }
        }

        /// <summary>
        /// Method to print calendar using queue
        /// </summary>
        public void DisplayCalendarUsingQueue()
        {
            Console.WriteLine($"{CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month)} {year}");
            Console.WriteLine("Mon Tue Wed Thu Fri Sat Sun");
            foreach (var i in weekQueue)
            {
                i.DisplayWeek();
            }
        }

    }
}
