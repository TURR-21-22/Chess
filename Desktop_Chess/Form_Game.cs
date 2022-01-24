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
        static Debug Debug;
        static RenderMain Render;
        
        public Form_Game()
        {
            Render = new RenderMain(this);

            Debug = new Debug(this);

            InitializeComponent();
            
        }

        public void Grid_Button_Click(object sender, EventArgs e)
        {
            Render.PlaceFigure(sender);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Render.Init("wood"); // 1. paranmeter = skin set

            
            Debug.GUIdebug();
        }

        private void comboBox_Skin_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            Render.SelectSkin(sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Debug.RefreshtCellDatas(Debug.debug_Grid, Debug.model_Grid);
            
        }
    }
}
