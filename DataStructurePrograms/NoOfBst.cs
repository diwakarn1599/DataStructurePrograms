using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructurePrograms
{
    class NoOfBst
    {
        public void NoOfBinarySearchTree()
        {
	    //getting number of nodes from user
            Console.WriteLine("Enter the number of Nodes");
            int number = Convert.ToInt32(Console.ReadLine());
	    //array for storing trees
            int[] bstArray = new int[number + 1];
            bstArray[0] = bstArray[1] = 1;
            for (int i = 2; i <= number; i++)
            {
                bstArray[i] = 0;
                for (int j = 0; j < i; j++)
                {
                    bstArray[i] += bstArray[j] * bstArray[i - j - 1];
                }
            }
	    //calculating number of trees
            double power = Math.Pow(10, 8) + 7;

            Console.WriteLine($"Number of Bst with {number} nodes is : { Math.Abs(bstArray[number] % power)}");
        }
    }
}
