using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardModel
{
    public class WhitePlayer
    {
        private List<int[]> switchableCells = new List<int[]>();
        public List<int[]> SwitchableCells { get { return switchableCells; } set { switchableCells = value; } }
    }
}
