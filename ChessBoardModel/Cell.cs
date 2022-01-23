using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardModel
{
    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool CurrentlyOccupied { get; set; }
        public bool LegalNextMove { get; set; }
        public Figure CellFigure { get; set; }
        public bool Kick { get; set; }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
