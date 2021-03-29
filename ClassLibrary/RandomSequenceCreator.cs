using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace RandomNumberSequence.Libraries
{
    public class RandomSequenceCreator
    {
        public RandomSequenceCreator()
        {
        }
        public RandomSequenceCreator(int maxValue)
        {
            MaxValue = maxValue;
            if (maxValue < 1)
                throw new ArgumentOutOfRangeException();
        }

        //Time complexity of this method is O(n)
        public List<int> GenerateRandomList()
    {
        var random = new Random(); //O(1)
        var numbersOrdered = Enumerable.Range(1, MaxValue).ToList();  //O(n)
        var numbersRandom = new List<int>(); //O(1)

        while (numbersOrdered.Count > 0) //O(n)
        {
            var index = random.Next(numbersOrdered.Count); //O(1)
            var value = numbersOrdered[index]; //O(1)
            numbersOrdered.RemoveAt(index); //O(1)
            numbersRandom.Add(value); //O(1)
        }

        return numbersRandom; //O(1)
    }

        [Range(1, int.MaxValue)]
        public int MaxValue { get; set; } = 10000;
    }
}
