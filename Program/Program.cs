using System;
using System.IO;
using RandomNumberSequence.Libraries;

namespace RandomNumberSequence.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var randomSequenceCreator = new RandomSequenceCreator();
            var list = randomSequenceCreator.GenerateRandomList();

            using (StreamWriter writer = new StreamWriter("output.txt", false))
            {
                foreach(var number in list)
                {
                    writer.WriteLine(number);
                }
            }
        }
    }
}
