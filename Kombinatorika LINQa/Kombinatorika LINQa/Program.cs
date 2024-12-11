using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kombinatorika_LINQa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var digits = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var permutations = GetPermutations(digits, digits.Count);

            foreach (var perm in permutations)
            {
                if (IsValid(perm))
                {
                    Console.WriteLine(string.Join("", perm));
                    break;
                }
            }

            Console.ReadLine();
        }

        static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1)
                return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                            (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        static bool IsValid(IEnumerable<int> digits)
        {
            var number = digits.Aggregate(0, (current, digit) => current * 10 + digit);

            for (int i = 9; i >= 1; i--)
            {
                if (number % i != 0)
                    return false;
                number /= 10;
            }

            return true;
        }
    }
}
