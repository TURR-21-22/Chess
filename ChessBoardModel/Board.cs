using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardModel
{
    public class Board
    {
        
        public int Size { get; set; }
        public Cell[,] theGrid { get; set; }

        public static Figures model_Figures = new Figures();
        

        public Board (int s)
        {
            Size = s;
            theGrid = new Cell[Size, Size];
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    Cell cell = new Cell(x, y);
                    theGrid[x, y] = cell;
                    cell.LegalNextMove = false;
                    cell.CurrentlyOccupied = false;
                    cell.CellFigure = null;
                }
            }

            List<Figure> white = model_Figures.WhiteFiguresON;
            List<Figure> black = model_Figures.BlackFiguresON;

            for (int i = 0; i < model_Figures.BlackFiguresON.Count; i++)
            {

                theGrid[white[i].X, white[i].Y].CurrentlyOccupied = true;
                theGrid[white[i].X, white[i].Y].CellFigure = white[i];
                theGrid[black[i].X, black[i].Y].CurrentlyOccupied = true;
                theGrid[black[i].X, black[i].Y].CellFigure = black[i];
            }
            

        }


        public void MarkNextLegalMove(Cell currentCell, string chessPiece)
        {
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    theGrid[x, y].LegalNextMove = false;
                }
            }
            
            switch (chessPiece)
            {
                case "huszar":
                    OneStepPath(currentCell,new int[8,2] { { 2, 1 }, { -2, 1 }, { +2, -1 }, { -2, -1 }, { 1, 2 }, { -1, 2 }, { 1, -2 }, { -1, -2 } });
                    break;
                case "kiraly":
                    OneStepPath(currentCell, new int[8,2] { { -1, -1 }, { 0, -1 }, { 1, -1 }, { 1, 0 }, { 1, 1 }, { 0, 1 }, { -1, 1 }, { -1,  0} });
                    break;
                case "bastya":
                    LinearPath(currentCell);
                    break;
                case "futo":
                    DiagonalPath(currentCell);
                    break;
                case "kiralyno":
                    LinearPath(currentCell);
                    DiagonalPath(currentCell);
                    break;
                case "gyalog":
                    gyalog(currentCell);
                    break;
                default:
                    break;
            }
            //theGrid[currentCell.X, currentCell.Y].CurrentlyOccupied = true;
        }


        private void gyalog(Cell currentCell)
        {
            
        }


        private void OneStepPath(Cell currentCell, int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                if (currentCell.X + arr[i, 0] >= 0 &&
                    currentCell.Y + arr[i, 1] >= 0 &&
                    currentCell.X + arr[i, 0] < Size &&
                    currentCell.Y + arr[i, 1] < Size)
                {
                    theGrid[currentCell.X + arr[i, 0], currentCell.Y + arr[i, 1]].LegalNextMove = true;
                }
            }
        }

        private void LinearPath(Cell currentCell)
        {
            int[,] linearSteps = new int[4, 2] { { 0, -1 }, { 0, 1 }, { -1, 0 }, { 1, 0 } };
            int cnt = 0;
            for (int i = 0; i < linearSteps.GetLength(0); i++)
            {
                int x = currentCell.X;
                int y = currentCell.Y;
                switch (i)
                {
                    case 0:
                        cnt = y+1;
                        break;
                    case 1:
                        cnt = Size-y;
                        break;
                    case 2:
                        cnt = x+1;
                        break;
                    case 3:
                        cnt = Size-x;
                        break;
                }
                for (int j = 1; j < cnt; j++)
                {
                    x = currentCell.X + linearSteps[i, 0]*j;
                    y = currentCell.Y + linearSteps[i, 1]*j;

                    if ( theGrid[x, y].CurrentlyOccupied == true)
                    {
                        theGrid[x, y].LegalNextMove = true;
                        break;
                    }
                    theGrid[x, y].LegalNextMove = true;
                }
            }
        }
        private void DiagonalPath(Cell currentCell)
        {
            
            int[,] diagonalSteps = new int[4, 4] { { -1, -1, 0, 0 }, { 1, -1, Size - 1, 0 }, { 1, 1, Size - 1, Size - 1 }, { -1, 1, 0, Size - 1 } };
            List<int[]> legal_List = new List<int[]>();
            List<int[]> kick_List = new List<int[]>();
            //Cell[,] grid = model_Board.theGrid;
            for (int i = 0; i < diagonalSteps.GetLength(0); i++)
            {
                int x = currentCell.X;
                int y = currentCell.Y;
                int j = 1;
                
                while (x != diagonalSteps[i, 2] && y != diagonalSteps[i, 3])
                {
                    if (x != diagonalSteps[i, 2]) { x = currentCell.X + (diagonalSteps[i, 0] * j); }
                    if (y != diagonalSteps[i, 3]) { y = currentCell.Y + (diagonalSteps[i, 1] * j); }
                    j++;
                    
                    
                    if (theGrid[x, y].CurrentlyOccupied)
                    {
                        legal_List.Add(new int[] { x, y });
                        theGrid[x, y].LegalNextMove = true;
                        break;
                    }
                    
                    legal_List.Add(new int[] { x, y });
                    theGrid[x, y].LegalNextMove = true;
                }
            }
            /*
            for (int i = 0; i < arrayList.Count; i++)
            {
                int x = arrayList[i][0];
                int y = arrayList[i][1];
                theGrid[x, y].LegalNextMove = true;
            }
            */
        }


    }
}
