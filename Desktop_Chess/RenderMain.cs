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
                    Cell tmpModelCell = model_Board.theGrid[x, y];
                    Gui_Cell  tmpGuiCell = gui_Grid[x, y];
                    Label tmpDebugCell = debug_Grid[x, y];
                    Color[] tmpCellBkgColors = { Color.White,Color.Black };

                    tmpDebugCell.Text = $"" +
                       $"{tmpModelCell.CellBkgColor}";

                    switch (tmpModelCell.CellBkgColor)
                    {
                        case "light":
                            tmpDebugCell.BackColor = tmpCellBkgColors[0];
                            tmpDebugCell.ForeColor = tmpCellBkgColors[1];
                            break;
                        case "dark":
                            tmpDebugCell.BackColor = tmpCellBkgColors[1];
                            tmpDebugCell.ForeColor = tmpCellBkgColors[0];
                            break;
                        default:
                            break;
                    }
                    if (model_Board.theGrid[x, y].LegalNextMove)
                    {
                        
                        if (tmpModelCell.CellFigure != null)
                        {
                            if (model_Board.theGrid[x, y].CellFigure.Kick)
                            {

                                tmpGuiCell.BackColor = Color.Red;
                                Figure tmpFigure = tmpModelCell.CellFigure;
                                tmpDebugCell.Text += $"\n>> Kick <<";
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
                            tmpDebugCell.Text = $"Legal" +
                                $"\n{tmpModelCell.CellBkgColor}";
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
