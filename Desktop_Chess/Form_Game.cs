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
    public partial class Form_Game : Form
    {
        static RenderMain Render = null;
        public Form_Game()
        {
            Render = new RenderMain(this);
            

            InitializeComponent();
        }

        public void Grid_Button_Click(object sender, EventArgs e)
        {
            Render.PlaceFigure(sender);
        }

        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Render.ComboSelectFigure(sender);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Render.Init(2,0); // 1. paranmeter = cell skin set, 2. parameter = misc sckin set

        }
    }
}
