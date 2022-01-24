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
        private static Board model_Board = RenderInit.model_Board;
        public static Button[,] boardGrid = RenderInit.boardGrid;

        public RenderMain(Form_Game ob)
        {
            this.form_game = ob;
        }

        public void Init() 
        {
            renderInit = new RenderInit(form_game);
        }

        internal void PicFigure(object sender)
        {
            Button clickedButton = (Button)sender;
            Point location;
            string figureType;
            Figure clickedFigure;
            if (clickedButton.Tag.GetType() == typeof(Figure))
            {
                clickedFigure = (Figure)clickedButton.Tag;
                location = new Point( clickedFigure.X, clickedFigure.Y );
                figureType = clickedFigure.Type;
            }
            else
            {
                //location = (Point)clickedButton.Tag;
                return;
            }
 
            Cell currenCell = model_Board.theGrid[location.X, location.Y];

            model_Board.MarkNextLegalMove(currenCell, figureType);
            for (int x = 0; x < model_Board.Size; x++)
            {
                for (int y = 0; y < model_Board.Size; y++)
                {
                    boardGrid[x, y].Text = "";
                    if (model_Board.theGrid[x, y].LegalNextMove)
                    {
                        boardGrid[x, y].Text = "Legal";
                        if (model_Board.theGrid[x, y].CurrentlyOccupied)
                        {
                            clickedButton.Text = "AAAAA";
                            if (boardGrid[x, y].Tag.GetType() == typeof(Figure))
                            {
                                Figure figure = (Figure)boardGrid[x, y].Tag;
                                
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
