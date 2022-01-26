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
        public Form_Game form_game = null;
        private static Board model_Board = RenderInit.model_Board;
        private static Gui_Cell[,] gui_Grid = RenderInit.gui_Grid;
        static public Cell[,] model_Grid = model_Board.theGrid;
        static public Label[,] debug_Grid = new Label[8, 8];
        public Panel container;
        public Panel debugPanel;
        public static Size debugCellSize;
        public bool props = true;

        public Debug(Form_Game ob) {
            this.form_game = ob;
            form_game = ob;
            
        }

        public void GUIdebug()
        {
            Panel container = form_game.panel_Container_Right;
            Panel debugPanel = form_game.panel_Debug;

            debugPanel.Size = new Size(Convert.ToInt32(container.Width*1)-24, Convert.ToInt32(container.Width*1)-24);
            debugPanel.Location = new Point(12, 12);
            debugPanel.BackColor = Color.Red;
            Size debugCellSize = new Size(debugPanel.Width / 8, debugPanel.Width / 8);
            debugPanel.BringToFront();

            DebugMatrix(debugPanel, debugCellSize,"draw",null);
        }

        private void DebugMatrix(Panel debugPanel, Size debugCellSize, string action, string grid)
        {
            Color[] colors = new Color[2];
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if ( action == "draw")
                    {
                        Label tmpDebugCell = new Label();
                        debug_Grid[x, y] = tmpDebugCell;
                        Cell tmpModelCell = model_Board.theGrid[x, y];
                        Gui_Cell tmpGuiCell = gui_Grid[x, y];

                        switch (tmpModelCell.CellBkgColor)
                        {
                            case "light":
                                colors = new Color[] { Color.White, Color.Black };
                                break;
                            case "dark":
                                colors = new Color[] { Color.Black, Color.White };
                                break;
                        }
                        
                        tmpDebugCell.Size = debugCellSize;
                        tmpDebugCell.Location = new Point(x * debugCellSize.Width, y * debugCellSize.Height);
                        tmpDebugCell.Font = new System.Drawing.Font("Impact", 8, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                        tmpDebugCell.BackColor = colors[0];
                        tmpDebugCell.ForeColor = colors[1];
                        debugPanel.Controls.Add(tmpDebugCell);
                        tmpDebugCell.BringToFront();
                        tmpDebugCell.Text = getBoardInfo(tmpModelCell);
                    }
                    else
                    {

                        Label tmpDebugCell = debug_Grid[x, y];
                        Cell tmpModelCell = model_Board.theGrid[x, y];
                        Gui_Cell tmpGuiCell = gui_Grid[x, y];
                        switch (grid)
                        {
                            case "model":
                                tmpDebugCell.Text = getBoardInfo(tmpModelCell);
                                break;
                            case "gui":
                                tmpDebugCell.Text = getBoardInfo(tmpGuiCell);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        private string getBoardInfo(object cell)
        {
            string text = "";
            switch (cell.GetType().Name)
            {
                case "Cell":
                    Cell tmpModelCell = (Cell)cell;
                    text = $"" +
                        $"{tmpModelCell.CellBkgColor}" +
                        $"\nOccupied: {tmpModelCell.Occupied}" +
                        $"\nLegal: {tmpModelCell.LegalNextMove}" +
                        $"\n{tmpModelCell.X}×{tmpModelCell.Y}";
                    if (tmpModelCell.CellFigure != null)
                    {
                        Figure tmpModelFigure = tmpModelCell.CellFigure;
                        text = $"" +
                            $"Type: {tmpModelFigure.Type}" +
                            $"\nSide: {tmpModelFigure.Side}" +
                            $"\nID: {tmpModelFigure.ID}, KIck: {tmpModelFigure.Kick}" +
                            $"\nCellBkg: {tmpModelFigure.FigureCell.CellBkgColor}" +
                            $"\nCellCoord: {tmpModelFigure.FigureCell.X} × {tmpModelFigure.FigureCell.Y}" +
                            $"\n{tmpModelFigure.X}×{tmpModelFigure.Y}";
                    }
                    break;
                case "Gui_Cell":
                    Gui_Cell tmpGuiCell = (Gui_Cell)cell;
                    text = $"" +
                        $"Legal: {tmpGuiCell.LegalNextMove}" +
                        $"\n{tmpGuiCell.X} × {tmpGuiCell.Y}";
                    if (tmpGuiCell.CellFigure != null)
                    {
                        Button tmpGuiFigure = tmpGuiCell.CellFigure;
                        text = $"" +
                            $"{tmpGuiFigure.Location.X}×{tmpGuiFigure.Location.Y}";
                    }
                    break;
            }
            return text;
        }

        public void debugScanArray( string targetGrid)
        {
            
            switch (targetGrid)//target_Grid.GetType()
            {
                case "model":
                    DebugMatrix(debugPanel, debugCellSize, "scan","model");
                    break;
                case "gui":
                    DebugMatrix(debugPanel, debugCellSize, "scan","gui");
                    break;
            }
        }
    }
}
