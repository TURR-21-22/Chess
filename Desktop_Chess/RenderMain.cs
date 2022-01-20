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
       
    class RenderMain
    {
        Form_Game mainBoard = null;
        public RenderMain(Form_Game ob) { this.mainBoard = ob; }
        public static Board myBoard = new Board(8);
        public string comboBoxFigure = "";
        public Button[,] btnGrid = new Button[myBoard.Size, myBoard.Size];
        public List<Image[]> cellImages = new List<Image[]>();
        public List<Image[]> figureImagesWhite = new List<Image[]>();
        public List<Image[]> figureImagesBlack = new List<Image[]>();
        public List<Image[]> miscImages = new List<Image[]>();
        private bool swap = false;
        private Image bkgImage = null;
        private Color txtColor = Color.White;
        private Color bkgColor = Color.White;
        

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
        public void Init(int cellIndex,int miscIndex) 
        {

            // Setup layout
            setDefaultSkins();
            Screen screen = Screen.FromPoint(Cursor.Position);
            mainBoard.Size = screen.WorkingArea.Size;
            mainBoard.Location = new Point(screen.WorkingArea.X, screen.WorkingArea.Y);
            for (int i = 0; i < Layout.GetLength(0); i++)
            {
                mainBoard.Controls[$"panel_Container_{(string)Layout[i, 0]}"].Size = ContainerSize( (int)Layout[i, 1], (int)Layout[i, 2], mainBoard );
            }
            mainBoard.BackgroundImage = miscImages[miscIndex][0];
            mainBoard.BackgroundImageLayout = ImageLayout.Tile;
            mainBoard.panel_Container_Top.Location = new Point(0, 0);
            mainBoard.panel_Container_Left.Location = new Point(0, mainBoard.panel_Container_Top.Height);
            mainBoard.panel_Container_Right.Location = new Point(mainBoard.panel_Container_Left.Width, mainBoard.panel_Container_Left.Location.Y);
            mainBoard.panel_ChessBoard.Padding = new Padding(0, 0, 0, 0);
            mainBoard.panel_ChessBoard.Margin = new Padding(0, 0, 0, 0);
            if (mainBoard.panel_Container_Left.Width < mainBoard.panel_Container_Left.Height) {
                mainBoard.panel_ChessBoard.Width = mainBoard.panel_Container_Left.Width;
            } else {
                mainBoard.panel_ChessBoard.Width = mainBoard.panel_Container_Left.Height;
            }
            mainBoard.panel_ChessBoard.Height = mainBoard.panel_ChessBoard.Width;
            
            mainBoard.panel_ChessBoard.Location = new Point( (mainBoard.panel_Container_Left.Width - mainBoard.panel_ChessBoard.Width) / 2, (mainBoard.panel_Container_Left.Height - mainBoard.panel_ChessBoard.Height) / 2);
            mainBoard.panel_Container_Top.BackColor = Color.FromArgb(96, 0, 0, 0);
            mainBoard.panel_Container_Right.BackColor = Color.FromArgb(96, 0, 0, 0);
            populateGrid(cellIndex);
        }

        private void setDefaultSkins()
        {
            string[,] cellStr = new string[3,2] { 
                { "default_white", "default_black" },
                { "test_green", "test_red" },
                { "wood_white", "wood_black" }
            };
            string[] figureStr = new string[6] { "kiraly","vezer","huszar","futo","bastya","gyalog" };
            for (int i = 0; i < cellStr.GetLength(0); i++)
            {
                cellImages.Add(new Image[]{
                    (Image)Properties.Resources.ResourceManager.GetObject( $"cell_{cellStr[i,0]}" ),
                    (Image)Properties.Resources.ResourceManager.GetObject( $"cell_{cellStr[i,1]}" )
                });
            }
            for (int i = 0; i < figureStr.Length; i++)
            {
                figureImagesWhite.Add(new Image[]{
                    (Image)Properties.Resources.ResourceManager.GetObject( $"figures_default_white_{figureStr[i]}" )
                });
                figureImagesBlack.Add(new Image[]{
                    (Image)Properties.Resources.ResourceManager.GetObject( $"figures_default_black_{figureStr[i]}" )
                });
            }

            miscImages.Add(new Image[]{
                global::Desktop_Chess.Properties.Resources.misc_default_form
                });
        }

        private void swapCellProps(int imgListIndex)
        {
            if (swap == true)
            {
                bkgImage = cellImages[imgListIndex][0];
                bkgColor = Color.White;
                txtColor = Color.Black;
            }
            else
            {
                bkgImage = cellImages[imgListIndex][1];
                bkgColor = Color.Black;
                txtColor = Color.White;
            }
            swap = !swap;
        }

        public void populateGrid(int imgListIndex)
        {
            int buttonSize = mainBoard.panel_ChessBoard.Width / myBoard.Size;
            mainBoard.panel_ChessBoard.Height = mainBoard.panel_ChessBoard.Width;

            for (int i = 0; i < myBoard.Size; i++)
            {
                swapCellProps(imgListIndex);
                for (int j = 0; j < myBoard.Size; j++)
                {
                    swapCellProps(imgListIndex);
                    btnGrid[i, j] = new Button();
                    btnGrid[i, j].Height = buttonSize;
                    btnGrid[i, j].Width = buttonSize;
                    btnGrid[i, j].BackgroundImage = bkgImage;
                    btnGrid[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    btnGrid[i, j].ForeColor = txtColor;
                    btnGrid[i, j].BackColor = bkgColor;
                    btnGrid[i, j].TextImageRelation = TextImageRelation.TextAboveImage;
                    btnGrid[i, j].Margin = new Padding(0,0,0,0);
                    btnGrid[i, j].Padding = new Padding(0, 0, 0, 0);
                    btnGrid[i, j].FlatAppearance.BorderSize = 0;
                    btnGrid[i, j].FlatStyle = FlatStyle.Flat;
                    btnGrid[i, j].Click += mainBoard.Grid_Button_Click;
                    btnGrid[i, j].Location = new Point(i * buttonSize, j * buttonSize);
                    btnGrid[i, j].Text = i + " : " + j;
                    btnGrid[i, j].Tag = new Point(i, j);
                    mainBoard.panel_ChessBoard.Controls.Add(btnGrid[i, j]);
                    
                }
            }
        }

        internal void ComboSelectFigure(object sender)
        {
            ComboBox cmb = (ComboBox)sender;
            comboBoxFigure = cmb.SelectedItem.ToString();
            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    btnGrid[i, j].Text = "";
                }
            }
        }

        internal void PlaceFigure(object sender)
        {
            Button clickedButton = (Button)sender;
            Point location = (Point)clickedButton.Tag;
            Cell currenCell = myBoard.theGrid[location.X, location.Y];
            if (comboBoxFigure == "")
            {
                comboBoxFigure = "queen";
            }

            myBoard.MarkNextLegalMove(currenCell, comboBoxFigure);
            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    btnGrid[i, j].Text = "";
                    if (myBoard.theGrid[i, j].LegalNextMove == true)
                    {
                        btnGrid[i, j].Text = "Legal";
                    }
                    if (myBoard.theGrid[i, j].CurrentlyOccupied == true)
                    {
                        btnGrid[i, j].Text = comboBoxFigure;
                    }
                }
            }
        }
    }
}
