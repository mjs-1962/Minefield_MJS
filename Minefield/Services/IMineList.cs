namespace Minefield.Services
{
    public interface IMineList
   {
        public List<int> CreateUniqueMineList(int inclusiveLowerMineCellSeedValue, int exclusiveUpperMineCellSeedValue, int integerCount);
    }
}