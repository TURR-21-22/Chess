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

    public class RenderMain
    {
        Form_Game form_game = null;
        static RenderInit renderInit;
        static Debug debug;
        private static Board model_Board = RenderInit.model_Board;
        public static Gui_Cell[,] gui_Grid = RenderInit.gui_Grid;
        public static Label[,] debug_Grid = Debug.debug_Grid;
        public bool debugSwitch = true; 
        public RenderMain(Form_Game ob)
        {
            this.form_game = ob;
        }

        public void Init() 
        {
            renderInit = new RenderInit(form_game);
            debug = new Debug(form_game);
        }

        internal void Board_Click(object sender)
        {

            Point location;
            string figureType;
            Gui_Cell clickedCell;
            Gui_Figure clickedFigure;

            switch (sender.GetType().Name)
            {
                case "Gui_Cell":
                    break;
                case "Gui_Figure":
                    clickedFigure = (Gui_Figure)sender;
                    Cell[,] modelGrid = model_Board.theGrid;
                    location = new Point(clickedFigure.X, clickedFigure.Y);
                    figureType = clickedFigure.Type;

                    drawMain(location, figureType);
                    drawDebug(modelGrid);
                    break;
            }
        }

        public void clearBordersMain() 
        {
            for (int i = 0; i < RenderInit.gui_whiteFigures.Count; i++)
            {
                RenderInit.gui_whiteFigures[i].BackColor = Color.Black;
                RenderInit.gui_blackFigures[i].BackColor = Color.Black;
            }
            foreach (var item in gui_Grid) { item.BackColor = Color.Black; }
        }

        public void drawDebug( Cell[,] modelGrid) 
        {
            bool swap = true;
            foreach (var item in debug_Grid) {
                if (swap)
                {
                    item.BackColor = Color.Green;
                }
                else
                {
                    item.BackColor = Color.SlateBlue;
                }
                item.ForeColor = Color.White;
                swap = !swap;
            }
            for (int x = 0; x < model_Board.Size; x++)
            {
                for (int y = 0; y < model_Board.Size; y++)
                {
                    Cell modelCell = modelGrid[x, y];
                    Label debugCell = debug_Grid[x, y];

                    if (modelCell.LegalNextMove)
                    {
                        if (modelCell.CellFigure != null && modelCell.CellFigure.Kick)
                        {
                            debugCell.BackColor = Color.Red;
                        }
                        else
                        {
                            debugCell.BackColor = Color.Yellow;
                        }
                    }
                }
            }
        }
 
        public void drawMain(Point location, string figureType)
        {
            Cell currenCell = model_Board.theGrid[location.X, location.Y];
            model_Board.MarkNextLegalMove(currenCell, figureType);

            if (debugSwitch)
            {
                clearBordersMain();
                for (int x = 0; x < model_Board.Size; x++)
                {
                    for (int y = 0; y < model_Board.Size; y++)
                    {
                        Cell modelCell = model_Board.theGrid[x, y];
                        Gui_Cell guiCell = gui_Grid[x, y];


                        if (modelCell.LegalNextMove)
                        {
                            if (modelCell.CellFigure != null && modelCell.CellFigure.Kick)
                            {
                                if (guiCell.CellFigure != null)
                                {
                                    guiCell.CellFigure.BackColor = Color.Red;
                                }
                                guiCell.BackColor = Color.Red;
                            }
                            else
                            {
                                guiCell.BackColor = Color.Yellow;
                            }
                        }
                    }
                }
            }
        }

        internal void SelectSkin(object sender)
        {
            ComboBox cmb = (ComboBox)sender;
            renderInit.RestartGui(cmb.SelectedItem.ToString());
        }
        
    }
}
