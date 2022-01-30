using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardModel
{
    public class WhitePlayer
    {
        private List<Cell[]> switchableCells = new List<Cell[]>();
        public List<Cell[]> SwitchableCells { get { return switchableCells; } set { switchableCells = value; } }
    }
}
