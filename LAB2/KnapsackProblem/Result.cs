using System.Collections.Generic;

namespace KnapsackProblem
{
    public class Result
    {
        public int totalWeight;
        public int totalValue;
        private List<Item> items;

        public Result(int totalWeight, int totalValue, List<Item> items)
        {
            this.totalWeight = totalWeight;
            this.totalValue = totalValue;
            this.items = items;
        }

        public override string ToString()
        {
            string result = "RESULT: total weight: " + totalWeight + " total value: " + totalValue + "\n";
            for (int i = 0; i < items.Count; i++)
            {
                Item item = items[i];
                result = result + (i + 1) + ". " + item + "\n";
            }

            return result;
        }
    }
}