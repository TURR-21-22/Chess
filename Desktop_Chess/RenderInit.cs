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

        public static Button[,] boardGrid = new Button[model_Board.Size, model_Board.Size];
        public static List<Button> whiteFigures = new List<Button>(16);
        public static List<Button> blackFigures = new List<Button>(16);

        public string comboBoxFigure = "";
        public string comboBoxSkin = "";

        public static Dictionary<string, Image[]> cellImages = new Dictionary<string, Image[]>();
        public static Dictionary<string, Image[]> backgroundImages = new Dictionary<string, Image[]>();
        
        public static Panel divTop;
        public static Panel divLeft;
        public static Panel divRight;
        public static Panel divChess;
        
        public Dictionary<string, Image[]> figureImagesWhite = new Dictionary<string, Image[]>();
        public Dictionary<string, Image[]> figureImagesBlack = new Dictionary<string, Image[]>();

        public bool CellProps = false;

        // game board containers layout width/height in percent of Form_Game
        private static object[,] Layout = new object[3, 3] {
            { "Top",100, 9},
            { "Left",70, 91 },
            { "Right",30, 91}
        };

        public RenderInit(Form_Game ob)
        {
            this.form_game = ob;

            divChess = form_game.panel_ChessBoard;
            divTop = form_game.panel_Container_Top;
            divLeft = form_game.panel_Container_Left;
            divRight = form_game.panel_Container_Right;

            //Render = new RenderMain(form_game);

            Init("wood");
        }

        public void Init(string skin)
        {
            // Setup layout
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
            form_game.BackgroundImage = backgroundImages[skin][0];
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
            
            form_game.button_Rescan.BringToFront();
            form_game.label_Rescan.BringToFront();
            populaBoardteGrid(skin);
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
            if (!cellImages.TryGetValue(skin, out value))
            {
                cellImages.Add(skin, tmpArray);
            }

            value = new Image[1];
            if (!backgroundImages.TryGetValue(skin, out value))
            {
                backgroundImages.Add(skin, new Image[]{
                (Image)Properties.Resources.ResourceManager.GetObject( $"{skin}_bkg" )
                });
            }

            string[] mod = new string[2] { "light", "dark" };
            type = new string[6] { "kiraly", "kiralyno", "huszar", "futo", "bastya", "gyalog" };
            value = new Image[1];
            if (!figureImagesWhite.TryGetValue(skin, out value))
            {
                figureImagesWhite.Add(skin, genFiguresImages(skin, "white", mod, type));
            }

            value = new Image[1];
            if (!figureImagesBlack.TryGetValue(skin, out value))
            {
                figureImagesBlack.Add(skin, genFiguresImages(skin, "black", mod, type));
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

        public object[] swapCellProps(string skin)
        {
            object[] props = new object[3];
            if (CellProps == true)
            {
                props = new object[3] { (Image)cellImages[skin][0], Color.Black, Color.White };
            }
            else
            {
                props = new object[3] { (Image)cellImages[skin][1], Color.White, Color.Black };
            }
            CellProps = !CellProps;
            return props;
        }

        public void populaBoardteGrid(string skin)
        {
            //Panel divChess = form_game.panel_ChessBoard;
            int buttonSize = divChess.Width / model_Board.Size;
            divChess.Height = divChess.Width;

            for (int i = 0; i < model_Board.Size; i++)
            {
                object[] props = swapCellProps(skin);
                for (int j = 0; j < model_Board.Size; j++)
                {
                    props = swapCellProps(skin);
                    boardGrid[i, j] = new Button();
                    //Button gridCell = boardGrid[i, j];
                    boardGrid[i, j].Height = buttonSize;
                    boardGrid[i, j].Width = buttonSize;
                    boardGrid[i, j].BackgroundImage = (Image)props[0];
                    boardGrid[i, j].ForeColor = (Color)props[1];
                    boardGrid[i, j].BackColor = (Color)props[2];
                    boardGrid[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    boardGrid[i, j].TextImageRelation = TextImageRelation.TextAboveImage;
                    boardGrid[i, j].Margin = new Padding(0, 0, 0, 0);
                    boardGrid[i, j].Padding = new Padding(0, 0, 0, 0);
                    boardGrid[i, j].FlatStyle = FlatStyle.Standard;
                    boardGrid[i, j].FlatAppearance.BorderSize = 0;
                    boardGrid[i, j].FlatAppearance.BorderColor = Color.Yellow;
                    boardGrid[i, j].FlatStyle = FlatStyle.Flat;
                    boardGrid[i, j].Click += form_game.Grid_Button_Click;
                    boardGrid[i, j].Location = new Point(i * buttonSize, j * buttonSize);
                    //boardGrid[i, j].Text = i + " : " + j;
                    boardGrid[i, j].Text = "";
                    boardGrid[i, j].Font = new Font("Impact", 22);
                    boardGrid[i, j].Tag = new Point(i, j);
                    divChess.Controls.Add(boardGrid[i, j]);
                }
            }


            for (int i = 0; i < model_Figures.BlackFiguresON.Count; i++)
            {
                whiteFigures.Add(new Button());
                Button GUIButtonWhite = whiteFigures[i];
                Figure modelFigureWhite = model_Figures.WhiteFiguresON[i];
                Button GUICellWhite = boardGrid[modelFigureWhite.X, modelFigureWhite.Y];
                Cell modelCellWhite = model_Board.theGrid[modelFigureWhite.X, modelFigureWhite.Y];

                blackFigures.Add(new Button());
                Button GUIButtonBlack = blackFigures[i];
                Figure modelFigureBlack = model_Figures.BlackFiguresON[i];
                Button GUICellBlack = boardGrid[modelFigureBlack.X, modelFigureBlack.Y];
                Cell modelCellBlack = model_Board.theGrid[modelFigureBlack.X, modelFigureBlack.Y];

                setFigureStyle(skin, GUIButtonWhite, modelFigureWhite, GUICellWhite, modelCellWhite, buttonSize, i);
                setFigureStyle(skin, GUIButtonBlack, modelFigureBlack, GUICellBlack, modelCellWhite, buttonSize, i);
            }

        }

        public void loadFiguresSkin(string skin, Button GUIButton, Figure modelFigure, Button GUICell, Cell modelCell)
        {
            if (GUICell.BackColor == Color.Black)
            {
                GUIButton.ForeColor = Color.White;
                GUIButton.BackColor = Color.Black;
                GUIButton.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject($"{skin}_figure_" +
                    $"{modelFigure.Side}_" +
                    $"{"dark"}_" +
                    $"{modelFigure.Type}");
            }
            else
            {
                GUIButton.ForeColor = Color.Black;
                GUIButton.BackColor = Color.White;
                GUIButton.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject($"{skin}_figure_" +
                        $"{modelFigure.Side}_" +
                        $"{"light"}_" +
                        $"{modelFigure.Type}");
            }
        }

        private void setFigureStyle(string skin, Button GUIButton, Figure modelFigure, Button GUICell, Cell modelCell, int size, int cnt)
        {
            GUIButton.Height = size;
            GUIButton.Width = size;
            loadFiguresSkin(skin, GUIButton, modelFigure, GUICell, modelCell);
            GUIButton.TextImageRelation = TextImageRelation.TextAboveImage;
            GUIButton.Font = new Font("Impact", 16);
            GUIButton.FlatStyle = FlatStyle.Flat;
            GUIButton.BackgroundImageLayout = ImageLayout.Stretch;
            GUIButton.Margin = new Padding(0, 0, 0, 0);
            GUIButton.Padding = new Padding(0, 0, 0, 0);
            GUIButton.FlatStyle = FlatStyle.Flat;
            GUIButton.FlatAppearance.BorderSize = 0;
            GUIButton.FlatAppearance.BorderColor = Color.Yellow;
            GUIButton.Location = new Point(modelFigure.X * size, modelFigure.Y * size);
            GUIButton.Text = $""; //{myFigure}\n{myButton}\n
            //myButton.Text = $"{cnt}\n{myFigure.ID}\n{myFigure.X}×{myFigure.Y}";
            GUIButton.TextAlign = ContentAlignment.TopLeft;
            GUIButton.Tag = modelFigure;
            GUIButton.Click += form_game.Grid_Button_Click;
            divChess.Controls.Add(GUIButton);
            GUIButton.BringToFront();
        }

        public void RestartGui(string skin)
        {
            CellProps = false;
            form_game.BackgroundImage = backgroundImages[skin][0];

            for (int y = 0; y < model_Board.Size; y++)
            {
                object[] props = swapCellProps(skin);

                for (int x = 0; x < model_Board.Size; x++)
                {
                    props = swapCellProps(skin);
                    boardGrid[y, x].BackgroundImage = (Image)props[0];
                    boardGrid[y, x].ForeColor = (Color)props[1];
                    boardGrid[y, x].BackColor = (Color)props[2];
                }
            }

            for (int i = 0; i < whiteFigures.Count; i++)
            {
                Button GUIButtonWhite = whiteFigures[i];
                Button GUIButtonBlack = blackFigures[i];

                Figure modelFigureWhite = model_Figures.WhiteFiguresON[i];
                Figure modelFigureBlack = model_Figures.BlackFiguresON[i];

                Button GUICellWhite = boardGrid[modelFigureWhite.X, modelFigureWhite.Y];
                Button GUICellBlack = boardGrid[modelFigureBlack.X, modelFigureBlack.Y];

                Cell modelCellWhite = model_Board.theGrid[modelFigureWhite.X, modelFigureWhite.Y];
                Cell modelCellBlack = model_Board.theGrid[modelFigureBlack.X, modelFigureBlack.Y];

                loadFiguresSkin(skin, GUIButtonWhite, modelFigureWhite, GUICellWhite, modelCellWhite);
                loadFiguresSkin(skin, GUIButtonBlack, modelFigureBlack, GUICellBlack, modelCellBlack);

            }
        }
    }
}
