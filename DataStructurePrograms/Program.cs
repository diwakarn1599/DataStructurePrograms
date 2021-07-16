using System;

namespace DataStructurePrograms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Data Structure Programs");
            Console.WriteLine("*******************MENU*******************");
            Console.WriteLine("1.Unordered List\n2.Ordered List\n3.Exit\nEnter Your Option");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    UnOrderedList<string> ul = new UnOrderedList<string>();
                    ul.UnorderList();
                    break;
                case 2:
                    UnOrderedList<int> ol = new UnOrderedList<int>();
                    ol.OrderList();
                    break;
                case 3:
                    Console.WriteLine("Exited");
                    break;
            }
           
            
        }
    }
}
