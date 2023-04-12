using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingNumbersUsingStackAndQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            int numCount = 100;
            // only purpose is to limit the number of things in the list
            int maxNum = 20; 
            // the maximum number to be generated
            Random rnd = new Random();
            int indexToRemove = 0;
            int displayNum = 15;

            // stack and queue
            Stack<int> numStack = new Stack<int>();
            Queue<int> numQueue = new Queue<int>();

            // populating the list
            for(int x = 0; x < numCount; x++) 
                numbers.Add(rnd.Next(maxNum));

            Console.WriteLine(numbers.Count());
            // sorting logic
            // .Contains method
            //for (int x = 0; x < maxNum; x++)
            //{
            //    if (numbers.Contains(x))
            //    {
            //        numbers.Remove(x);
            //        x--;
            //    }
            //}

            // actively search
            // this block of code actively looks for the first instance
            // of the least number in the list until the list is empty
            while(numbers.Count() > 0) 
            {
                // this line resets to the largest number possible in the list
                // + 1
                maxNum = 100;
                // this is the variable that holds the index of the first instance
                // of the least number in the list
                indexToRemove = 0;

                // looking for numbers in the list
                for(int x = 0; x < numbers.Count(); x++)
                {
                    // compares the number in the list to the max number
                    if (numbers[x] < maxNum)
                    {
                        // changing the value of max number with the number located
                        maxNum = numbers[x];
                        // saving the index of the least number
                        indexToRemove = x;
                    }
                }

                // puts the least number in the stack
                numStack.Push(maxNum);
                // peeking at the top of the stack to put in the queue
                numQueue.Enqueue(numStack.Peek());
                // removing the index from the list
                numbers.RemoveAt(indexToRemove);
            }

            Console.WriteLine(numbers.Count());
            Console.WriteLine(numStack.Count());
            Console.WriteLine(numQueue.Count());

            Console.WriteLine("\nPrinting the Stack");
            while(numStack.Count() > 0)
            {
                Console.Write(numStack.Pop() + "\t");
                displayNum--;
                if (displayNum == 0)
                {
                    Console.WriteLine();
                    displayNum = 15;
                }
            }

            displayNum = 15;
            Console.WriteLine("\nPrinting the Queue");
            while (numQueue.Count() > 0)
            {
                Console.Write(numQueue.Dequeue() + "\t");
                displayNum--;
                if (displayNum == 0)
                {
                    Console.WriteLine();
                    displayNum = 15;
                }
            }
            Console.ReadKey();
        }
    }
}
