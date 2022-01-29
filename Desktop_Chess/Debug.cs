using ChessBoardModel;
using System;
using System.IO;
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
    public class Debug
    {
        public Main mainForm = null;
        public static RenderMain renderMain;
        static RenderFunctions renderFunctions;
        private static Board model_Board = RenderInit.model_Board;
        private static Gui_Cell[,] guiGrid = RenderInit.guiGrid;
        static public Cell[,] modelGrid = model_Board.theGrid;
        static public Label[,] debugGrid = new Label[8, 8];
        public Panel container;
        public Panel debugPanel;
        public static Size debugCellSize;
        //public bool props = true;
        public static Label debugLabel;
        public static ComboBox debugCombo;
        public static string currentDebugArray;
        
        public Debug(Main ob) { 
            this.mainForm = ob;
        }

        public void GUIdebug()
        {
            renderFunctions = new RenderFunctions(mainForm);
            debugLabel = mainForm.label_DebugSwitch;
            debugCombo = mainForm.comboBox_Debug;
            
            debugLabel.Location = new Point(RenderInit.divRight.Width - debugLabel.Width - 12, (RenderInit.divRight.Height - debugLabel.Height - 12 ) );
            debugLabel.ForeColor = Color.White;
            debugLabel.BringToFront();
            debugCombo.Location = new Point(debugLabel.Location.X - debugCombo.Width - 6, debugLabel.Location.Y);
            

            Panel container = mainForm.panel_Container_Right;
            debugPanel = mainForm.panel_Debug;
            debugPanel.Size = new Size(Convert.ToInt32(container.Width*1)-24, Convert.ToInt32(container.Width*1)-24);
            debugPanel.Location = new Point(12, debugLabel.Location.Y - debugPanel.Height - 6);
            debugPanel.BackColor = Color.Red;
            Size debugCellSize = new Size(debugPanel.Width / 8, debugPanel.Width / 8);
            debugPanel.BringToFront();

            if (mainForm.debugIs) { debugLabel.BackColor = Color.Red; }
            else { debugLabel.BackColor = Color.Green; }

            if (mainForm.debugIs) {
                debugLabel.BackColor = Color.Green;
                debugPanel.Visible = true;
            }
            else
            {
                debugLabel.BackColor = Color.Red;
                debugPanel.Visible = false;
            }
            DebugMatrix(debugPanel, debugCellSize);
        }

        private void DebugMatrix(Panel debugPanel, Size debugCellSize)
        {
            
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    Label debugCell = new Label();
                    debugGrid[x, y] = debugCell;
                    debugCell.Size = debugCellSize;
                    debugCell.Location = new Point(x * debugCellSize.Width, y * debugCellSize.Height);
                    debugCell.Font = new System.Drawing.Font("Impact", 8, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                    debugCell.TextAlign = ContentAlignment.MiddleCenter;
                    debugPanel.Controls.Add(debugCell);
                    debugCell.BringToFront();
                }
            }
        }
        private string getBoardInfo(object cell)
        {
            string text = "";
            switch (cell.GetType().Name)
            {
                case "Cell":
                    Cell modelCell = (Cell)cell;
                    text = $"" +
                        $"{modelCell.X}×{modelCell.Y}";
                    if (modelCell.Figure != null)
                    {
                        Figure modelFigure = modelCell.Figure;
                        text = $"" +
                            $"Side: {modelFigure.Side}" +
                            $"\nType: {modelFigure.Type}" +
                            $"\nID: {modelFigure.ID}" +
                            $"\nKIck: {modelFigure.Kick}" +
                            $"\nColor {modelCell.CellBkgColor}" +
                            $"\n{modelFigure.X}×{modelFigure.Y}";
                    }
                    break;
                case "Gui_Cell":
                    Gui_Cell guiCell = (Gui_Cell)cell;
                    text = $"" +
                        $"{guiCell.X} × {guiCell.Y}";
                    if (guiCell.Type)
                    {
                        if (guiCell.Pupet != null)
                        {
                            Figure modelFigure = guiCell.Pupet;
                            text = $"" +
                                $"Side: {modelFigure.Side}" +
                                $"\nType: {modelFigure.Type}" +
                                $"\nID: {modelFigure.ID}" +
                                $"\nKIck: {modelFigure.Kick}" +
                                $"\n{modelFigure.X}×{modelFigure.Y}";
                        }
                    }
                    break;
            }
            return text;
        }
        public void setMonitoredArray( string array) 
        {
            switch (array)
            {
                case "model":
                    currentDebugArray = "model";
                    break;
                case "gui":
                    currentDebugArray = "gui";
                    break;
            }
            draw2Debug(currentDebugArray);
        }

        public void draw2Debug(string array)
        {
            var r = new Random();
            Cell modelCell;
            Label debugCell;
            Gui_Cell guiCell;

            for (int x = 0; x < model_Board.Size; x++)
            {
                for (int y = 0; y < model_Board.Size; y++)
                {
                    debugCell = debugGrid[x, y];
                    debugCell.BackColor = Color.FromArgb(255, 0, 0, Convert.ToInt32(r.Next(196, 255)));
                    debugCell.ForeColor = Color.White;
                    debugCell.TextAlign = ContentAlignment.MiddleCenter;
                    modelCell = modelGrid[x, y];
                    guiCell = guiGrid[x, y];
                    switch (array)
                    {
                        case "model":
                            debugModelCell(modelCell, debugCell);
                            break;
                        case "gui":
                            debugGuiCell(modelCell,guiCell, debugCell);
                            break;
                    }
                }
            }

        }

        public void debugModelCell(Cell modelCell, Label debugCell)
        {
            var r = new Random();
            if (modelCell.Occupied)
            {
                switch (modelCell.Figure.Side)
                {
                    case "white":
                        debugCell.BackColor = Color.White;
                        debugCell.ForeColor = Color.Black;
                        break;
                    case "black":
                        debugCell.BackColor = Color.Black;
                        debugCell.ForeColor = Color.White;
                        break;
                }
                debugCell.TextAlign = ContentAlignment.TopLeft;
                debugCell.Text = getBoardInfo(modelCell);
            }
            else
            {
                debugCell.BackColor = Color.FromArgb(255, 0, Convert.ToInt32(r.Next(128, 255)), 0 );
                debugCell.ForeColor = Color.Black;
                debugCell.TextAlign = ContentAlignment.MiddleCenter;
                debugCell.Text = getBoardInfo(modelCell);
            }
            if (modelCell.LegalNextMove)
            {
                debugCell.BackColor = Color.Yellow;
                debugCell.Text = getBoardInfo(modelCell);
                debugCell.ForeColor = Color.Green;
                if (modelCell.Figure != null && modelCell.Figure.Kick)
                {
                    debugCell.ForeColor = Color.Red;
                }
            }
        }

        public void debugGuiCell(Cell modelCell, Gui_Cell guiCell, Label debugCell)
        {
            var r = new Random();
            if (guiCell.Type)
            {
                if (guiCell.Pupet != null)
                {
                    switch (guiCell.Pupet.Side)
                    {
                        case "white":
                            debugCell.BackColor = Color.White;
                            debugCell.ForeColor = Color.Black;
                            break;
                        case "black":
                            debugCell.BackColor = Color.Black;
                            debugCell.ForeColor = Color.White;
                            break;
                    }
                }
                debugCell.TextAlign = ContentAlignment.TopLeft;
                debugCell.Text = getBoardInfo(guiCell);
            }
            else
            {
                debugCell.BackColor = Color.FromArgb(255, 0, 0, Convert.ToInt32(r.Next(128, 255)));
                debugCell.ForeColor = Color.White;
                debugCell.TextAlign = ContentAlignment.MiddleCenter;
                debugCell.Text = getBoardInfo(guiCell);
            }
            if (modelCell.LegalNextMove)
            {
                debugCell.BackColor = Color.Yellow;
                debugCell.Text = getBoardInfo(guiCell);
                debugCell.ForeColor = Color.Green;
                if (guiCell.Type && modelCell.Figure.Kick)
                {
                    debugCell.ForeColor = Color.Red;
                }
            }
        }

        public void debugSwitch()
        {
            if (mainForm.debugIs)
            {
                renderFunctions.clearMainboardCellsBorder();
                mainForm.debugIs = false;
                debugPanel.Visible = false;
                debugCombo.Visible = false;
                debugLabel.BackColor = Color.Red;
            }
            else
            {
                mainForm.debugIs = true;
                debugPanel.Visible = true;
                debugCombo.Visible = true;
                debugLabel.BackColor = Color.Green;
            }
        }

    }
}
