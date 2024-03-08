using System;
using System.Collections.Generic;
using System.Linq;

namespace KnapsackProblem
{
    public class Problem
    {
        public List<Item> items { get; set; }
        private int _seed;

        public Problem(int n, int seed)
        {
            _seed = seed;
            items = new List<Item>();
            Random random = new Random(seed);
            for (int i = 0; i < n; i++)
            {
                items.Add(new Item(random.Next(1, 11), random.Next(1, 11)));
            }
        }
        
        
        public Result Solve(int capacity)
        {
            items = items.OrderByDescending(a => a.ratio).ToList();
            List<Item> resultItems = new List<Item>();
            int sumWeight = 0;
            int sumValue = 0;
            int index = 0;
            while (sumWeight < capacity && index < items.Count)
            {
                Item item = items[index];
                if (sumWeight + item.weight <= capacity)
                {
                    sumWeight += item.weight;
                    sumValue += item.value;
                    resultItems.Add(item);
                }
                index++;
            }
            
            return new Result(sumWeight, sumValue, resultItems);
        }

        public override string ToString()
        {
            string result = "n: " + items.Count + " seed: " + _seed + "\n";
            for (int i = 0; i < items.Count; i++)
            {
                Item item = items[i];
                result = result + (i + 1) + ". " + item + "\n";
            }
            return result;
        }
    }
}