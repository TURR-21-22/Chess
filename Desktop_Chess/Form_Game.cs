using System;
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

        public void Board_Click(object sender, EventArgs e)
        {
            Render.Board_Click(sender);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Render.Init();
            Debug.GUIdebug();
        }
       
        private void comboBox_Skins(object sender, EventArgs e)
        {
            Render.SelectSkin(sender);
        }

        private void comboBox_DebugArrays(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            Debug.RefreshtCellDatas(combo.Text);
            
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
