using System;
using System.Windows.Forms;

namespace Desktop_Chess
{
    public partial class Form_Game : Form
    {
        static Debug debug;
        static RenderMain render;
        static RenderFunctions renderFunctions;
        public Form_Game()
        {
            render = new RenderMain(this);
            renderFunctions = new RenderFunctions(this);
            debug = new Debug(this);
            InitializeComponent();
        }

        public void Board_Click(object sender, EventArgs e)
        {
            render.Board_Click(sender);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            render.Init();
            debug.GUIdebug();
        }
       
        private void comboBox_Skins(object sender, EventArgs e)
        {
            render.SelectSkin(sender);
        }

        private void comboBox_DebugArrays(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            debug.debugScanArray(combo.Text);
            
        }


        

        private void label_Rescan_Click(object sender, EventArgs e)
        {

        }
    }
}
