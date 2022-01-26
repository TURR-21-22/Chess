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
        //public RenderMain(Form_Game ob) { this.form_game = ob; }
        static RenderInit renderInit;
        static Debug debug;
        private static Board model_Board = RenderInit.model_Board;
        public static Gui_Cell[,] gui_Grid = RenderInit.gui_Grid;

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
            Figure clickedFigure;
            
            if (sender.GetType().Name == "Button")
            {
                Button clickedButton = (Button)sender;
                if (clickedButton.Tag.GetType() == typeof(Figure))
                {
                    clickedFigure = (Figure)clickedButton.Tag;
                    location = new Point(clickedFigure.X, clickedFigure.Y);
                    figureType = clickedFigure.Type;
                    draw2Debug(location, figureType);
                }
            }
            else if (sender.GetType().Name == "Gui_Cell")
            {
                return;
            }

        }

        public void draw2Debug(Point location, string figureType)
        {
            Cell currenCell = model_Board.theGrid[location.X, location.Y];
            for (int i = 0; i < RenderInit.gui_whiteFigures.Count; i++)
            {
                RenderInit.gui_whiteFigures[i].BackColor = Color.Black;
                RenderInit.gui_blackFigures[i].BackColor = Color.Black;
            }


                model_Board.MarkNextLegalMove(currenCell, figureType);
            for (int x = 0; x < model_Board.Size; x++)
            {
                
                for (int y = 0; y < model_Board.Size; y++)
                {
                    gui_Grid[x, y].BackColor = Color.Black;
                    
                    Debug.debug_Grid[x, y].Text = "";
                    
                    if (model_Board.theGrid[x, y].LegalNextMove)
                    {
                        Cell tmpCell = model_Board.theGrid[x, y];
                        if (tmpCell.CellFigure != null)
                        {
                            if (model_Board.theGrid[x, y].CellFigure.Kick)
                            {
                                
                                gui_Grid[x, y].CellFigure.BackColor = Color.Red;
                                Figure tmpFigure = model_Board.theGrid[x, y].CellFigure;
                                Debug.debug_Grid[x, y].Text = $"Kick";
                                /*
                                Debug.debug_Grid[x, y].Text = $"" +
                                    $"{ tmpFigure.Type }" +
                                    $"\n{ tmpFigure.Side }" +
                                    $"\n{ tmpFigure.ID } :: ({ tmpFigure.X } × { tmpFigure.Y })";
                            */
                            }
                        }
                        else
                        {
                            gui_Grid[x, y].BackColor = Color.White;
                            Debug.debug_Grid[x, y].Text = $"Legal";
                        }
                    }

                    /*
                    else
                    {
                        gui_Grid[x, y].BackColor = Color.Black;
                        Debug.debug_Grid[x, y].Text = "";
                    }
                    */
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
