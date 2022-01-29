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
        Main mainForm = null;
        static RenderInit renderInit;
        static RenderFunctions renderFunctions;
        static Debug debug;
        private static Board model_Board = RenderInit.model_Board;
        private static Cell[,] modelGrid = model_Board.theGrid;
        public static Gui_Cell[,] guiGrid = RenderInit.guiGrid;
        public static Label[,] debugGrid = Debug.debugGrid;
        
        public static int clickCounter = 0;
        //public Figure clickedFigure = null;
        public Cell clickedCell = null;
        //public Gui_Figure clickedGuiFigure = null;

        public RenderMain(Main ob)
        {
            this.mainForm = ob;
        }
        
        public void Init() 
        {
            renderInit = new RenderInit(mainForm);
            renderFunctions = new RenderFunctions(mainForm);
            debug = new Debug(mainForm);
        }

        public void Board_Click(object sender)
        {
            Gui_Cell guiCell = (Gui_Cell)sender;
            Cell modelCell = modelGrid[guiCell.X, guiCell.Y];
            Figure modelFigure = modelGrid[guiCell.X, guiCell.Y].Figure;
            switch (guiCell.Type)
            {
                case true:
                    if (!modelFigure.Kick)
                    {
                        renderFunctions.DrawLegalPath( guiCell, modelFigure.Type);
                        clickedCell = modelCell;
                    }
                    else
                    {
                        renderFunctions.KickFigure(guiCell, modelCell, renderInit.Skin);
                    }
                    break;
                case false:
                    if (modelCell.LegalNextMove)
                    {
                        renderFunctions.MoveFigure( guiCell, clickedCell, renderInit.Skin );
                    }
                    break;
            }


            //mainForm.listBox1.Items.Add(guiCell.Type);
            /*
            Gui_Cell guiCell;
            switch (sender.GetType().Name)
            {
                case "Gui_Cell":
                    Gui_Cell tmpCell = (Gui_Cell)sender;
                    Cell modelCell = modelGrid[tmpCell.X, tmpCell.Y];
                    if (modelCell.LegalNextMove)
                    {
                        //guiGrid[tmpCell.X, tmpCell.Y].Visible = false;
                        //renderFunctions.MoveFigure(clickedFigure, clickedGuiFigure, guiCell, renderInit.Skin);
                        clickedFigure = null;
                    }
                    break;
                case "Gui_Figure":
                    Gui_Figure guiFigure = (Gui_Figure)sender;
                    //mainForm.listBox1.Items.Add(guiGrid[guiFigure.X, guiFigure.Y].FigureNr);
                    mainForm.listBox1.Items.Add(guiFigure.FigureNr);
                    guiFigure.Visible = false;

                    //RenderInit.gui_whiteFigures[guiFigure.FigureNr].Visible = false;

                    //guiGrid[1, 1].Visible = false;
                    //guiGrid[1, 1].Figure.Visible = false;
                    //guiFigure.Visible = false;
                    //guiGrid[1, 0].Visible = false;

                    guiCell = guiGrid[guiFigure.X, guiFigure.Y];
                    Figure modelFigure = modelGrid[guiFigure.X, guiFigure.Y].Figure;
                    if (!modelFigure.Kick)
                    {
                        if (oldFigure != null)
                        {
                            oldFigure.BackColor = Color.Black;
                        }
                        
                        renderFunctions.DrawLegalPath(guiFigure);

                        
                        //guiGrid[guiFigure.X, guiFigure.Y].Visible = false;
                        //guiGrid[guiFigure.X, guiFigure.Y].Figure.Visible = false;

                        clickedFigure = modelGrid[guiFigure.X, guiFigure.Y].Figure;
                        //clickedGuiFigure = guiCell;
                        //oldFigure = guiFigure;
                    }
                    else
                    {
                        renderFunctions.KickFigure(guiFigure);
                        renderFunctions.MoveFigure(clickedFigure, clickedGuiFigure, guiCell, renderInit.Skin);
                        guiFigure.BringToFront();
                        clickedFigure = null;
                        clickedGuiFigure = null;
                    }
                    break;
                }
*/
        }

        public void SelectSkin(object sender)
        {
            ComboBox cmb = (ComboBox)sender;

            renderInit.RestartGui(cmb.SelectedItem.ToString());
        }


    }
}
