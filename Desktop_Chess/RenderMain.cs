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
        public Figure clickedFigure = null;
        public Gui_Figure oldFigure = null;

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
            Gui_Cell guiCell;
            switch (sender.GetType().Name)
            {
                case "Gui_Cell":
                    guiCell = (Gui_Cell)sender;
                    Cell modelCell = modelGrid[guiCell.X, guiCell.Y];
                    if (modelCell.LegalNextMove)
                    {
                        renderFunctions.MoveFigure(clickedFigure, guiCell, renderInit.Skin);
                        clickedFigure = null;
                    }
                    break;
                case "Gui_Figure":
                    Gui_Figure guiFigure = (Gui_Figure)sender;
                    guiCell = guiGrid[guiFigure.X, guiFigure.Y];
                    Figure modelFigure = modelGrid[guiFigure.X, guiFigure.Y].Figure;
                    if (!modelFigure.Kick)
                    {
                        if (oldFigure != null)
                        {
                            oldFigure.BackColor = Color.Black;
                        }
                        renderFunctions.DrawLegalPath(guiFigure);
                        clickedFigure = modelGrid[guiFigure.X, guiFigure.Y].Figure;
                        oldFigure = guiFigure;
                    }
                    else
                    {
                        renderFunctions.KickFigure(guiFigure);
                        renderFunctions.MoveFigure(clickedFigure, guiCell, renderInit.Skin);
                        guiFigure.BringToFront();
                        clickedFigure = null;
                    }
                    break;
            }
            
        }


        public void SelectSkin(object sender)
        {
            ComboBox cmb = (ComboBox)sender;

            renderInit.RestartGui(cmb.SelectedItem.ToString());
        }


    }
}
