using System;
using System.Linq;

namespace GreedyAlgorithm
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            var solver = new GreedySolver(new[] { 12000, 14000, 15000 });

            try
            {
                var desiredLengths = Enumerable.Range(1, 100).Select(x => 6000).ToList();
                desiredLengths.AddRange(Enumerable.Range(1, 100).Select(x => 11000));

                var results = solver.Solve(desiredLengths);

                foreach (var result in results.GroupBy(x => x.OriginalLength))
                    Console.WriteLine($"You should buy {result.Count()} of {result.Key.ToString("n0")} length bar.");

                var totalWaste = results.Select(x => x.Remaining).Sum().ToString("n0");

                Console.WriteLine($"Finished with {totalWaste} waste");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
