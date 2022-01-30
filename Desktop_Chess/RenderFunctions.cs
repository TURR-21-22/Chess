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
        Main mainForm = null;
        public static RenderMain renderMain;
        public static Debug debug;
        public static RenderInit renderInit;
        private static Gui_Cell[,] guiGrid = RenderInit.guiGrid;
        private static Board model_Board = RenderInit.model_Board;
        private static Figures model_Figures = RenderInit.model_Figures;
        //private static List<Gui_Cell> guiKickedWhites = RenderInit.guiKickedWhites;
        private static Cell[,] modelGrid = model_Board.theGrid;
        public RenderFunctions(Main ob)
        {
            this.mainForm = ob;
            renderMain = new RenderMain(mainForm);
            //renderInit = new RenderInit(mainForm);
            debug = new Debug(mainForm);
        }

        public void DrawLegalPath(Gui_Cell source, string type)
        {
            clearMainboardCellsBorder();
            Cell modelCell = modelGrid[source.X, source.Y];
            model_Board.MarkNextLegalMove(modelCell, type);
            source.BackColor = Color.Yellow;
            displayPath(new Point(source.X, source.Y), type);
            debug.draw2Debug(Debug.currentDebugArray);
        }

        public void KickFigure(Gui_Cell targetGuiCell, Cell sourceModelCell, string skin) 
        {
            Cell targetModelCell = modelGrid[targetGuiCell.X, targetGuiCell.Y];
            Gui_Cell container;
            switch (targetModelCell.Figure.Side)
            {
                case "white":
                    model_Figures.Model_whiteFiguresOFF.Add(targetModelCell.Figure);
                    container = RenderInit.guiKickedWhites[model_Figures.Model_whiteFiguresOFF.Count - 1];
                    setKickedSkin(container, targetModelCell, skin);
                    container.Pupet = targetModelCell.Figure;
                    break;
                case "black":
                    model_Figures.Model_blackFiguresOFF.Add(targetModelCell.Figure);
                    container = RenderInit.guiKickedBlacks[model_Figures.Model_blackFiguresOFF.Count - 1];
                    setKickedSkin(container, targetModelCell, skin);
                    container.Pupet = targetModelCell.Figure;
                    break;
            }
            MoveFigure(targetGuiCell, sourceModelCell, skin);
            debug.draw2Debug(Debug.currentDebugArray);
        }

        private void setKickedSkin(Gui_Cell container, Cell targetModelCell, string skin)
        {
            string mod = "";
            switch (container.KickedBkgColor)
            {
                case "white":
                    mod = "light";
                    break;
                case "black":
                    mod = "dark";
                    break;
            }
            container.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject($"{skin}_figure_" +
                               $"{targetModelCell.Figure.Side}_" +
                               $"{mod}_" +
                               $"{targetModelCell.Figure.Type}");
        }

        public void MoveFigure(Gui_Cell targeGuitCell, Cell sourceCell, string skin)
        {
            Gui_Cell sourceGuiCell = guiGrid[sourceCell.X, sourceCell.Y];
            Cell targetCell = modelGrid[targeGuitCell.X, targeGuitCell.Y];
            string backColor = "";
            if (targetCell.CellBkgColor == "light") { backColor = "light"; } else { backColor = "dark"; };
            targeGuitCell.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(
                $"{skin}_figure_{sourceCell.Figure.Side}_{backColor}_{sourceCell.Figure.Type}");
            if (sourceCell.CellBkgColor == "light") { backColor = "white"; } else { backColor = "black"; };
            sourceGuiCell.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject($"{skin}_cell_{backColor}");
            targetCell.Occupied = true;
            targetCell.Figure = sourceCell.Figure;
            targetCell.Figure.X = targetCell.X;
            targetCell.Figure.Y = targetCell.Y;
            sourceCell.Occupied = false;
            sourceCell.Figure = null;
            targeGuitCell.Type = true;
            targeGuitCell.Pupet = sourceGuiCell.Pupet;
            sourceGuiCell.Type = false;
            sourceGuiCell.Pupet = null;
            clearMainboardCellsBorder();
            model_Board.ClearBoard();
            debug.draw2Debug(Debug.currentDebugArray);
        }


        public void displayPath(Point location, string figureType)
        {
            if (mainForm.debugIs)
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
                                if (guiCell.Type)
                                {
                                    guiCell.BackColor = Color.Red;
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
            foreach (var item in guiGrid) { item.BackColor = Color.Black; }
        }
        

    }
}
