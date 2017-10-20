using System.Collections.Generic;
using System.Linq;

namespace GreedyAlgorithm
{
    internal class Bar
    {
        public int OriginalLength { get; set; }
        public int Remaining => OriginalLength - Cuts.Sum();
        public List<int> Cuts { get; }

        public void Cut(int length) => Cuts.Add(length);

        public Bar(int length)
        {
            Cuts = new List<int>();
            OriginalLength = length;
        }
    }
}
