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
        //static RenderInit renderInit;
        static Debug debug;
        private static Gui_Cell[,] guiGrid = RenderInit.gui_Grid;
        private static Label[,] debugGrid =  Debug.debugGrid;
        private static Board model_Board = RenderInit.model_Board;
        private static Cell[,] modelGrid = model_Board.theGrid;
        public RenderFunctions(Form_Game ob)
        {
            this.form_game = ob;
            
            renderMain = new RenderMain(form_game);
            debug = new Debug(form_game);
            //renderInit = new RenderInit(form_game);
            
        }

        public void DrawLegalPath(Gui_Figure source)
        {
            //Gui_Figure guiFigure = (Gui_Figure)source;
            int sourceX = source.X;
            int sourceY = source.Y;
            string figureType = source.Type;
            Cell modelCell = modelGrid[sourceX, sourceY];
            //Figure modelFigure = modelCell.Figure;
            model_Board.MarkNextLegalMove(modelCell, figureType);
            debugMain(new Point(sourceX, sourceY), figureType);
            debug.drawDebug(modelGrid);
        }
        public void MoveFigure(Figure source, Gui_Cell targetGuiCell, string skin)
        {
            if (source == null)
            {
                return;
            }
            // set target_modelCell props ( clickedFigure, Occupied = true)
            // set source modelCell props (Figure Cell = null, Occupied = false)
            // set source modelFigure props (targetX,targetY, target_modelCell)
            
            // set target_guiCell props ( Gui_Figure Figure,      //Occupied = true)
            // set source guiFigure props ( targetX,targetY)
            // set source guiFigure location to target_guiCell.Location

            Cell target_modelCell = modelGrid[targetGuiCell.X, targetGuiCell.Y];
            target_modelCell.Occupied = true;
            target_modelCell.Figure = source;

            Cell source_modelCell = modelGrid[source.X, source.Y];
            source_modelCell.Figure = null;
            source_modelCell.Occupied = false;
            Gui_Figure guiFigure = guiGrid[source.X, source.Y].Figure;

            source.X = targetGuiCell.X;
            source.Y = targetGuiCell.Y;
            source.Cell = target_modelCell;
            targetGuiCell.Figure = guiFigure;

            guiFigure.X = targetGuiCell.X;
            guiFigure.Y = targetGuiCell.Y;
            guiFigure.Location = targetGuiCell.Location;
            
            switch (target_modelCell.CellBkgColor)
            {
                case "light":
                guiFigure.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(
                        $"{ skin}_figure_" +
                        $"{ source.Side }_" +
                        $"{ "light" }_" +
                        $"{ source.Type }");

                    break;
                case "dark":
                guiFigure.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(
                        $"{skin}_figure_" +
                        $"{source.Side}_" +
                        $"{"dark"}_" +
                        $"{source.Type}");
                    break;
            }
            clearMainboardCellsBorder();
            model_Board.ClearBoard();
            debug.drawDebug(modelGrid);
            
        }


        public void debugMain(Point location, string figureType)
        {
            if (form_game.debugIs)
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
                            if (modelCell.Figure != null && modelCell.Figure.Kick)
                            {
                                if (guiCell.Figure != null)
                                {
                                    guiCell.Figure.BackColor = Color.Red;
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
