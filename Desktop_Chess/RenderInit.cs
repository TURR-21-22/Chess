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

        Form_Game form_game = null;

        public static Board model_Board = new Board(8);
        public static Figures model_Figures = new Figures();
        
        public static Gui_Cell[,] gui_Grid = new Gui_Cell[model_Board.Size, model_Board.Size];
        public static List<Button> gui_whiteFigures = new List<Button>(16);
        public static List<Button> gui_blackFigures = new List<Button>(16);

        public static Dictionary<string, Image[]> gui_cellImages = new Dictionary<string, Image[]>();
        public static Dictionary<string, Image[]> gui_backgroundImages = new Dictionary<string, Image[]>();
        
        public static Panel divTop;
        public static Panel divLeft;
        public static Panel divRight;
        public static Panel divChess;
        
        //public Dictionary<string, Image[]> gui_figureImagesWhite = new Dictionary<string, Image[]>();
        //public Dictionary<string, Image[]> gui_figureImagesBlack = new Dictionary<string, Image[]>();

        public bool CellProps = false;

        // game board containers layout width/height in percent of Form_Game
        private static object[,] Layout = new object[3, 3] {
            { "Top",100, 6},
            { "Left",60, 94 },
            { "Right",40, 94}
        };

        public RenderInit(Form_Game ob)
        {
            this.form_game = ob;
            divChess = form_game.panel_ChessBoard;
            divTop = form_game.panel_Container_Top;
            divLeft = form_game.panel_Container_Left;
            divRight = form_game.panel_Container_Right;
            Init("wood");
        }

        public void Init(string skin)
        {
            string[] skins = new string[] { "solid", "wood" };
            foreach (var item in skins)
            {
                initSkin(item);
            }
            Screen screen = Screen.FromPoint(Cursor.Position);
            form_game.Size = screen.WorkingArea.Size;
            form_game.Location = new Point(screen.WorkingArea.X, screen.WorkingArea.Y);
            for (int i = 0; i < Layout.GetLength(0); i++)
            {
                form_game.Controls[$"panel_Container_{(string)Layout[i, 0]}"].Size = ContainerSize((int)Layout[i, 1], (int)Layout[i, 2], form_game);
            }
            form_game.BackgroundImage = gui_backgroundImages[skin][0];
            form_game.BackgroundImageLayout = ImageLayout.Tile;

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
            ComboBox debugCombo = form_game.comboBox_arrays;
            Label debugComboLabel = form_game.label_Rescan;
            HScrollBar debugScroll = form_game.hScrollBar_Debug;
            ComboBox skinsCombo = form_game.comboBox_Skin_List;
            Label skinsLabel = form_game.label_Skins;

            debugCombo.Location = new Point(divTop.Width - debugCombo.Width - 32, (divTop.Height / 2) - (debugCombo.Height / 2));
            debugComboLabel.Location = new Point(debugCombo.Location.X - debugComboLabel.Width - 6, debugCombo.Location.Y);
            debugScroll.Location = new Point(debugComboLabel.Location.X - debugScroll.Width - 6, debugCombo.Location.Y);
            debugScroll.Height = debugComboLabel.Height;
            debugComboLabel.BackColor = Color.White;

            skinsCombo.Location = new Point(32, (divTop.Height / 2) - (skinsCombo.Height / 2));
            skinsLabel.Location = new Point( skinsCombo.Location.X + skinsCombo.Width +6, (divTop.Height / 2) - (skinsCombo.Height / 2));
            skinsLabel.BackColor = Color.White;

            debugCombo.BringToFront();
            debugComboLabel.BringToFront();
            debugScroll.BringToFront();
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

            /*
            string[] mod = new string[2] { "light", "dark" };
            type = new string[6] { "kiraly", "kiralyno", "huszar", "futo", "bastya", "gyalog" };
            value = new Image[1];
            if (!gui_figureImagesWhite.TryGetValue(skin, out value))
            {
                gui_figureImagesWhite.Add(skin, genFiguresImages(skin, "white", mod, type));
            }

            value = new Image[1];
            if (!gui_figureImagesBlack.TryGetValue(skin, out value))
            {
                gui_figureImagesBlack.Add(skin, genFiguresImages(skin, "black", mod, type));
            }
            */
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
            int size = divChess.Width / model_Board.Size;
            divChess.Height = divChess.Width;
            for (int x = 0; x < model_Board.Size; x++)
            {
                for (int y = 0; y < model_Board.Size; y++)
                {
                    Gui_Cell gui_Cell = new Gui_Cell(x, y);
                    gui_Grid[x, y] = gui_Cell;
                    gui_Cell.Width = size;
                    gui_Cell.Height = size;
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
                    gui_Cell.Click += form_game.Board_Click;
                    gui_Cell.Location = new Point(x * size, y * size);
                    divChess.Controls.Add(gui_Cell);
                }
            }
            for (int i = 0; i < model_Figures.Model_blackFiguresON.Count; i++)
            {
                gui_whiteFigures.Add(new Button());
                Figure model_FigureWhite = model_Figures.Model_whiteFiguresON[i];
                Cell model_CellWhite = model_Board.theGrid[model_FigureWhite.X, model_FigureWhite.Y];
                Button gui_FigureWhite = gui_whiteFigures[i];
                Gui_Cell gui_CellWhite = gui_Grid[model_FigureWhite.X, model_FigureWhite.Y];

                gui_blackFigures.Add(new Button());
                Figure model_FigureBlack = model_Figures.Model_blackFiguresON[i];
                Cell model_CellBlack = model_Board.theGrid[model_FigureBlack.X, model_FigureBlack.Y];
                Button gui_FigureBlack = gui_blackFigures[i];
                Gui_Cell gui_CellBlack = gui_Grid[model_FigureBlack.X, model_FigureBlack.Y];

                setFigure(skin, gui_FigureWhite, model_FigureWhite, gui_CellWhite, model_CellWhite, size, i);
                setFigure(skin, gui_FigureBlack, model_FigureBlack, gui_CellBlack, model_CellBlack, size, i);
            }
        }

        private void setCell(int x, int y, Figure model_Cell, int size, Object[] props)
        {
            Gui_Cell gui_Cell = new Gui_Cell(x, y);
            gui_Grid[x, y] = gui_Cell;
            gui_Cell.Width = size;
            gui_Cell.Height = size;
            gui_Cell.BackgroundImage = (Image)props[0]; //(Image)props[0];
            gui_Cell.BackColor = (Color)Color.Black; //(Color)props[1];
            gui_Cell.Click += form_game.Board_Click;
            gui_Cell.Location = new Point(x * size, y * size);
            divChess.Controls.Add(gui_Cell);
        }

        private void setFigure(string skin, Button gui_Figure, Figure modelFigure, Gui_Cell gui_Cell, Cell modelCell, int size, int cnt)
        {
            gui_Cell.CellFigure = gui_Figure;
            gui_Figure.Height = size;
            gui_Figure.Width = size;
            loadFiguresSkin(skin, gui_Figure, modelFigure, gui_Cell, modelCell);
            gui_Figure.TextImageRelation = TextImageRelation.TextAboveImage;
            gui_Figure.Font = new Font("Impact", 16);
            gui_Figure.FlatStyle = FlatStyle.Flat;
            gui_Figure.BackgroundImageLayout = ImageLayout.Stretch;
            gui_Figure.Margin = new Padding(0, 0, 0, 0);
            gui_Figure.Padding = new Padding(0, 0, 0, 0);
            gui_Figure.FlatStyle = FlatStyle.Flat;
            gui_Figure.FlatAppearance.BorderSize = 0;
            gui_Figure.FlatAppearance.BorderColor = Color.Yellow;
            gui_Figure.Location = new Point(modelFigure.X * size, modelFigure.Y * size);
            gui_Figure.Text = $"";
            gui_Figure.TextAlign = ContentAlignment.TopLeft;
            gui_Figure.Tag = modelFigure;
            gui_Figure.Click += form_game.Board_Click;
            divChess.Controls.Add(gui_Figure);
            gui_Figure.BringToFront();
        }

        public void RestartGui(string skin)
        {
            form_game.BackgroundImage = gui_backgroundImages[skin][0];
            for (int y = 0; y < model_Board.Size; y++)
            {
                for (int x = 0; x < model_Board.Size; x++)
                {
                    gui_Grid[y, x].ForeColor = Color.White;
                    gui_Grid[y, x].BackColor = Color.Black;
                    switch (model_Board.theGrid[x, y].CellBkgColor)
                    {
                        case "light":
                            gui_Grid[y, x].BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject($"" +
                                $"{skin}_cell_white");
                                
                            break;
                        case "dark":
                            gui_Grid[y, x].BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject($"" +
                                $"{skin}_cell_black");
                                
                            break;
                    }
                }
            }

            for (int i = 0; i < gui_whiteFigures.Count; i++)
            {
                Button gui_FigureWhite = gui_whiteFigures[i];
                Button gui_FigureBlack = gui_blackFigures[i];

                Figure model_FigureWhite = model_Figures.Model_whiteFiguresON[i];
                Figure model_FigureBlack = model_Figures.Model_blackFiguresON[i];

                Gui_Cell gui_CellWhite = gui_Grid[model_FigureWhite.X, model_FigureWhite.Y];
                Gui_Cell gui_CellBlack = gui_Grid[model_FigureBlack.X, model_FigureBlack.Y];

                Cell model_CellWhite = model_Board.theGrid[model_FigureWhite.X, model_FigureWhite.Y];
                Cell model_CellBlack = model_Board.theGrid[model_FigureBlack.X, model_FigureBlack.Y];

                loadFiguresSkin(skin, gui_FigureWhite, model_FigureWhite, gui_CellWhite, model_CellWhite);
                loadFiguresSkin(skin, gui_FigureBlack, model_FigureBlack, gui_CellBlack, model_CellBlack);

            }
        }
        public void loadFiguresSkin(string skin, Button gui_Figure, Figure model_Figure, Gui_Cell gui_Cell, Cell model_Cell)
        {
            gui_Figure.ForeColor = Color.White;
            gui_Figure.BackColor = Color.Black;
            switch (model_Cell.CellBkgColor)
            {
                case "light":
                    gui_Figure.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject($"{skin}_figure_" +
                        $"{model_Figure.Side}_" +
                        $"{"light"}_" +
                        $"{model_Figure.Type}");

                    break;
                case "dark":
                    gui_Figure.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject($"{skin}_figure_" +
                        $"{model_Figure.Side}_" +
                        $"{"dark"}_" +
                        $"{model_Figure.Type}");

                    break;
            }
        }


    }
}
