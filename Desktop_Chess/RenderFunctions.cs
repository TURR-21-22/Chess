using ChessBoardModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_Chess
{
    class RenderFunctions
    {

        Form_Game form_game = null;
        public static RenderMain renderMain;
        static RenderInit renderInit;
        private Gui_Cell[,] guiGrid = RenderInit.gui_Grid;
        private Label[,] debugGrid =  Debug.debugGrid;
        private static Board model_Board = RenderInit.model_Board;
        


        public RenderFunctions(Form_Game ob)
        {
            this.form_game = ob;
            renderMain = new RenderMain(form_game);
            //renderInit = new RenderInit();
        }

        public void drawDebug(Cell[,] modelGrid)
        {
            var r = new Random();
            foreach (var item in debugGrid)
            {

                item.BackColor = Color.FromArgb(255,
                    0,
                    Convert.ToInt32(r.Next(64, 255)),
                    0
                    );
                item.ForeColor = Color.White;
            }
            for (int x = 0; x < model_Board.Size; x++)
            {
                for (int y = 0; y < model_Board.Size; y++)
                {
                    Cell modelCell = modelGrid[x, y];
                    Label debugCell = debugGrid[x, y];
                    if (modelCell.LegalNextMove)
                    {
                        if (modelCell.CellFigure != null && modelCell.CellFigure.Kick)
                        {
                            debugCell.BackColor = Color.Red;
                            debugCell.ForeColor = Color.White;
                        }
                        else
                        {
                            debugCell.BackColor = Color.Yellow;
                            debugCell.ForeColor = Color.Black;
                        }
                    }
                    else
                    {
                        debugCell.Text = $"";
                    }
                }
            }
        }

        public void drawMain(Point location, string figureType)
        {
            if (renderMain.debugSwitch)
            {
                clearMainboardCellsBorder();
                for (int x = 0; x < model_Board.Size; x++)
                {
                    for (int y = 0; y < model_Board.Size; y++)
                    {
                        Cell modelCell = model_Board.theGrid[x, y];
                        Gui_Cell guiCell = guiGrid[x, y];
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



        public void clearMainboardCellsBorder()
        {
            for (int i = 0; i < RenderInit.gui_whiteFigures.Count; i++)
            {
                RenderInit.gui_whiteFigures[i].BackColor = Color.Black;
                RenderInit.gui_blackFigures[i].BackColor = Color.Black;
            }
            foreach (var item in guiGrid) { item.BackColor = Color.Black; }
        }
    }

    
}
