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
    public partial class Gui_Figure : UserControl
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Side { get; set; }
        public string Type { get; set; }
        public int ID { get; set; }
        public bool LegalNextMove { get; set; }
        public bool Kick { get; set; }
        public Gui_Figure()
        {
            InitializeComponent();
        }
    }
}
