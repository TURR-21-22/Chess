
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
            this.panel_ChessBoard = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel_Container_Top = new System.Windows.Forms.Panel();
            this.comboBox_Skin_List = new System.Windows.Forms.ComboBox();
            this.panel_Container_Right = new System.Windows.Forms.Panel();
            this.listBox_Debug = new System.Windows.Forms.ListBox();
            this.panel_Container_Left = new System.Windows.Forms.Panel();
            this.panel_Container_Top.SuspendLayout();
            this.panel_Container_Right.SuspendLayout();
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
            // panel_ChessBoard
            // 
            this.panel_ChessBoard.BackColor = System.Drawing.Color.Transparent;
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
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(854, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel_Container_Top
            // 
            this.panel_Container_Top.BackColor = System.Drawing.Color.Transparent;
            this.panel_Container_Top.Controls.Add(this.comboBox_Skin_List);
            this.panel_Container_Top.Controls.Add(this.button1);
            this.panel_Container_Top.Controls.Add(this.label1);
            this.panel_Container_Top.Location = new System.Drawing.Point(12, 12);
            this.panel_Container_Top.Name = "panel_Container_Top";
            this.panel_Container_Top.Padding = new System.Windows.Forms.Padding(6);
            this.panel_Container_Top.Size = new System.Drawing.Size(960, 45);
            this.panel_Container_Top.TabIndex = 4;
            // 
            // comboBox_Skin_List
            // 
            this.comboBox_Skin_List.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Skin_List.FormattingEnabled = true;
            this.comboBox_Skin_List.Items.AddRange(new object[] {
            "solid",
            "wood"});
            this.comboBox_Skin_List.Location = new System.Drawing.Point(405, 9);
            this.comboBox_Skin_List.Name = "comboBox_Skin_List";
            this.comboBox_Skin_List.Size = new System.Drawing.Size(121, 23);
            this.comboBox_Skin_List.TabIndex = 4;
            this.comboBox_Skin_List.SelectedIndexChanged += new System.EventHandler(this.comboBox_Skin_List_SelectedIndexChanged);
            // 
            // panel_Container_Right
            // 
            this.panel_Container_Right.BackColor = System.Drawing.Color.Transparent;
            this.panel_Container_Right.Controls.Add(this.listBox_Debug);
            this.panel_Container_Right.Location = new System.Drawing.Point(607, 63);
            this.panel_Container_Right.Name = "panel_Container_Right";
            this.panel_Container_Right.Padding = new System.Windows.Forms.Padding(6);
            this.panel_Container_Right.Size = new System.Drawing.Size(365, 592);
            this.panel_Container_Right.TabIndex = 0;
            // 
            // listBox_Debug
            // 
            this.listBox_Debug.BackColor = System.Drawing.Color.Black;
            this.listBox_Debug.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox_Debug.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.listBox_Debug.FormattingEnabled = true;
            this.listBox_Debug.ItemHeight = 15;
            this.listBox_Debug.Location = new System.Drawing.Point(9, 9);
            this.listBox_Debug.Name = "listBox_Debug";
            this.listBox_Debug.Size = new System.Drawing.Size(118, 240);
            this.listBox_Debug.TabIndex = 0;
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
            this.ClientSize = new System.Drawing.Size(1149, 708);
            this.Controls.Add(this.panel_Container_Left);
            this.Controls.Add(this.panel_Container_Right);
            this.Controls.Add(this.panel_Container_Top);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Chess";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel_Container_Top.ResumeLayout(false);
            this.panel_Container_Top.PerformLayout();
            this.panel_Container_Right.ResumeLayout(false);
            this.panel_Container_Left.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Panel panel_Container_Top;
        public System.Windows.Forms.Panel panel_Container_Right;
        public System.Windows.Forms.Panel panel_Container_Left;
        public System.Windows.Forms.Panel panel_ChessBoard;
        public System.Windows.Forms.ListBox listBox_Debug;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.ComboBox comboBox_Skin_List;
    }
}

