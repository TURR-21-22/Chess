using ChessBoardModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_Chess
{
    public partial class Gui_Cell : UserControl
    {

        public int X { get; set; }
        public int Y { get; set; }
        public bool Type { get; set; } // true = figure; false = cell
        public Figure Pupet { get; set; }
        public string KickedBkgColor { get; set; }

        public Gui_Cell(int x, int y)
        {
            X = x;
            Y = y;
            InitializeComponent();
        }
    }
}
