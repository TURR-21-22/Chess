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
        private bool swap = false;
        public Cell[,] model_Grid = model_Board.theGrid;
        public Label[,] debug_Grid = new Label[8, 8];
        public static Panel container;
        public static Panel debugPanel;
        public Debug(Form_Game ob) {
            this.form_game = ob;
            form_game = ob;
        
        }

        private Color[] swapProps()
        {
            Color[] colors = new Color[2];
            if (swap == true)
            {
                colors[0] = Color.DarkBlue;
                colors[1] = Color.White;
            }
            else
            {
                colors[0] = Color.CadetBlue;
                colors[1] = Color.Black;
            }
            swap = !swap;
            return colors;

        }

        public void GUIdebug()
        {
            Panel container = form_game.panel_Container_Right;
            Panel debugPanel = form_game.panel_Debug;

            debugPanel.Size = new Size(container.Width, container.Width+2);
            debugPanel.Location = new Point(0, 0);
            debugPanel.BackColor = Color.Red;
            Size debugCellSize = new Size(debugPanel.Width / 8, debugPanel.Width / 8);
            
            debugPanel.BringToFront();
            
            Color[] colors;
            Random r = new Random();

            for (int x = 0; x < 8; x++)
            {
                colors = swapProps();
                for (int y = 0; y < 8; y++)
                {
                    colors = swapProps();
                    Label debugCell = new Label();
                    debug_Grid[x, y] = debugCell;
                    SetCellDatas(container, x, y, debugCell, debugCellSize, colors, model_Grid);
                }
            }
        }


        public void RefreshtCellDatas(Label[,] debug_Grid , Cell[,] model_Grid)
        {

            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (model_Grid[x, y].CurrentlyOccupied)
                    {
                        if (debug_Grid.Length > 0)
                        {
                            debug_Grid[x, y].Text = $"Occupied" +
                            $"\n{ model_Grid[x, y].CellFigure.ID}" +
                            $"\n{ model_Grid[x, y].CellFigure.Type}" +
                            $"\n{ model_Grid[x, y].CellFigure.Side}" +
                            $"REFRESHED !";
                        }
                    }
                    else
                    {
                        debug_Grid[x, y].Text = $"";
                    }
                }
            }
        }

        private void SetCellDatas(Panel container, int x,int y,Label debugCell, Size debugCellSize, Color[] colors, Cell[,] model_Grid)
        {
            debugCell.Size = debugCellSize;
            debugCell.Location = new Point(x * debugCellSize.Width, y * debugCellSize.Height);
            debugCell.Font = new System.Drawing.Font("Arial Narrow", 10, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            debugCell.BackColor = colors[0];
            debugCell.ForeColor = colors[1];
            if (model_Grid[x, y].CurrentlyOccupied)
            {
                debugCell.Text = $"Occupied" +
                    $"\n{ model_Grid[x, y].CellFigure.ID}" +
                    $"\n{ model_Grid[x, y].CellFigure.Type}" +
                    $"\n{ model_Grid[x, y].CellFigure.Side}" +
                    $"";
            }
            else
            {
                debugCell.Text = $"";
            }
            container.Controls.Add(debugCell);
            debugCell.BringToFront();
        }


    }
}
