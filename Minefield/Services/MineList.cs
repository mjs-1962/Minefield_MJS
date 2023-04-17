using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield.Services
{
    public class MineList : IMineList
    {
        public List<int> CreateUniqueMineList(int inclusiveLowerMineCellSeedValue, int exclusiveUpperMineCellSeedValue, int integerCount)
        {
            List<int> uniqueRandomNumbers = new List<int>();

            var rand = new Random();
            int newNumber;
            do
            {
                newNumber = rand.Next(inclusiveLowerMineCellSeedValue, exclusiveUpperMineCellSeedValue);

                if (!uniqueRandomNumbers.Contains(newNumber))
                {
                    uniqueRandomNumbers.Add(newNumber);
                }

            } while (uniqueRandomNumbers.Count() < integerCount);

            List<int> uniqueRandomNumbersSorted = uniqueRandomNumbers.OrderBy(o => o).ToList();
            return uniqueRandomNumbersSorted;

        }
    }
}
