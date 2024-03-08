namespace KnapsackProblem
{
    public class Item
    {
        public int value;
        public int weight;
        public double ratio;

        public Item(int value, int weight)
        {
            this.value = value;
            this.weight = weight;
            ratio = value / (double)weight;
        }

        public override string ToString()
        {
            return "v:" + value + "     w:" + weight + "    r:" + ratio;
        }
    }
}