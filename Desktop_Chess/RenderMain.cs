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
        private static Board model_Board = RenderInit.model_Board;
        private static Cell[,] modelGrid = model_Board.theGrid;
        public static Gui_Cell[,] guiGrid = RenderInit.guiGrid;
        public static Label[,] debugGrid = Debug.debugGrid;
        public static string currentPlayer = "white";
        public Cell clickedCell = null;

        public RenderMain(Main ob)
        {
            this.mainForm = ob;
        }
        
        public void Init() 
        {
            renderInit = new RenderInit(mainForm);
            renderFunctions = new RenderFunctions(mainForm);
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
                        if (currentPlayer == modelFigure.Side)
                        {
                            renderFunctions.DrawLegalPath(guiCell, modelFigure.Type);
                            clickedCell = modelCell;
                        }
                    }
                    else
                    {
                        renderFunctions.KickFigure(guiCell, clickedCell,  renderInit.Skin);
                        swithcPlayer();
                    }
                    break;
                case false:
                    if (modelCell.LegalNextMove)
                    {
                        renderFunctions.MoveFigure( guiCell, clickedCell, renderInit.Skin );
                        swithcPlayer();
                    }
                    break;
            }
        }

        private void swithcPlayer()
        {
            if (currentPlayer == "white") { currentPlayer = "black"; }
            else { currentPlayer = "white"; }
        }

        public void SelectSkin(object sender)
        {
            ComboBox cmb = (ComboBox)sender;

            renderInit.RestartGui(cmb.SelectedItem.ToString());
        }


    }
}
