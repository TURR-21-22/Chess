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

        private bool swap = false;
        static public Cell[,] model_Grid = model_Board.theGrid;
        static public Label[,] debug_Grid = new Label[8, 8];
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

            debugPanel.Size = new Size(Convert.ToInt32(container.Width*1)-24, Convert.ToInt32(container.Width*1)-24);
            debugPanel.Location = new Point(12, 12);
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
                    SetCellDatas(debugPanel, x, y, debugCell, debugCellSize, colors, model_Grid);
                }
            }
        }


        public void RefreshtCellDatas( string targetGrid)
        {
            switch (targetGrid)//target_Grid.GetType()
            {
                case "model_Board":
                    scanModelArray();
                    break;
                case "gui_Grid":
                    scanGUIArray();
                    break;
            }
        }

        public void scanGUIArray()
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    Gui_Cell tmpCell = gui_Grid[x, y];

                    if (tmpCell.CellFigure != null)
                    {
                        Button tmpFigure = tmpCell.CellFigure;
                        debug_Grid[x, y].Text = $"";
                    }
                    else
                    {
                        {
                            debug_Grid[x, y].Text = $"";
                        }
                    }
                }
            }
        }

        public void scanModelArray()
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (model_Grid[x, y].LegalNextMove)
                    {
                        Cell tmpCell = model_Board.theGrid[x, y];
                        if (tmpCell.CellFigure != null)
                        {
                            if (model_Grid[x, y].CellFigure.Kick)
                            {
                                Figure tmpFigure = model_Board.theGrid[x, y].CellFigure;
                                debug_Grid[x, y].Text = $"" +
                                     $"{ tmpFigure.Type }" +
                                     $"\n{ tmpFigure.Side }" +
                                     $"\n{ tmpFigure.ID } :: ({ tmpFigure.X } × { tmpFigure.Y })";
                            }
                        }
                        else
                        {
                            debug_Grid[x, y].Text = $"legal";
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
            debugCell.Location = new Point( x * debugCellSize.Width, y * debugCellSize.Height);
            debugCell.Font = new System.Drawing.Font("Impact", 12, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            debugCell.BackColor = colors[0];
            debugCell.ForeColor = colors[1];
            if (model_Grid[x, y].Occupied)
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
