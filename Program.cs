using System;
using System.Collections.Generic;

namespace Kiran
{
    class Program
    {
        static void Main(string[] args)
        {            
            while (true)
            {
                LetterService svc = new LetterService();

                Console.WriteLine("input:");

                string input = Console.ReadLine();

                List<int> inputList = new List<int>();

                char[] inputChars = input.ToCharArray();

                foreach (char c in inputChars)
                {
                    inputList.Add(int.Parse(c.ToString()));
                }

                List<int>[] markerSets = svc.GenerateMarkerSets(inputList);
                List<string> output = svc.GenerateLetterStrings(inputList, markerSets);

                foreach (string str in output)
                {
                    Console.WriteLine(str);
                }
            }
        }
    }
}
