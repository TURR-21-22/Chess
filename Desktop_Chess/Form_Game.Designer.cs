
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
            this.label_Skins = new System.Windows.Forms.Label();
            this.panel_ChessBoard = new System.Windows.Forms.Panel();
            this.button_Rescan = new System.Windows.Forms.Button();
            this.panel_Container_Top = new System.Windows.Forms.Panel();
            this.label_Rescan = new System.Windows.Forms.Label();
            this.comboBox_Skin_List = new System.Windows.Forms.ComboBox();
            this.panel_Container_Right = new System.Windows.Forms.Panel();
            this.panel_Debug = new System.Windows.Forms.Panel();
            this.listBox_Debug = new System.Windows.Forms.ListBox();
            this.panel_Container_Left = new System.Windows.Forms.Panel();
            this.panel_Container_Top.SuspendLayout();
            this.panel_Container_Right.SuspendLayout();
            this.panel_Container_Left.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_Skins
            // 
            this.label_Skins.AutoSize = true;
            this.label_Skins.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Skins.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_Skins.Location = new System.Drawing.Point(9, 9);
            this.label_Skins.Name = "label_Skins";
            this.label_Skins.Size = new System.Drawing.Size(52, 23);
            this.label_Skins.TabIndex = 0;
            this.label_Skins.Text = "Skins";
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
            // button_Rescan
            // 
            this.button_Rescan.BackColor = System.Drawing.SystemColors.Control;
            this.button_Rescan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Rescan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Rescan.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_Rescan.Location = new System.Drawing.Point(818, 9);
            this.button_Rescan.Name = "button_Rescan";
            this.button_Rescan.Size = new System.Drawing.Size(116, 27);
            this.button_Rescan.TabIndex = 3;
            this.button_Rescan.Text = "Rescan";
            this.button_Rescan.UseVisualStyleBackColor = false;
            this.button_Rescan.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel_Container_Top
            // 
            this.panel_Container_Top.BackColor = System.Drawing.Color.Transparent;
            this.panel_Container_Top.Controls.Add(this.label_Rescan);
            this.panel_Container_Top.Controls.Add(this.label_Skins);
            this.panel_Container_Top.Controls.Add(this.comboBox_Skin_List);
            this.panel_Container_Top.Controls.Add(this.button_Rescan);
            this.panel_Container_Top.Location = new System.Drawing.Point(12, 12);
            this.panel_Container_Top.Name = "panel_Container_Top";
            this.panel_Container_Top.Padding = new System.Windows.Forms.Padding(6);
            this.panel_Container_Top.Size = new System.Drawing.Size(960, 45);
            this.panel_Container_Top.TabIndex = 4;
            // 
            // label_Rescan
            // 
            this.label_Rescan.AutoSize = true;
            this.label_Rescan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Rescan.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_Rescan.Location = new System.Drawing.Point(724, 9);
            this.label_Rescan.Name = "label_Rescan";
            this.label_Rescan.Size = new System.Drawing.Size(67, 23);
            this.label_Rescan.TabIndex = 5;
            this.label_Rescan.Text = "Rescan";
            // 
            // comboBox_Skin_List
            // 
            this.comboBox_Skin_List.BackColor = System.Drawing.SystemColors.Control;
            this.comboBox_Skin_List.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Skin_List.FormattingEnabled = true;
            this.comboBox_Skin_List.Items.AddRange(new object[] {
            "solid",
            "wood"});
            this.comboBox_Skin_List.Location = new System.Drawing.Point(67, 9);
            this.comboBox_Skin_List.Name = "comboBox_Skin_List";
            this.comboBox_Skin_List.Size = new System.Drawing.Size(121, 23);
            this.comboBox_Skin_List.TabIndex = 4;
            this.comboBox_Skin_List.SelectedIndexChanged += new System.EventHandler(this.comboBox_Skin_List_SelectedIndexChanged);
            // 
            // panel_Container_Right
            // 
            this.panel_Container_Right.BackColor = System.Drawing.Color.Transparent;
            this.panel_Container_Right.Controls.Add(this.panel_Debug);
            this.panel_Container_Right.Controls.Add(this.listBox_Debug);
            this.panel_Container_Right.Location = new System.Drawing.Point(607, 63);
            this.panel_Container_Right.Name = "panel_Container_Right";
            this.panel_Container_Right.Padding = new System.Windows.Forms.Padding(6);
            this.panel_Container_Right.Size = new System.Drawing.Size(365, 592);
            this.panel_Container_Right.TabIndex = 0;
            // 
            // panel_Debug
            // 
            this.panel_Debug.BackColor = System.Drawing.Color.Transparent;
            this.panel_Debug.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Debug.Location = new System.Drawing.Point(21, 23);
            this.panel_Debug.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Debug.Name = "panel_Debug";
            this.panel_Debug.Size = new System.Drawing.Size(250, 252);
            this.panel_Debug.TabIndex = 3;
            // 
            // listBox_Debug
            // 
            this.listBox_Debug.BackColor = System.Drawing.Color.Black;
            this.listBox_Debug.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox_Debug.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.listBox_Debug.FormattingEnabled = true;
            this.listBox_Debug.ItemHeight = 15;
            this.listBox_Debug.Location = new System.Drawing.Point(21, 296);
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
        public System.Windows.Forms.Label label_Skins;
        public System.Windows.Forms.Button button_Rescan;
        public System.Windows.Forms.ComboBox comboBox_Skin_List;
        public System.Windows.Forms.Panel panel_Debug;
        public System.Windows.Forms.Label label_Rescan;
    }
}

