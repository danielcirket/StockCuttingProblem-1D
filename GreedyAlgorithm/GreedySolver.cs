using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreedyAlgorithm
{
    internal class GreedySolver
    {
        private readonly IEnumerable<int> _availableLengths;

        public IEnumerable<Bar> Solve(IEnumerable<int> desiredLengths)
        {
            var results = new List<Bar>();
            var maxAvailableLength = _availableLengths.Max();

            if (desiredLengths.Max() > maxAvailableLength)
                throw new ArgumentOutOfRangeException("One or more desired lengths is greater than all available lengths");

            foreach (var item in desiredLengths)
            {
                if (!results.Any(bar => bar.Remaining >= item))
                    results.Add(new Bar(maxAvailableLength));

                var availableBar = results.FirstOrDefault(bar => bar.Remaining >= item);

                availableBar?.Cut(item);
            }

            foreach(var bar in results)
            {
                var length = bar.OriginalLength;

                foreach(var availableLength in _availableLengths)
                {
                    if (availableLength != bar.OriginalLength && bar.OriginalLength - bar.Remaining <= availableLength)
                    {
                        length = availableLength;
                        break;
                    }
                }

                bar.OriginalLength = length;
            }

            return results;
        }

        public GreedySolver(IEnumerable<int> availableLengths)
        {
            if (availableLengths == null)
                throw new ArgumentNullException(nameof(availableLengths));

            _availableLengths = availableLengths;
        }
    }
}
