using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardModel
{
    public class Figure
    {
        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }
        public int ID { get ; set; }
        public int Side { get ; set ; }
        public int Type { get; set; }

        public Figure(int x, int y)
        {
            RowNumber = x;
            ColumnNumber = y;
        }
    }
}
