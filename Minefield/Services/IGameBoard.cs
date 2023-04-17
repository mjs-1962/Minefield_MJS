namespace Minefield.Services
{
    public interface IGameBoard
    {
        List<List<bool>> ApplyMinesToPlayingField(int gridSize, List<List<bool>> cells, List<int> uniqueIntegers);
        int GetColumnFromInteger(int gridSize, int index);
        int GetRowFromInteger(int gridSize, int index);
        List<List<bool>> InitialiseCells(int gridSize);
    }
}