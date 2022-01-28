
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
            this.panel_Container_Top = new System.Windows.Forms.Panel();
            this.comboBox_DebugArrays = new System.Windows.Forms.ComboBox();
            this.label_DebugSwitch = new System.Windows.Forms.Label();
            this.comboBox_Skin_List = new System.Windows.Forms.ComboBox();
            this.panel_Container_Left = new System.Windows.Forms.Panel();
            this.panel_Debug = new System.Windows.Forms.Panel();
            this.panel_Container_Right = new System.Windows.Forms.Panel();
            this.panel_kicked = new System.Windows.Forms.Panel();
            this.panel_Container_Top.SuspendLayout();
            this.panel_Container_Left.SuspendLayout();
            this.panel_Container_Right.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_Skins
            // 
            this.label_Skins.AutoSize = true;
            this.label_Skins.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Skins.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_Skins.Location = new System.Drawing.Point(136, 8);
            this.label_Skins.Name = "label_Skins";
            this.label_Skins.Size = new System.Drawing.Size(45, 20);
            this.label_Skins.TabIndex = 0;
            this.label_Skins.Text = "Skins";
            // 
            // panel_ChessBoard
            // 
            this.panel_ChessBoard.BackColor = System.Drawing.Color.Transparent;
            this.panel_ChessBoard.Location = new System.Drawing.Point(0, 0);
            this.panel_ChessBoard.Margin = new System.Windows.Forms.Padding(0);
            this.panel_ChessBoard.Name = "panel_ChessBoard";
            this.panel_ChessBoard.Size = new System.Drawing.Size(450, 450);
            this.panel_ChessBoard.TabIndex = 2;
            // 
            // panel_Container_Top
            // 
            this.panel_Container_Top.BackColor = System.Drawing.Color.Transparent;
            this.panel_Container_Top.Controls.Add(this.comboBox_DebugArrays);
            this.panel_Container_Top.Controls.Add(this.label_DebugSwitch);
            this.panel_Container_Top.Controls.Add(this.label_Skins);
            this.panel_Container_Top.Controls.Add(this.comboBox_Skin_List);
            this.panel_Container_Top.Location = new System.Drawing.Point(12, 12);
            this.panel_Container_Top.Name = "panel_Container_Top";
            this.panel_Container_Top.Padding = new System.Windows.Forms.Padding(6);
            this.panel_Container_Top.Size = new System.Drawing.Size(960, 45);
            this.panel_Container_Top.TabIndex = 4;
            // 
            // comboBox_DebugArrays
            // 
            this.comboBox_DebugArrays.BackColor = System.Drawing.SystemColors.Control;
            this.comboBox_DebugArrays.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DebugArrays.FormattingEnabled = true;
            this.comboBox_DebugArrays.Items.AddRange(new object[] {
            "model",
            "gui"});
            this.comboBox_DebugArrays.Location = new System.Drawing.Point(757, 13);
            this.comboBox_DebugArrays.Name = "comboBox_DebugArrays";
            this.comboBox_DebugArrays.Size = new System.Drawing.Size(121, 23);
            this.comboBox_DebugArrays.TabIndex = 6;
            // 
            // label_DebugSwitch
            // 
            this.label_DebugSwitch.AutoSize = true;
            this.label_DebugSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_DebugSwitch.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_DebugSwitch.Location = new System.Drawing.Point(884, 13);
            this.label_DebugSwitch.Name = "label_DebugSwitch";
            this.label_DebugSwitch.Padding = new System.Windows.Forms.Padding(2);
            this.label_DebugSwitch.Size = new System.Drawing.Size(64, 27);
            this.label_DebugSwitch.TabIndex = 5;
            this.label_DebugSwitch.Text = "Debug";
            this.label_DebugSwitch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_DebugSwitch.Click += new System.EventHandler(this.label_DebugSwitch_Click);
            // 
            // comboBox_Skin_List
            // 
            this.comboBox_Skin_List.BackColor = System.Drawing.SystemColors.Control;
            this.comboBox_Skin_List.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Skin_List.FormattingEnabled = true;
            this.comboBox_Skin_List.Items.AddRange(new object[] {
            "solid",
            "wood"});
            this.comboBox_Skin_List.Location = new System.Drawing.Point(9, 8);
            this.comboBox_Skin_List.Name = "comboBox_Skin_List";
            this.comboBox_Skin_List.Size = new System.Drawing.Size(121, 23);
            this.comboBox_Skin_List.Sorted = true;
            this.comboBox_Skin_List.TabIndex = 4;
            this.comboBox_Skin_List.SelectedIndexChanged += new System.EventHandler(this.comboBox_Skins);
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
            // panel_Debug
            // 
            this.panel_Debug.BackColor = System.Drawing.Color.Transparent;
            this.panel_Debug.Location = new System.Drawing.Point(6, 6);
            this.panel_Debug.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Debug.Name = "panel_Debug";
            this.panel_Debug.Size = new System.Drawing.Size(250, 252);
            this.panel_Debug.TabIndex = 3;
            // 
            // panel_Container_Right
            // 
            this.panel_Container_Right.BackColor = System.Drawing.Color.Transparent;
            this.panel_Container_Right.Controls.Add(this.panel_kicked);
            this.panel_Container_Right.Controls.Add(this.panel_Debug);
            this.panel_Container_Right.Location = new System.Drawing.Point(607, 63);
            this.panel_Container_Right.Name = "panel_Container_Right";
            this.panel_Container_Right.Padding = new System.Windows.Forms.Padding(6);
            this.panel_Container_Right.Size = new System.Drawing.Size(365, 592);
            this.panel_Container_Right.TabIndex = 0;
            // 
            // panel_kicked
            // 
            this.panel_kicked.BackColor = System.Drawing.Color.Transparent;
            this.panel_kicked.Location = new System.Drawing.Point(6, 283);
            this.panel_kicked.Margin = new System.Windows.Forms.Padding(0);
            this.panel_kicked.Name = "panel_kicked";
            this.panel_kicked.Size = new System.Drawing.Size(250, 252);
            this.panel_kicked.TabIndex = 4;
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
            this.panel_Container_Left.ResumeLayout(false);
            this.panel_Container_Right.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Panel panel_Container_Top;
        public System.Windows.Forms.Panel panel_Container_Left;
        public System.Windows.Forms.Panel panel_ChessBoard;
        public System.Windows.Forms.Label label_Skins;
        public System.Windows.Forms.ComboBox comboBox_Skin_List;
        public System.Windows.Forms.Label label_DebugSwitch;
        public System.Windows.Forms.ComboBox comboBox_arrays;
        public System.Windows.Forms.Panel panel_Debug;
        public System.Windows.Forms.Panel panel_Container_Right;
        public System.Windows.Forms.Panel panel_kicked;
        public System.Windows.Forms.ComboBox comboBox_DebugArrays;
    }
}

