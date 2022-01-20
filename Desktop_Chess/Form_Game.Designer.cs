
namespace Desktop_Chess
{
    partial class Form_Game
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel_ChessBoard = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel_Container_Top = new System.Windows.Forms.Panel();
            this.panel_Container_Right = new System.Windows.Forms.Panel();
            this.panel_Container_Left = new System.Windows.Forms.Panel();
            this.panel_Container_Top.SuspendLayout();
            this.panel_Container_Left.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select the piece from drop down menu";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "king",
            "queen",
            "knight",
            "knight",
            "bishop",
            "rook"});
            this.comboBox1.Location = new System.Drawing.Point(258, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // panel_ChessBoard
            // 
            this.panel_ChessBoard.BackColor = System.Drawing.Color.Black;
            this.panel_ChessBoard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_ChessBoard.Location = new System.Drawing.Point(0, 0);
            this.panel_ChessBoard.Margin = new System.Windows.Forms.Padding(0);
            this.panel_ChessBoard.Name = "panel_ChessBoard";
            this.panel_ChessBoard.Size = new System.Drawing.Size(450, 450);
            this.panel_ChessBoard.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::Desktop_Chess.Properties.Resources.figures_default_black_bastya;
            this.button1.Location = new System.Drawing.Point(406, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel_Container_Top
            // 
            this.panel_Container_Top.BackColor = System.Drawing.Color.Transparent;
            this.panel_Container_Top.Controls.Add(this.button1);
            this.panel_Container_Top.Controls.Add(this.label1);
            this.panel_Container_Top.Controls.Add(this.comboBox1);
            this.panel_Container_Top.Location = new System.Drawing.Point(12, 12);
            this.panel_Container_Top.Name = "panel_Container_Top";
            this.panel_Container_Top.Padding = new System.Windows.Forms.Padding(6);
            this.panel_Container_Top.Size = new System.Drawing.Size(960, 45);
            this.panel_Container_Top.TabIndex = 4;
            // 
            // panel_Container_Right
            // 
            this.panel_Container_Right.BackColor = System.Drawing.Color.Transparent;
            this.panel_Container_Right.Location = new System.Drawing.Point(607, 63);
            this.panel_Container_Right.Name = "panel_Container_Right";
            this.panel_Container_Right.Padding = new System.Windows.Forms.Padding(6);
            this.panel_Container_Right.Size = new System.Drawing.Size(365, 592);
            this.panel_Container_Right.TabIndex = 0;
            // 
            // panel_Container_Left
            // 
            this.panel_Container_Left.BackColor = System.Drawing.Color.Transparent;
            this.panel_Container_Left.Controls.Add(this.panel_ChessBoard);
            this.panel_Container_Left.Location = new System.Drawing.Point(12, 63);
            this.panel_Container_Left.Name = "panel_Container_Left";
            this.panel_Container_Left.Size = new System.Drawing.Size(589, 592);
            this.panel_Container_Left.TabIndex = 1;
            // 
            // Form_Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1054, 708);
            this.Controls.Add(this.panel_Container_Left);
            this.Controls.Add(this.panel_Container_Right);
            this.Controls.Add(this.panel_Container_Top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Chess";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel_Container_Top.ResumeLayout(false);
            this.panel_Container_Top.PerformLayout();
            this.panel_Container_Left.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Panel panel_Container_Top;
        public System.Windows.Forms.Panel panel_Container_Right;
        public System.Windows.Forms.Panel panel_Container_Left;
        public System.Windows.Forms.Panel panel_ChessBoard;
    }
}

