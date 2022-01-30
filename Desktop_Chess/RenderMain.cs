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
        public static Figures model_Figures = new Figures();
        private static Cell[,] modelGrid = model_Board.theGrid;
        public static Gui_Cell[,] guiGrid = RenderInit.guiGrid;
        public static Label[,] debugGrid = Debug.debugGrid;
        public static string currentPlayer = "white";
        public static bool whitePlayerCanExchange = false;
        public static bool blackPlayerCanExchange = false;
        public static Cell exchangeCell;
        public static bool exchangeDone = true;
        public static int whiteFiguresCount = model_Figures.Model_whiteFiguresON.Count;
        public static int blackFiguresCount = model_Figures.Model_blackFiguresON.Count;


        public void ChkSakk()
        {
            for (int x = 0; x < model_Board.Size; x++)
            {
                for (int y = 0; y < model_Board.Size; y++)
                {
                    
                    if (modelGrid[x,y].Figure != null && modelGrid[x, y].Figure.Type == "kiraly" && modelGrid[x, y].Figure.Type != currentPlayer)
                    {
                        mainForm.label_Results.Text = $"" +
                            $"{modelGrid[x, y].Figure.Side}" +
                            $"\n{modelGrid[x, y].Figure.Type}";
                    }
                }
            }
        }


        internal void Kicked_Click(object sender)
        {
            Gui_Cell guiCell = (Gui_Cell)sender;
            int x = 0;
            int y = 0;
            
            if (whitePlayerCanExchange && exchangeDone == false) //  && guiCell.Pupet != null
            {
                x = exchangeCell.X;
                y = exchangeCell.Y;
                exchangeCell.Figure = guiCell.Pupet;
                exchangeCell.Figure.Cell = exchangeCell;
                exchangeCell.Figure.X = x;
                exchangeCell.Figure.Y = y;
                exchangeCell.Figure.Kick = false;
                exchangeCell.Figure.Replaceable = false;
                guiGrid[x, y].Pupet = exchangeCell.Figure;
                guiGrid[x, y].Type = true;
                guiGrid[x, y].BackgroundImage = guiCell.BackgroundImage;
                switch (exchangeCell.CellBkgColor)
                {
                    case "light":
                        guiGrid[x, y].BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject($"{renderInit.Skin}_figure_" +
                                $"{guiCell.Pupet.Side}_" +
                                $"{"light"}_" +
                                $"{guiCell.Pupet.Type}");
                        break;
                    case "dark":
                        guiGrid[x, y].BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject($"{renderInit.Skin}_figure_" +
                                $"{guiCell.Pupet.Side}_" +
                                $"{"dark"}_" +
                                $"{guiCell.Pupet.Type}");
                        break;
                }
                RenderInit.kickedWhitesContainer.BackColor = Color.White;
                model_Figures.Model_whiteFiguresOFF.Remove(exchangeCell.Figure);
                model_Figures.Model_whiteFiguresON.Remove(exchangeCell.Figure);
                renderInit.RefreshKickeds(model_Figures.Model_whiteFiguresOFF, RenderInit.guiKickedWhites);
                exchangeDone = true;
            }

            if (blackPlayerCanExchange && exchangeDone == false) //  && guiCell.Pupet != null
            {
                x = exchangeCell.X;
                y = exchangeCell.Y;
                exchangeCell.Figure = guiCell.Pupet;
                exchangeCell.Figure.Cell = exchangeCell;
                exchangeCell.Figure.X = x;
                exchangeCell.Figure.Y = y;
                exchangeCell.Figure.Kick = false;
                exchangeCell.Figure.Replaceable = false;
                guiGrid[x, y].Pupet = exchangeCell.Figure;
                guiGrid[x, y].Type = true;
                guiGrid[x, y].BackgroundImage = guiCell.BackgroundImage;
                switch (exchangeCell.CellBkgColor)
                {
                    case "light":
                        guiGrid[x, y].BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject($"{renderInit.Skin}_figure_" +
                                $"{guiCell.Pupet.Side}_" +
                                $"{"light"}_" +
                                $"{guiCell.Pupet.Type}");
                        break;
                    case "dark":
                        guiGrid[x, y].BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject($"{renderInit.Skin}_figure_" +
                                $"{guiCell.Pupet.Side}_" +
                                $"{"dark"}_" +
                                $"{guiCell.Pupet.Type}");
                        break;
                }
                RenderInit.kickedBlacksContainer.BackColor = Color.Black;
                model_Figures.Model_blackFiguresOFF.Remove(exchangeCell.Figure);
                model_Figures.Model_blackFiguresON.Add(exchangeCell.Figure);
                renderInit.RefreshKickeds(model_Figures.Model_blackFiguresOFF, RenderInit.guiKickedBlacks);
                exchangeDone = true;
            }
            
        }

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
            if (!exchangeDone)
            {
                return;
            }
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
                        mainForm.label_white_count.Text = $"{whiteFiguresCount}";
                        mainForm.label_black_count.Text = $"{blackFiguresCount}";
                        ChkSakk();
                    }
                    break;
                case false:
                    if (modelCell.LegalNextMove)
                    {
                        renderFunctions.MoveFigure( guiCell, clickedCell, renderInit.Skin );

                        swithcPlayer();
                        mainForm.label_white_count.Text = $"{whiteFiguresCount}";
                        mainForm.label_black_count.Text = $"{blackFiguresCount}";
                        ChkSakk();
                    }
                    break;
            }
        }


        private void swithcPlayer()
        {
            if (currentPlayer == "white")
            {
                currentPlayer = "black";
                RenderInit.infoLabel2.Text = "Fekete játékos.";
            }
            else
            {
                currentPlayer = "white";
                RenderInit.infoLabel2.Text = "Fehér játékos.";
            }
            
        }

        public void SelectSkin(object sender)
        {
            ComboBox cmb = (ComboBox)sender;

            renderInit.RestartGui(cmb.SelectedItem.ToString());
        }


    }
}
