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
        private static Gui_Cell[,] guiGrid = RenderInit.guiGrid;
        private static Label[,] debugGrid =  Debug.debugGrid;
        private static Board model_Board = RenderInit.model_Board;
        private static Cell[,] modelGrid = model_Board.theGrid;
        public static int whiteFiguresCounter = Board.model_Figures.Model_blackFiguresON.Count;
        public static int blackFiguresCounter = Board.model_Figures.Model_blackFiguresON.Count;
        public static int whiteKickedFiguresCounter;
        public static int blackKickedFiguresCounter;
        public static List<Gui_Figure> kickedWhites = new List<Gui_Figure>();
        public static List<Gui_Figure> kickedBlacks = new List<Gui_Figure>();
        public static Point[] kickedPanelCoords;
        
        public RenderFunctions(Main ob)
        {
            this.mainForm = ob;
            renderMain = new RenderMain(mainForm);
            debug = new Debug(mainForm);
            kickedPanelCoords = RenderInit.kickedPanelCoords;
            whiteKickedFiguresCounter = 0;
            blackKickedFiguresCounter = 0;
        }

        public void DrawLegalPath(Gui_Cell source, string type)
        {
            Cell modelCell = modelGrid[source.X, source.Y];
            model_Board.MarkNextLegalMove(modelCell, type);
            source.BackColor = Color.Yellow;
            displayPath(new Point(source.X, source.Y), type);
            debug.draw2Debug(Debug.currentDebugArray);
        }

        public void KickFigure(Gui_Cell targetGuiCell, Cell sourceCell, string skin) 
        {/*
            int kickedCellSize = RenderInit.kickedCellSize;
            int cellSize = RenderInit.cellSize;
            
            Figure modelFigure = modelGrid[guiFigure.X, guiFigure.Y].Figure;
            
            guiFigure.Kick = false;
            guiFigure.LegalNextMove = false;
            modelFigure.Kick = false;
            modelFigure.LegalNextMove = false;
            guiFigure.Size = new Size(kickedCellSize, kickedCellSize);
            switch (modelFigure.Side)
            {
                case "white":

                    //model_whiteFiguresOFF.Add(modelFigure);
                    
                    //mainForm.panel_kicked_white.Controls.Remove(guiFigure);
                    mainForm.panel_kicked_white.Controls.Add(guiFigure);
                    
                    //guiFigure.Location = kickedPanelCoords[model_whiteFiguresOFF.Count-1];
                    guiFigure.Location = kickedPanelCoords[whiteKickedFiguresCounter];
                    //mainForm.listBox1.Items.Add(model_whiteFiguresOFF.Count);
                    whiteKickedFiguresCounter++;
                    break;
                case "black":
                    //model_blackFiguresOFF.Add(modelFigure);
                    
                    //mainForm.panel_kicked_black.Controls.Remove(guiFigure);
                    mainForm.panel_kicked_black.Controls.Add(guiFigure);
                    
                    //guiFigure.Location = kickedPanelCoords[model_blackFiguresOFF.Count-1];
                    guiFigure.Location = kickedPanelCoords[blackKickedFiguresCounter];
                    //mainForm.listBox1.Items.Add(model_blackFiguresOFF.Count);
                    blackKickedFiguresCounter++;
                    break;
            }
            guiFigure.Click -= mainForm.Board_Click;


            /*
            for (int i = 0; i < kickedPanelCoords.Length; i++)
            {
                mainForm.listBox1.Items.Add(kickedPanelCoords[i]);
            }
            */

            //guiFigure.Click += 

            //Debug.debugLabel.Text = $"{whiteFiguresCounter}";
            //Debug.debugLabel.Text = $"{kickedCellSize}";
            // figureCounter--
            // if figurecounter == 0 game over
            // figure property: Cell = null, LegalNextMove = false, Kick = false
            //int size = RenderInit.kickedCellSize;
            //guiGrid[guiFigure.X, guiFigure.Y].Visible = false;
            //guiGrid[guiFigure.X, guiFigure.Y].Figure.Visible = false;
            //guiFigure.Visible = false;
            //mainForm.panel_ChessBoard.Controls.Remove(guiGrid[guiFigure.X, guiFigure.Y].Figure);
            //guiGrid[guiFigure.X, guiFigure.Y].Figure = null;

            
            //guiFigure.Location = new Point(RenderInit.cellSize * 0, RenderInit.cellSize * 7);
            //RenderMain.guiGrid[guiFigure.X, guiFigure.Y].Figure.Location = new Point(RenderInit.cellSize * 0, RenderInit.cellSize * 7);
            //guiFigure.Kick = false;
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
            for (int i = 0; i < RenderInit.gui_whiteFigures.Count; i++)
            {
                RenderInit.gui_whiteFigures[i].BackColor = Color.Black;
                RenderInit.gui_blackFigures[i].BackColor = Color.Black;
            }
            foreach (var item in guiGrid) { item.BackColor = Color.Black; }
        }
        

    }
}
