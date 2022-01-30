using System;
using System.Windows.Forms;

namespace Desktop_Chess
{
    public partial class Main : Form
    {
        static Debug debug;
        static RenderMain render;
        static RenderFunctions renderFunctions;
        public bool debugIs = false;
        public bool testMode = true;

        public Main()
        {
            render = new RenderMain(this);
            renderFunctions = new RenderFunctions(this);
            

            InitializeComponent();
        }

        public void Board_Click(object sender, EventArgs e)
        {
            render.Board_Click(sender);
        }

        public void Kicked_Click(object sender, EventArgs e)
        {
            render.Kicked_Click(sender);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            render.Init();
            debug = new Debug(this);
            debug.GUIdebug();
            comboBox_Debug.Text = "model";
        }
       
        private void comboBox_Skins(object sender, EventArgs e)
        {
            render.SelectSkin(sender);
        }

        private void label_DebugSwitch_Click(object sender, EventArgs e)
        {
            debug.debugSwitch();
        }

        private void comboBox_Debug_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            debug.setMonitoredArray(cmb.SelectedItem.ToString());
        }

    }
}
