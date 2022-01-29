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
        public static Panel divTop, divLeft, divRight, divChess, kickedWhitesContainer, kickedBlacksContainer, kickedWhites, kickedBlacks;
        public string Skin;
        public static int cellSize;
        public static int kickedCellSize;
        public static Point[] kickedPanelCoords;
        public bool CellProps = true;

        //public Dictionary<string, Image[]> gui_figureImagesWhite = new Dictionary<string, Image[]>();
        //public Dictionary<string, Image[]> gui_figureImagesBlack = new Dictionary<string, Image[]>();

        

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
            kickedWhitesContainer = mainForm.panel_kicked_container_white;
            kickedBlacksContainer = mainForm.panel_kicked_container_black;
            kickedWhites = mainForm.panel_kicked_white;
            kickedBlacks = mainForm.panel_kicked_black;
            
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

            headerControlls();
            kickedPanels();
            populaBoardGuiGrid(skin);
            
        }

        private void headerControlls()
        {
            ComboBox skinsCombo = mainForm.comboBox_Skin_List;
            Label skinsLabel = mainForm.label_Skins;
            skinsCombo.Location = new Point(32, (divTop.Height / 2) - (skinsCombo.Height / 2));
            skinsLabel.Location = new Point( skinsCombo.Location.X + skinsCombo.Width +6, (divTop.Height / 2) - (skinsCombo.Height / 2));
            skinsLabel.BackColor = Color.White;
        }

        private void kickedPanels()
        {
            kickedWhitesContainer.Size = new Size(divRight.Width - 40, (divRight.Width/8)*2);
            kickedBlacksContainer.Size = kickedWhitesContainer.Size;
            kickedWhitesContainer.Location = new Point(12, 12);
            kickedBlacksContainer.Location = new Point(12, kickedWhitesContainer.Location.Y + kickedWhitesContainer.Height + 6);
            kickedWhites.Size = new Size(kickedWhitesContainer.Width -40, ((kickedWhitesContainer.Width - 38) / 8) * 2);
            kickedWhites.Padding = new Padding(0, 0, 0, 0);
            kickedWhites.Location = new Point((kickedWhitesContainer.Width - kickedWhites.Width) / 2, 8);
            kickedBlacks.Size = kickedWhites.Size;
            kickedBlacks.Padding = new Padding(0, 0, 0, 0);
            kickedBlacks.Location = new Point((kickedBlacksContainer.Width - kickedBlacks.Width) / 2, 8);
            mainForm.listBox1.Location = new Point(12, kickedBlacksContainer.Location.Y + kickedBlacksContainer.Height + 6);
            mainForm.listBox1.Width = divRight.Width - 24;
            mainForm.listBox1.Height = mainForm.label_DebugSwitch.Location.Y - 6;

            kickedPanelCoords = new Point[16];
            kickedCellSize = (kickedWhitesContainer.Width - 38) / 8;
            Point baseLocation;
            int counter = 0;
            for (int y = 0; y < 2; y++)
            {
                baseLocation = new Point(0, 0 + (kickedCellSize * y));
                for (int x = 0; x < 8; x++)
                {
                    kickedPanelCoords[counter] = new Point(kickedCellSize * x, baseLocation.Y);
                    counter++;
                }
            }
            makeKickedCells(kickedWhites);
            makeKickedCells(kickedBlacks);
        }

        private void makeKickedCells(Panel panel)
        {
            int counter = 0;
            Point baseLocation;
            for (int y = 0; y < 2; y++)
            {
                baseLocation = new Point(0, 0 + (kickedCellSize * y));
                CellProps = !CellProps;
                for (int x = 0; x < 8; x++)
                {
                    CellProps = !CellProps;
                    Label kickedCell = new Label();
                    kickedCell.Width = kickedCellSize;
                    kickedCell.Height = kickedCellSize;
                    if (CellProps)
                    {
                        kickedCell.ForeColor = Color.White;
                        kickedCell.BackColor = Color.Black;
                    }
                    else
                    {
                        kickedCell.ForeColor = Color.Black;
                        kickedCell.BackColor = Color.White;
                    }
                    kickedCell.BorderStyle = BorderStyle.None;
                    //kickedCell.Type = false;
                    //kickedCell.Pupet = null;
                    //kickedCell.Click += mainForm.Board_Click;
                    kickedCell.Location = kickedPanelCoords[counter];
                    panel.Controls.Add(kickedCell);
                    counter++;
                }
            }
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

        public void populaBoardGuiGrid(string skin)
        {
            cellSize = divChess.Width / model_Board.Size;
            divChess.Height = divChess.Width;
            int x = 0;
            int y = 0;
            for ( x = 0; x < model_Board.Size; x++)
            {
                for ( y = 0; y < model_Board.Size; y++)
                {
                    Gui_Cell gui_Cell = new Gui_Cell(x, y);
                    guiGrid[x, y] = gui_Cell;
                    gui_Cell.Width = cellSize;
                    gui_Cell.Height = cellSize;
                    gui_Cell.ForeColor = Color.White;
                    gui_Cell.BackColor = Color.Black;
                    gui_Cell.Type = false;
                    gui_Cell.Pupet = null;
                    gui_Cell.Click += mainForm.Board_Click;
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
                    gui_Cell.Location = new Point(x * cellSize, y * cellSize);
                    divChess.Controls.Add(gui_Cell);
                }
            }

            Figure modelFigure;
            x = 0;
            y = 0;

            for (int i = 0; i < model_Figures.Model_whiteFiguresON.Count; i++)
            {
                x = model_Figures.Model_whiteFiguresON[i].X;
                y = model_Figures.Model_whiteFiguresON[i].Y;
                guiGrid[x, y].X = x;
                guiGrid[x, y].Y = y;
                guiGrid[x, y].Pupet = model_Figures.Model_whiteFiguresON[i];
                guiGrid[x, y].Type = true;
                if (model_Board.theGrid[x, y].Figure != null)
                {
                    modelFigure = model_Board.theGrid[x, y].Figure;
                    loadFiguresSkin(skin, guiGrid[x, y], modelFigure, model_Board.theGrid[x, y]);
                }
            }
            x = 0;
            y = 0;
            
            for (int i = 0; i < model_Figures.Model_blackFiguresON.Count; i++)
            {
                x = model_Figures.Model_blackFiguresON[i].X;
                y = model_Figures.Model_blackFiguresON[i].Y;
                guiGrid[x, y].X = x;
                guiGrid[x, y].Y = y;
                guiGrid[x, y].Pupet = model_Figures.Model_blackFiguresON[i];
                guiGrid[x, y].Type = true;
                if (model_Board.theGrid[x, y].Figure != null)
                {
                    modelFigure = model_Board.theGrid[x, y].Figure;
                    loadFiguresSkin(skin, guiGrid[x, y], modelFigure, model_Board.theGrid[x, y]);
                }
            }
        }

        public void RestartGui(string skin)
        {
            mainForm.BackgroundImage = gui_backgroundImages[skin][0];
            /*
            for (int x = 0; x < model_Board.Size; x++)
            {
                for (int y = 0; y < model_Board.Size; y++)
                {
                    if (model_Board.theGrid[x, y].Figure != null) // ha van rajta pápet
                    {
                        Figure modelFigure = model_Board.theGrid[x, y].Figure;
                        loadFiguresSkin(skin, guiGrid[x, y], modelFigure, model_Board.theGrid[x, y]);
                    }
                    else
                    {
                        switch (model_Board.theGrid[x,y].CellBkgColor)
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
            }
            */
        }
        public void loadFiguresSkin(string skin, Gui_Cell guiCell, Figure modelFigure, Cell modelCell)
        {
            guiCell.ForeColor = Color.White;
            guiCell.BackColor = Color.Black;
            switch (modelCell.CellBkgColor)
            {
                case "light":
                    guiCell.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject($"{skin}_figure_" +
                        $"{modelFigure.Side}_" +
                        $"{"light"}_" +
                        $"{modelFigure.Type}");

                    break;
                case "dark":
                    guiCell.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject($"{skin}_figure_" +
                        $"{modelFigure.Side}_" +
                        $"{"dark"}_" +
                        $"{modelFigure.Type}");
                    break;
            }
        }
       


    }
}
