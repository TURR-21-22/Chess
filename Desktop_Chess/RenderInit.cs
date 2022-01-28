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
    public class RenderInit
    {

        Main mainForm = null;

        public static Board model_Board = new Board(8);
        public static Figures model_Figures = new Figures();
        
        public static Gui_Cell[,] guiGrid = new Gui_Cell[model_Board.Size, model_Board.Size];
        public static List<Gui_Figure> gui_whiteFigures = new List<Gui_Figure>(16);
        public static List<Gui_Figure> gui_blackFigures = new List<Gui_Figure>(16);

        
        public static Dictionary<string, Image[]> gui_cellImages = new Dictionary<string, Image[]>();
        public static Dictionary<string, Image[]> gui_backgroundImages = new Dictionary<string, Image[]>();
        
        public static Panel divTop;
        public static Panel divLeft;
        public static Panel divRight;
        public static Panel divChess;
        public string Skin;
        public static int cellSize;

        //public Dictionary<string, Image[]> gui_figureImagesWhite = new Dictionary<string, Image[]>();
        //public Dictionary<string, Image[]> gui_figureImagesBlack = new Dictionary<string, Image[]>();

        public bool CellProps = false;

        // game board containers layout width/height in percent of Form_Game
        private static object[,] Layout = new object[3, 3] {
            { "Top",100, 6},
            { "Left",60, 94 },
            { "Right",40, 94}
        };
                
        
        public RenderInit(Main ob)
        {
            this.mainForm = ob;
            divChess = mainForm.panel_ChessBoard;
            divTop = mainForm.panel_Container_Top;
            divLeft = mainForm.panel_Container_Left;
            divRight = mainForm.panel_Container_Right;
            Init("wood");
        }
      

        public void Init(string skin)
        {
            Skin = skin;
            string[] skins = new string[] { "solid", "wood" };
            foreach (var item in skins)
            {
                initSkin(item);
            }
            Screen screen = Screen.FromPoint(Cursor.Position);
            mainForm.Size = screen.WorkingArea.Size;
            mainForm.Location = new Point(screen.WorkingArea.X, screen.WorkingArea.Y);
            for (int i = 0; i < Layout.GetLength(0); i++)
            {
                mainForm.Controls[$"panel_Container_{(string)Layout[i, 0]}"].Size = ContainerSize((int)Layout[i, 1], (int)Layout[i, 2], mainForm);
            }
            mainForm.BackgroundImage = gui_backgroundImages[Skin][0];
            mainForm.BackgroundImageLayout = ImageLayout.Tile;

            divTop.Location = new Point(0, 0);
            divLeft.Location = new Point(0, divTop.Height);
            divRight.Location = new Point(divLeft.Width, divLeft.Location.Y);
            divChess.Padding = new Padding(0, 0, 0, 0);
            divChess.Margin = new Padding(0, 0, 0, 0);
            if (divLeft.Width < divLeft.Height)
            {
                divChess.Width = divLeft.Width;
            }
            else
            {
                divChess.Width = divLeft.Height;
            }
            divChess.Height = divChess.Width;

            divChess.Location = new Point((divLeft.Width - divChess.Width) / 2, (divLeft.Height - divChess.Height) / 2);
            divTop.BackColor = Color.FromArgb(96, 0, 0, 0);
            divRight.BackColor = Color.FromArgb(96, 0, 0, 0);

            headerControlls(divTop);
            populaBoardteGrid(skin);
        }

        private void headerControlls(Panel divTop)
        {
            ComboBox skinsCombo = mainForm.comboBox_Skin_List;
            Label skinsLabel = mainForm.label_Skins;
            skinsCombo.Location = new Point(32, (divTop.Height / 2) - (skinsCombo.Height / 2));
            skinsLabel.Location = new Point( skinsCombo.Location.X + skinsCombo.Width +6, (divTop.Height / 2) - (skinsCombo.Height / 2));
            skinsLabel.BackColor = Color.White;
        }

        private Size ContainerSize(int width, int height, Form container)
        {
            return new Size(
                (int)Math.Round((Double)(Convert.ToInt32(width * container.Width) / 100)),
                (int)Math.Round((Double)(Convert.ToInt32(height * container.Height) / 100))
                );
        }
        private void initSkin(string skin)
        {
            string[] type = new string[] { $"{skin}_cell_white", $"{skin}_cell_black" };
            Image[] tmpArray = new Image[type.Length];
            for (int i = 0; i < type.Length; i++)
            {
                tmpArray[i] = (Image)Properties.Resources.ResourceManager.GetObject($"{type[i]}");
            }
            Image[] value = new Image[1];
            if (!gui_cellImages.TryGetValue(skin, out value))
            {
                gui_cellImages.Add(skin, tmpArray);
            }

            value = new Image[1];
            if (!gui_backgroundImages.TryGetValue(skin, out value))
            {
                gui_backgroundImages.Add(skin, new Image[]{
                (Image)Properties.Resources.ResourceManager.GetObject( $"{skin}_bkg" )
                });
            }
        }

        private Image[] genFiguresImages(string skin, string side, string[] mod, string[] type)
        {
            Image[] tmp = new Image[24];
            //string[] tmp = new string[12];
            int cnt = 0;
            for (int m = 0; m < mod.Length; m++)
            {
                for (int t = 0; t < type.Length; t++)
                {
                    tmp[cnt] = (Image)Properties.Resources.ResourceManager.GetObject($"{skin}_figure_{side}_{mod[m]}_{type[t]}");
                    //tmp[cnt] = $"{skin}_figure_{side}_{mod[m]}_{type[t]}";
                    cnt++;
                }
            }
            return tmp;
        }

        public void populaBoardteGrid(string skin)
        {
            cellSize = divChess.Width / model_Board.Size;
            divChess.Height = divChess.Width;
            for (int x = 0; x < model_Board.Size; x++)
            {
                for (int y = 0; y < model_Board.Size; y++)
                {

                    Gui_Cell gui_Cell = new Gui_Cell(x, y);
                    guiGrid[x, y] = gui_Cell;
                    gui_Cell.LegalNextMove = model_Board.theGrid[x, y].LegalNextMove;
                    gui_Cell.Width = cellSize;
                    gui_Cell.Height = cellSize;
                    gui_Cell.ForeColor = Color.White;
                    gui_Cell.BackColor = Color.Black;
                    switch (model_Board.theGrid[x, y].CellBkgColor)
                    {
                        case "light":
                            gui_Cell.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject($"" +
                                $"{skin}_cell_white");
                            break;
                        case "dark":
                            gui_Cell.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject($"" +
                                $"{skin}_cell_black");
                            break;
                    }
                    gui_Cell.Click += mainForm.Board_Click;
                    gui_Cell.Location = new Point(x * cellSize, y * cellSize);
                    divChess.Controls.Add(gui_Cell);
                }
            }
            for (int i = 0; i < model_Figures.Model_blackFiguresON.Count; i++)
            {
                gui_whiteFigures.Add(new Gui_Figure());

                Figure model_FigureWhite = model_Figures.Model_whiteFiguresON[i];
                
                Cell model_CellWhite = model_Board.theGrid[model_FigureWhite.X, model_FigureWhite.Y];
                Gui_Figure gui_FigureWhite = gui_whiteFigures[i];
                Gui_Cell gui_CellWhite = guiGrid[model_FigureWhite.X, model_FigureWhite.Y];

                gui_blackFigures.Add(new Gui_Figure());
                Figure model_FigureBlack = model_Figures.Model_blackFiguresON[i];
                Cell model_CellBlack = model_Board.theGrid[model_FigureBlack.X, model_FigureBlack.Y];
                Gui_Figure gui_FigureBlack = gui_blackFigures[i];
                Gui_Cell gui_CellBlack = guiGrid[model_FigureBlack.X, model_FigureBlack.Y];

                setFigure(skin, gui_FigureWhite, model_FigureWhite, gui_CellWhite, model_CellWhite, cellSize, i);
                setFigure(skin, gui_FigureBlack, model_FigureBlack, gui_CellBlack, model_CellBlack, cellSize, i);
            }
        }

        private void setFigure(string skin, Gui_Figure gui_Figure, Figure modelFigure, Gui_Cell gui_Cell, Cell modelCell, int size, int cnt)
        {
            gui_Cell.Figure = gui_Figure;
            gui_Figure.X = modelCell.X;
            gui_Figure.Y = modelCell.Y;
            gui_Figure.Side = modelFigure.Side;
            gui_Figure.Type = modelFigure.Type;
            gui_Figure.LegalNextMove = modelFigure.LegalNextMove;
            gui_Figure.Kick = modelFigure.Kick;
            gui_Figure.Height = size;
            gui_Figure.Width = size;
            loadFiguresSkin(skin, gui_Figure, modelFigure, modelCell);
            gui_Figure.Font = new Font("Impact", 16);
            gui_Figure.BackgroundImageLayout = ImageLayout.Stretch;
            gui_Figure.Margin = new Padding(0, 0, 0, 0);
            gui_Figure.Padding = new Padding(0, 0, 0, 0);
            gui_Figure.Location = new Point(modelFigure.X * size, modelFigure.Y * size);
            gui_Figure.Click += mainForm.Board_Click;
            divChess.Controls.Add(gui_Figure);
            gui_Figure.BringToFront();
        }

        public void RestartGui(string skin)
        {
            Skin = skin;
            mainForm.BackgroundImage = gui_backgroundImages[skin][0];
            for (int y = 0; y < model_Board.Size; y++)
            {
                for (int x = 0; x < model_Board.Size; x++)
                {
                    //guiGrid[y, x].ForeColor = Color.White;
                    //guiGrid[y, x].BackColor = Color.Black;
                    switch (model_Board.theGrid[x, y].CellBkgColor)
                    {
                        case "light":
                            guiGrid[y, x].BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(
                                $"{skin}_cell_white");
                                
                            break;
                        case "dark":
                            guiGrid[y, x].BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(
                                $"{skin}_cell_black");
                            break;
                    }
                }
            }

            for (int i = 0; i < gui_whiteFigures.Count; i++)
            {
                Gui_Figure guiFigureWhite = gui_whiteFigures[i];
                Gui_Figure guiFigureBlack = gui_blackFigures[i];
                
                Figure modelFigureWhite = model_Figures.Model_whiteFiguresON[i];
                Figure modelFigureBlack = model_Figures.Model_blackFiguresON[i];

                Cell modelCellWhite = model_Board.theGrid[modelFigureWhite.X, modelFigureWhite.Y];
                Cell modelCellBlack = model_Board.theGrid[modelFigureBlack.X, modelFigureBlack.Y];

                loadFiguresSkin(skin, guiFigureWhite, modelFigureWhite, modelCellWhite);
                loadFiguresSkin(skin, guiFigureBlack, modelFigureBlack, modelCellBlack);

            }
        }
        public void loadFiguresSkin(string skin, Gui_Figure guiFigure, Figure modelFigure, Cell modelCell)
        {
            guiFigure.ForeColor = Color.White;
            guiFigure.BackColor = Color.Black;
            switch (modelCell.CellBkgColor)
            {
                case "light":
                    guiFigure.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject($"{skin}_figure_" +
                        $"{modelFigure.Side}_" +
                        $"{"light"}_" +
                        $"{modelFigure.Type}");

                    break;
                case "dark":
                    guiFigure.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject($"{skin}_figure_" +
                        $"{modelFigure.Side}_" +
                        $"{"dark"}_" +
                        $"{modelFigure.Type}");
                    break;
            }
        }

        


    }
}
