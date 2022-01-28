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
        Form_Game form_game = null;
        static RenderInit renderInit;
        static RenderFunctions renderFunctions;
        static Debug debug;
        private static Board model_Board = RenderInit.model_Board;
        public static Gui_Cell[,] gui_Grid = RenderInit.gui_Grid;
        public static Label[,] debugGrid = Debug.debugGrid;

        public bool debugSwitch = true;
        public int clickCounter = 0;
        public Figure clickedFigure = null;

        public RenderMain(Form_Game ob)
        {
            this.form_game = ob;
        }

        public void Init() 
        {
            //renderInit = new RenderInit(form_game);
            renderInit = new RenderInit(form_game);
            renderFunctions = new RenderFunctions(form_game);
            debug = new Debug(form_game);
        }

        internal void Board_Click(object sender)
        {
            switch (clickCounter)
            {
                case 0:
                    clickCounter = 1;
                    break;
                case 1:
                    clickCounter = 0;
                    break;

            }
            
            string figureType;

            Cell[,] modelGrid = model_Board.theGrid;
            Gui_Cell[,] guiGrid = gui_Grid;
            Cell modelCell;
            int sourceX;
            int sourceY;

            switch (sender.GetType().Name)
            {
                case "Gui_Cell":
                    if (clickedFigure != null)
                    {
                        Gui_Cell target_GuiCell = (Gui_Cell)sender;
                        int targetX = target_GuiCell.X;
                        int targetY = target_GuiCell.Y;
                        sourceX = clickedFigure.X;
                        sourceY = clickedFigure.Y;
                        
                        Figure modelFigure = clickedFigure;
                        clickedFigure = null;
                        // set target_modelCell props ( clickedFigure, Occupied = true)
                        // set source modelCell props (Figure FigureCell = null, Occupied = false)
                        // set source modelFigure props (targetX,targetY, target_modelCell)
                        // set target_guiCell props ( Gui_Figure CellFigure,      //Occupied = true)
                        // set source guiFigure props ( targetX,targetY)
                        // set source guiFigure location to target_guiCell.Location

                        Cell target_modelCell = modelGrid[targetX, targetY];
                        target_modelCell.Occupied = true;
                        target_modelCell.CellFigure = modelFigure;

                        Cell source_modelCell = modelGrid[sourceX, sourceY];
                        source_modelCell.CellFigure = null;
                        source_modelCell.Occupied = false;

                        modelFigure.X = targetX;
                        modelFigure.Y = targetX;
                        modelFigure.FigureCell = target_modelCell;

                        Gui_Figure source_GuiFigure = guiGrid[sourceX, sourceY].CellFigure;
                        target_GuiCell.CellFigure = source_GuiFigure;

                        source_GuiFigure.X = targetX;
                        source_GuiFigure.Y = targetY;
                        source_GuiFigure.Location = target_GuiCell.Location;
                        string skin = renderInit.Skin;
                        switch (target_modelCell.CellBkgColor)
                        {
                            case "light":
                                source_GuiFigure.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(
                                    $"{ skin}_figure_" +
                                    $"{ modelFigure.Side }_" +
                                    $"{ "light" }_" +
                                    $"{ modelFigure.Type }");

                                break;
                            case "dark":
                                source_GuiFigure.BackgroundImage = (Image)Properties.Resources.ResourceManager.GetObject(
                                    $"{skin}_figure_" +
                                    $"{modelFigure.Side}_" +
                                    $"{"dark"}_" +
                                    $"{modelFigure.Type}");
                                break;
                        }
                        renderFunctions.clearMainboardCellsBorder();

                    }
                    break;

                case "Gui_Figure":
                    
                    Gui_Figure guiFigure = (Gui_Figure)sender;
                    sourceX = guiFigure.X;
                    sourceY = guiFigure.Y;
                    figureType = guiFigure.Type;
                    modelCell = modelGrid[sourceX, sourceY];
                    clickedFigure = modelGrid[sourceX, sourceY].CellFigure;

                    model_Board.MarkNextLegalMove( modelCell, figureType);

                    renderFunctions.drawMain(new Point(sourceX, sourceY), figureType);
                    renderFunctions.drawDebug(modelGrid);
                    break;
            }
        }

        public void SelectSkin(object sender)
        {
            ComboBox cmb = (ComboBox)sender;

            renderInit.RestartGui(cmb.SelectedItem.ToString());
        }



    }
}
