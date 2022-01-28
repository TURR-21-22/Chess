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
        public bool CellProps = true;

        public Board (int s)
        {
            Size = s;
            theGrid = new Cell[Size, Size];
           
            for (int x = 0; x < Size; x++)
            {
                CellProps = !CellProps;
                for (int y = 0; y < Size; y++)
                {
                    CellProps = !CellProps;
                    Cell cell = new Cell(x, y);
                    theGrid[x, y] = cell;
                    cell.LegalNextMove = false;
                    cell.Occupied = false;
                    cell.CellFigure = null;
                    if (CellProps) { cell.CellBkgColor = "light"; } else { cell.CellBkgColor = "dark"; }
                }
            }

            List<Figure> white = model_Figures.Model_whiteFiguresON;
            List<Figure> black = model_Figures.Model_blackFiguresON;

            for (int i = 0; i < white.Count; i++)
            {
                theGrid[white[i].X, white[i].Y].Occupied = true;
                theGrid[white[i].X, white[i].Y].CellFigure = white[i];
                white[i].FigureCell = theGrid[white[i].X, white[i].Y];
                theGrid[black[i].X, black[i].Y].Occupied = true;
                theGrid[black[i].X, black[i].Y].CellFigure = black[i];
                black[i].FigureCell = theGrid[black[i].X, black[i].Y];

            }
        }

        public void MarkNextLegalMove(Cell currentCell, string chessPiece)
        {
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    theGrid[x, y].LegalNextMove = false;
                    if (theGrid[x, y].CellFigure != null)
                    {
                        theGrid[x, y].CellFigure.Kick = false;
                    }
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
        }


        private void gyalog(Cell currentCell)
        {
            int steps;
            int x = currentCell.X;
            int y = currentCell.Y;
            int[,] stepsWhite = new int[2,2] { { -1, -1 }, { 1, -1 } };
            int[,] stepsBlack = new int[2,2] { { -1, 1 }, { 1, 1 } };
            int[,] arr = new int[2, 2];
            string side = currentCell.CellFigure.Side;
            if (side == "white") {
                steps = -1;
                arr = stepsWhite; 
            } else {
                steps = 1;
                arr = stepsBlack; 
            }
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                if (currentCell.X + arr[i, 0] >= 0 &&
                    currentCell.Y + arr[i, 1] >= 0 &&
                    currentCell.X + arr[i, 0] < Size &&
                    currentCell.Y + arr[i, 1] < Size )
                {
                    x = currentCell.X + arr[i, 0];
                    y = currentCell.Y + arr[i, 1];
                    if (theGrid[x, y].Occupied && theGrid[x, y].CellFigure.Side != side)
                    {
                        theGrid[x, y].LegalNextMove = true;
                        theGrid[x, y].CellFigure.Kick = true;
                    }
                }
            }
            
            x = currentCell.X;
            y = currentCell.Y;
            if ( y + steps >= 0 && y + steps < Size)
            {
                if (!theGrid[x, y + steps].Occupied)
                {
                    theGrid[x, y + steps].LegalNextMove = true;
                }
            }
            
            
        }


        private void OneStepPath(Cell currentCell, int[,] arr)
        {
            string side = currentCell.CellFigure.Side;
            int x = currentCell.X;
            int y = currentCell.Y;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                if (currentCell.X + arr[i, 0] >= 0 &&
                    currentCell.Y + arr[i, 1] >= 0 &&
                    currentCell.X + arr[i, 0] < Size &&
                    currentCell.Y + arr[i, 1] < Size )
                {
                    x = currentCell.X + arr[i, 0];
                    y = currentCell.Y + arr[i, 1];
                    if (!theGrid[x, y].Occupied)
                    {
                        theGrid[x, y].LegalNextMove = true;
                    }
                    else if (theGrid[x, y].CellFigure.Side != side)
                    {
                        theGrid[x, y].LegalNextMove = true;
                        theGrid[x, y].CellFigure.Kick = true;
                    }
                }
            }
        }

        private void LinearPath(Cell currentCell)
        {
            string side = currentCell.CellFigure.Side;
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

                    if ( theGrid[x, y].Occupied)
                    {
                        if (theGrid[x, y].CellFigure.Side != side)
                        {
                            theGrid[x, y].LegalNextMove = true;
                            theGrid[x, y].CellFigure.Kick = true;
                        }
                        break;
                    }
                    theGrid[x, y].LegalNextMove = true;
                }
            }
        }
        private void DiagonalPath(Cell currentCell)
        {
            string side = currentCell.CellFigure.Side;
            int[,] diagonalSteps = new int[4, 4] { { -1, -1, 0, 0 }, { 1, -1, Size - 1, 0 }, { 1, 1, Size - 1, Size - 1 }, { -1, 1, 0, Size - 1 } };
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
                    if (theGrid[x, y].Occupied)
                    {
                        if (theGrid[x, y].CellFigure.Side != side)
                        {
                            theGrid[x, y].LegalNextMove = true;
                            theGrid[x, y].CellFigure.Kick = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    theGrid[x, y].LegalNextMove = true;
                }
            }
        }


    }
}
