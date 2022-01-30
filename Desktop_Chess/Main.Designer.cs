
namespace Desktop_Chess
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.label_Skins = new System.Windows.Forms.Label();
            this.panel_ChessBoard = new System.Windows.Forms.Panel();
            this.panel_Container_Top = new System.Windows.Forms.Panel();
            this.comboBox_Skin_List = new System.Windows.Forms.ComboBox();
            this.label_DebugSwitch = new System.Windows.Forms.Label();
            this.panel_Container_Left = new System.Windows.Forms.Panel();
            this.panel_Debug = new System.Windows.Forms.Panel();
            this.panel_Container_Right = new System.Windows.Forms.Panel();
            this.panel_Info = new System.Windows.Forms.Panel();
            this.label_Results = new System.Windows.Forms.Label();
            this.label_black_count = new System.Windows.Forms.Label();
            this.label_black_label = new System.Windows.Forms.Label();
            this.label_white_count = new System.Windows.Forms.Label();
            this.label_White_label = new System.Windows.Forms.Label();
            this.label_info_2 = new System.Windows.Forms.Label();
            this.label_info_1 = new System.Windows.Forms.Label();
            this.comboBox_Debug = new System.Windows.Forms.ComboBox();
            this.panel_kicked_container_black = new System.Windows.Forms.Panel();
            this.panel_kicked_black = new System.Windows.Forms.Panel();
            this.panel_kicked_container_white = new System.Windows.Forms.Panel();
            this.panel_kicked_white = new System.Windows.Forms.Panel();
            this.panel_Container_Top.SuspendLayout();
            this.panel_Container_Left.SuspendLayout();
            this.panel_Container_Right.SuspendLayout();
            this.panel_Info.SuspendLayout();
            this.panel_kicked_container_black.SuspendLayout();
            this.panel_kicked_container_white.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_Skins
            // 
            this.label_Skins.AutoSize = true;
            this.label_Skins.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_Skins.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_Skins.Location = new System.Drawing.Point(136, 8);
            this.label_Skins.Name = "label_Skins";
            this.label_Skins.Padding = new System.Windows.Forms.Padding(2);
            this.label_Skins.Size = new System.Drawing.Size(56, 27);
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
            this.panel_Container_Top.Controls.Add(this.label_Skins);
            this.panel_Container_Top.Controls.Add(this.comboBox_Skin_List);
            this.panel_Container_Top.Location = new System.Drawing.Point(12, 12);
            this.panel_Container_Top.Name = "panel_Container_Top";
            this.panel_Container_Top.Padding = new System.Windows.Forms.Padding(6);
            this.panel_Container_Top.Size = new System.Drawing.Size(960, 45);
            this.panel_Container_Top.TabIndex = 4;
            // 
            // comboBox_Skin_List
            // 
            this.comboBox_Skin_List.BackColor = System.Drawing.Color.Yellow;
            this.comboBox_Skin_List.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Skin_List.FlatStyle = System.Windows.Forms.FlatStyle.System;
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
            // label_DebugSwitch
            // 
            this.label_DebugSwitch.AutoSize = true;
            this.label_DebugSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label_DebugSwitch.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_DebugSwitch.Location = new System.Drawing.Point(265, 579);
            this.label_DebugSwitch.Name = "label_DebugSwitch";
            this.label_DebugSwitch.Padding = new System.Windows.Forms.Padding(2);
            this.label_DebugSwitch.Size = new System.Drawing.Size(64, 27);
            this.label_DebugSwitch.TabIndex = 5;
            this.label_DebugSwitch.Text = "Debug";
            this.label_DebugSwitch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_DebugSwitch.Click += new System.EventHandler(this.label_DebugSwitch_Click);
            // 
            // panel_Container_Left
            // 
            this.panel_Container_Left.BackColor = System.Drawing.Color.Transparent;
            this.panel_Container_Left.Controls.Add(this.panel_ChessBoard);
            this.panel_Container_Left.Location = new System.Drawing.Point(12, 63);
            this.panel_Container_Left.Name = "panel_Container_Left";
            this.panel_Container_Left.Size = new System.Drawing.Size(589, 633);
            this.panel_Container_Left.TabIndex = 1;
            // 
            // panel_Debug
            // 
            this.panel_Debug.BackColor = System.Drawing.Color.Transparent;
            this.panel_Debug.Location = new System.Drawing.Point(236, 466);
            this.panel_Debug.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Debug.Name = "panel_Debug";
            this.panel_Debug.Size = new System.Drawing.Size(120, 93);
            this.panel_Debug.TabIndex = 3;
            // 
            // panel_Container_Right
            // 
            this.panel_Container_Right.BackColor = System.Drawing.Color.Transparent;
            this.panel_Container_Right.Controls.Add(this.panel_Info);
            this.panel_Container_Right.Controls.Add(this.comboBox_Debug);
            this.panel_Container_Right.Controls.Add(this.panel_kicked_container_black);
            this.panel_Container_Right.Controls.Add(this.label_DebugSwitch);
            this.panel_Container_Right.Controls.Add(this.panel_kicked_container_white);
            this.panel_Container_Right.Controls.Add(this.panel_Debug);
            this.panel_Container_Right.Location = new System.Drawing.Point(607, 63);
            this.panel_Container_Right.Name = "panel_Container_Right";
            this.panel_Container_Right.Padding = new System.Windows.Forms.Padding(6);
            this.panel_Container_Right.Size = new System.Drawing.Size(365, 633);
            this.panel_Container_Right.TabIndex = 0;
            // 
            // panel_Info
            // 
            this.panel_Info.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.panel_Info.Controls.Add(this.label_Results);
            this.panel_Info.Controls.Add(this.label_black_count);
            this.panel_Info.Controls.Add(this.label_black_label);
            this.panel_Info.Controls.Add(this.label_white_count);
            this.panel_Info.Controls.Add(this.label_White_label);
            this.panel_Info.Controls.Add(this.label_info_2);
            this.panel_Info.Controls.Add(this.label_info_1);
            this.panel_Info.Location = new System.Drawing.Point(6, 209);
            this.panel_Info.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Info.Name = "panel_Info";
            this.panel_Info.Size = new System.Drawing.Size(327, 241);
            this.panel_Info.TabIndex = 6;
            // 
            // label_Results
            // 
            this.label_Results.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.label_Results.Font = new System.Drawing.Font("Impact", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_Results.Location = new System.Drawing.Point(16, 151);
            this.label_Results.Name = "label_Results";
            this.label_Results.Size = new System.Drawing.Size(133, 29);
            this.label_Results.TabIndex = 6;
            this.label_Results.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_black_count
            // 
            this.label_black_count.AutoSize = true;
            this.label_black_count.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_black_count.Location = new System.Drawing.Point(150, 99);
            this.label_black_count.Name = "label_black_count";
            this.label_black_count.Size = new System.Drawing.Size(103, 29);
            this.label_black_count.TabIndex = 5;
            this.label_black_count.Text = "dsfdsfsdf";
            // 
            // label_black_label
            // 
            this.label_black_label.AutoSize = true;
            this.label_black_label.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_black_label.Location = new System.Drawing.Point(11, 99);
            this.label_black_label.Name = "label_black_label";
            this.label_black_label.Size = new System.Drawing.Size(146, 29);
            this.label_black_label.TabIndex = 4;
            this.label_black_label.Text = "Fekete bábuk:";
            // 
            // label_white_count
            // 
            this.label_white_count.AutoSize = true;
            this.label_white_count.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_white_count.Location = new System.Drawing.Point(150, 58);
            this.label_white_count.Name = "label_white_count";
            this.label_white_count.Size = new System.Drawing.Size(115, 29);
            this.label_white_count.TabIndex = 3;
            this.label_white_count.Text = "dfsdfsdfds";
            // 
            // label_White_label
            // 
            this.label_White_label.AutoSize = true;
            this.label_White_label.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_White_label.Location = new System.Drawing.Point(11, 58);
            this.label_White_label.Name = "label_White_label";
            this.label_White_label.Size = new System.Drawing.Size(138, 29);
            this.label_White_label.TabIndex = 2;
            this.label_White_label.Text = "Fehér bábuk:";
            // 
            // label_info_2
            // 
            this.label_info_2.AutoSize = true;
            this.label_info_2.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_info_2.Location = new System.Drawing.Point(150, 11);
            this.label_info_2.Name = "label_info_2";
            this.label_info_2.Size = new System.Drawing.Size(146, 29);
            this.label_info_2.TabIndex = 1;
            this.label_info_2.Text = "sfsdfgdfsgdfg";
            // 
            // label_info_1
            // 
            this.label_info_1.AutoSize = true;
            this.label_info_1.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_info_1.Location = new System.Drawing.Point(11, 11);
            this.label_info_1.Name = "label_info_1";
            this.label_info_1.Size = new System.Drawing.Size(133, 29);
            this.label_info_1.TabIndex = 0;
            this.label_info_1.Text = "Jelenleg lép:";
            // 
            // comboBox_Debug
            // 
            this.comboBox_Debug.FormattingEnabled = true;
            this.comboBox_Debug.Items.AddRange(new object[] {
            "model",
            "gui"});
            this.comboBox_Debug.Location = new System.Drawing.Point(138, 585);
            this.comboBox_Debug.Name = "comboBox_Debug";
            this.comboBox_Debug.Size = new System.Drawing.Size(121, 23);
            this.comboBox_Debug.TabIndex = 7;
            this.comboBox_Debug.SelectedIndexChanged += new System.EventHandler(this.comboBox_Debug_SelectedIndexChanged);
            // 
            // panel_kicked_container_black
            // 
            this.panel_kicked_container_black.BackColor = System.Drawing.Color.Black;
            this.panel_kicked_container_black.Controls.Add(this.panel_kicked_black);
            this.panel_kicked_container_black.Location = new System.Drawing.Point(6, 100);
            this.panel_kicked_container_black.Margin = new System.Windows.Forms.Padding(0);
            this.panel_kicked_container_black.Name = "panel_kicked_container_black";
            this.panel_kicked_container_black.Size = new System.Drawing.Size(350, 92);
            this.panel_kicked_container_black.TabIndex = 5;
            // 
            // panel_kicked_black
            // 
            this.panel_kicked_black.BackColor = System.Drawing.Color.Silver;
            this.panel_kicked_black.BackgroundImage = global::Desktop_Chess.Properties.Resources.wood_kicked;
            this.panel_kicked_black.Location = new System.Drawing.Point(11, 15);
            this.panel_kicked_black.Margin = new System.Windows.Forms.Padding(0);
            this.panel_kicked_black.Name = "panel_kicked_black";
            this.panel_kicked_black.Size = new System.Drawing.Size(327, 62);
            this.panel_kicked_black.TabIndex = 6;
            // 
            // panel_kicked_container_white
            // 
            this.panel_kicked_container_white.BackColor = System.Drawing.Color.White;
            this.panel_kicked_container_white.Controls.Add(this.panel_kicked_white);
            this.panel_kicked_container_white.Location = new System.Drawing.Point(6, 6);
            this.panel_kicked_container_white.Margin = new System.Windows.Forms.Padding(0);
            this.panel_kicked_container_white.Name = "panel_kicked_container_white";
            this.panel_kicked_container_white.Size = new System.Drawing.Size(350, 85);
            this.panel_kicked_container_white.TabIndex = 4;
            // 
            // panel_kicked_white
            // 
            this.panel_kicked_white.BackColor = System.Drawing.Color.Silver;
            this.panel_kicked_white.BackgroundImage = global::Desktop_Chess.Properties.Resources.wood_kicked;
            this.panel_kicked_white.Location = new System.Drawing.Point(11, 9);
            this.panel_kicked_white.Margin = new System.Windows.Forms.Padding(0);
            this.panel_kicked_white.Name = "panel_kicked_white";
            this.panel_kicked_white.Size = new System.Drawing.Size(327, 61);
            this.panel_kicked_white.TabIndex = 5;
            // 
            // Main
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Chess";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel_Container_Top.ResumeLayout(false);
            this.panel_Container_Top.PerformLayout();
            this.panel_Container_Left.ResumeLayout(false);
            this.panel_Container_Right.ResumeLayout(false);
            this.panel_Container_Right.PerformLayout();
            this.panel_Info.ResumeLayout(false);
            this.panel_Info.PerformLayout();
            this.panel_kicked_container_black.ResumeLayout(false);
            this.panel_kicked_container_white.ResumeLayout(false);
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
        public System.Windows.Forms.Panel panel_kicked_container_white;
        public System.Windows.Forms.Panel panel_kicked_container_black;
        public System.Windows.Forms.Panel panel_kicked_white;
        public System.Windows.Forms.Panel panel_kicked_black;
        public System.Windows.Forms.ComboBox comboBox_Debug;
        public System.Windows.Forms.Panel panel_Info;
        public System.Windows.Forms.Label label_info_2;
        public System.Windows.Forms.Label label_info_1;
        public System.Windows.Forms.Label label_black_count;
        public System.Windows.Forms.Label label_black_label;
        public System.Windows.Forms.Label label_white_count;
        public System.Windows.Forms.Label label_White_label;
        public System.Windows.Forms.Label label_Results;
    }
}

