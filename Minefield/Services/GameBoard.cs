using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield.Services
{
    public class GameBoard
    {
        const bool CellHasMine = true;
        const bool CellHasNoMine = false;


        public List<List<bool>> InitialiseCells(int gridSize)
        {
            var cells = new List<List<bool>>();
            for (int row = 0; row < gridSize; row++)
            {
                var newRow = new List<bool>();
                for (int column = 0; column < gridSize; column++)
                {
                    newRow.Add(CellHasNoMine);
                }
                cells.Add(newRow);
            }
            return cells;
        }


        public List<List<bool>> ApplyMinesToPlayingField(int gridSize, List<List<bool>> cells, List<int> uniqueIntegers)
        {
            foreach (int randomInteger in uniqueIntegers)
            {
                int cellRow = GetRowFromInteger(gridSize, randomInteger);
                int cellColumn = GetColumnFromInteger(gridSize, randomInteger);

                var activeList = cells[cellRow];
                activeList[cellColumn] = true;

            }

            return cells;
        }

        public int GetRowFromInteger(int gridSize, int index)
        {
            return index / gridSize;
        }

        public int GetColumnFromInteger(int gridSize, int index)
        {
            return index % gridSize;
        }

    }
}
