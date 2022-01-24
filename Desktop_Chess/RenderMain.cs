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
        
        
        Form_Game mainBoard = null;
        public RenderMain(Form_Game ob) { this.mainBoard = ob; }

        //public static RenderInit InitRender;

        public static Board model_Board = new Board(8);
        public static Figures model_Figures = new Figures();

        public Button[,] boardGrid = new Button[model_Board.Size, model_Board.Size];
        public List<Button> whiteFigures = new List<Button>(16);
        public List<Button> blackFigures = new List<Button>(16);

        public string comboBoxFigure = "";
        public string comboBoxSkin = "";
        
        public Dictionary<string, Image[]> cellImages = new Dictionary<string, Image[]>();
        public Dictionary<string, Image[]> backgroundImages = new Dictionary<string, Image[]>();
        
        public Dictionary<string, Image[]> figureImagesWhite = new Dictionary<string, Image[]>();
        public Dictionary<string, Image[]> figureImagesBlack = new Dictionary<string, Image[]>();
        
        private bool CellProps = false;
        
        // game board containers layout width/height in percent of Form_Game
        private static object[,] Layout = new object[3, 3] { 
            { "Top",100, 9},
            { "Left",70, 91 },
            { "Right",30, 91}
        };

        private Size ContainerSize(int width, int height , Form container) {
            return new Size (
                (int)Math.Round((Double)(Convert.ToInt32(width * container.Width) / 100)),
                (int)Math.Round((Double)(Convert.ToInt32(height * container.Height) / 100))
                );
        }


        public RenderMain()
        {
            //InitRender = new RenderInit(this.mainBoard);
            //InitRender.GUIdebug();
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
            mainBoard.Size = screen.WorkingArea.Size;
            mainBoard.Location = new Point(screen.WorkingArea.X, screen.WorkingArea.Y);
            for (int i = 0; i < Layout.GetLength(0); i++)
            {
                mainBoard.Controls[$"panel_Container_{(string)Layout[i, 0]}"].Size = ContainerSize((int)Layout[i, 1], (int)Layout[i, 2], mainBoard);
            }
            mainBoard.BackgroundImage = backgroundImages[skin][0];
            mainBoard.BackgroundImageLayout = ImageLayout.Tile;
            mainBoard.panel_Container_Top.Location = new Point(0, 0);
            mainBoard.panel_Container_Left.Location = new Point(0, mainBoard.panel_Container_Top.Height);
            mainBoard.panel_Container_Right.Location = new Point(mainBoard.panel_Container_Left.Width, mainBoard.panel_Container_Left.Location.Y);
            mainBoard.panel_ChessBoard.Padding = new Padding(0, 0, 0, 0);
            mainBoard.panel_ChessBoard.Margin = new Padding(0, 0, 0, 0);
            if (mainBoard.panel_Container_Left.Width < mainBoard.panel_Container_Left.Height)
            {
                mainBoard.panel_ChessBoard.Width = mainBoard.panel_Container_Left.Width;
            }
            else
            {
                mainBoard.panel_ChessBoard.Width = mainBoard.panel_Container_Left.Height;
            }
            mainBoard.panel_ChessBoard.Height = mainBoard.panel_ChessBoard.Width;

            mainBoard.panel_ChessBoard.Location = new Point((mainBoard.panel_Container_Left.Width - mainBoard.panel_ChessBoard.Width) / 2, (mainBoard.panel_Container_Left.Height - mainBoard.panel_ChessBoard.Height) / 2);
            mainBoard.panel_Container_Top.BackColor = Color.FromArgb(96, 0, 0, 0);
            mainBoard.panel_Container_Right.BackColor = Color.FromArgb(96, 0, 0, 0);

            mainBoard.listBox_Debug.Width = mainBoard.panel_Container_Left.Width;
            mainBoard.listBox_Debug.Height = mainBoard.panel_Container_Left.Height / 2;
            mainBoard.listBox_Debug.Location = new Point(0, mainBoard.panel_Container_Left.Height / 2);

            mainBoard.button_Rescan.BringToFront();
            mainBoard.label_Rescan.BringToFront();
            populaBoardteGrid(skin);
            
        }

        private void initSkin(string skin)
        {
            string[] type = new string[] { $"{skin}_cell_white", $"{skin}_cell_black" };
            Image[] tmpArray = new Image[type.Length];
            for (int i = 0; i < type.Length; i++) {
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

        private Image[] genFiguresImages(string skin, string side,string[] mod, string[] type) 
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

        private object[] swapCellProps(string skin)
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
            int buttonSize = mainBoard.panel_ChessBoard.Width / model_Board.Size;
            mainBoard.panel_ChessBoard.Height = mainBoard.panel_ChessBoard.Width;

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
                    boardGrid[i, j].Margin = new Padding(0,0,0,0);
                    boardGrid[i, j].Padding = new Padding(0, 0, 0, 0);
                    boardGrid[i, j].FlatStyle = FlatStyle.Standard;
                    boardGrid[i, j].FlatAppearance.BorderSize = 0;
                    boardGrid[i, j].FlatAppearance.BorderColor = Color.Yellow;
                    boardGrid[i, j].FlatStyle = FlatStyle.Flat;
                    boardGrid[i, j].Click += mainBoard.Grid_Button_Click;
                    boardGrid[i, j].Location = new Point(i * buttonSize, j * buttonSize);
                    //boardGrid[i, j].Text = i + " : " + j;
                    boardGrid[i, j].Text = "";
                    boardGrid[i, j].Font = new Font("Impact", 22);
                    boardGrid[i, j].Tag = new Point(i, j);
                    mainBoard.panel_ChessBoard.Controls.Add(boardGrid[i, j]);
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

                setFigureStyle(skin, GUIButtonWhite, modelFigureWhite, GUICellWhite, modelCellWhite, buttonSize,i);
                setFigureStyle(skin, GUIButtonBlack, modelFigureBlack, GUICellBlack, modelCellWhite, buttonSize,i);
            }
        
            }
        
        private void loadFiguresSkin(string skin, Button GUIButton, Figure modelFigure, Button GUICell, Cell modelCell) {
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
            //whiteFigures[i].Click += mainBoard.Grid_Button_Click;
            

            
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
            GUIButton.Click += mainBoard.Grid_Button_Click;
            mainBoard.panel_ChessBoard.Controls.Add(GUIButton);
            GUIButton.BringToFront();
        }

        private void PickFigure(object sender)
        {

        }

        internal void PlaceFigure(object sender)
        {
            Button clickedButton = (Button)sender;
            Point location;
            string figureType;
            Figure clickedFigure;
            if (clickedButton.Tag.GetType() == typeof(Figure))
            {
                clickedFigure = (Figure)clickedButton.Tag;
                location = new Point( clickedFigure.X, clickedFigure.Y );
                figureType = clickedFigure.Type;
            }
            else
            {
                //location = (Point)clickedButton.Tag;
                return;
            }
 
            Cell currenCell = model_Board.theGrid[location.X, location.Y];

            model_Board.MarkNextLegalMove(currenCell, figureType);
            for (int x = 0; x < model_Board.Size; x++)
            {
                for (int y = 0; y < model_Board.Size; y++)
                {
                    boardGrid[x, y].Text = "";
                    if (model_Board.theGrid[x, y].LegalNextMove)
                    {
                        boardGrid[x, y].Text = "Legal";
                        if (model_Board.theGrid[x, y].CurrentlyOccupied)
                        {
                            clickedButton.Text = "AAAAA";
                            if (boardGrid[x, y].Tag.GetType() == typeof(Figure))
                            {
                                Figure figure = (Figure)boardGrid[x, y].Tag;
                                
                            }
                            
                        }
                    }
                }
            }
        }

        


        internal void SelectSkin(object sender)
        {
            ComboBox cmb = (ComboBox)sender;
            RestartGui(cmb.SelectedItem.ToString());
        }
        public void RestartGui(string skin)
        {
            CellProps = false;
            mainBoard.BackgroundImage = backgroundImages[skin][0];
            
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
