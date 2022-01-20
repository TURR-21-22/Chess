using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardModel
{
    public class Board
    {
        private void OneStepPath(Cell currentCell, int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                if (currentCell.RowNumber + arr[i, 0] >= 0 &&
                    currentCell.ColumnNumber + arr[i, 1] >= 0 &&
                    currentCell.RowNumber + arr[i, 0] < Size &&
                    currentCell.ColumnNumber + arr[i, 1] < Size )
                {
                    theGrid[currentCell.RowNumber + arr[i, 0], currentCell.ColumnNumber + arr[i, 1]].LegalNextMove = true;
                }
            }
        }

        private void LinearPath(Cell currentCell)
        {
            for (int i = 0; i < Size; i++)
            {
                theGrid[currentCell.RowNumber, i].LegalNextMove = true;
                theGrid[i, currentCell.ColumnNumber].LegalNextMove = true;
            }
        }

        private void DiagonalPath(Cell currentCell)
        {
            int[,] diagonalSteps = new int[4, 4] { { -1, -1, 0, 0 }, { 1, -1, Size-1, 0 }, { 1, 1, Size-1, Size-1 }, { -1, 1, 0, Size-1 } };
            List<int[]> arrayList = new List<int[]>();
            for (int i = 0; i < diagonalSteps.GetLength(0); i++)
            {
                int x = currentCell.RowNumber;
                int y = currentCell.ColumnNumber;
                int j = 1;
                while (x != diagonalSteps[i, 2] && y != diagonalSteps[i, 3])
                {
                    if (x != diagonalSteps[i, 2])
                    {
                        x = currentCell.RowNumber + (diagonalSteps[i, 0] * j);
                    }
                    if (y != diagonalSteps[i, 3])
                    {
                        y = currentCell.ColumnNumber + (diagonalSteps[i, 1] * j);
                    }
                    j++;
                    arrayList.Add(new int[] { x, y });
                }
            }
            for (int i = 0; i < arrayList.Count; i++)
            {
                theGrid[arrayList[i][0], arrayList[i][1]].LegalNextMove = true;
            }
        }

        public int Size { get; set; }
        public Cell[,] theGrid { get; set; }
        public Board (int s)
        {
            Size = s;
            theGrid = new Cell[Size, Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j] = new Cell(i, j);
                }
            }
        }

        public void MarkNextLegalMove(Cell currentCell, string chessPiece)
        {
            //  step 1 - clear all previous legal moves
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j].LegalNextMove = false;
                    theGrid[i, j].CurrentlyOccupied = false;
                }
            }
            
            switch (chessPiece)
            {
                case "knight":
                    OneStepPath(currentCell,new int[8,2] { { 2, 1 }, { -2, 1 }, { +2, -1 }, { -2, -1 }, { 1, 2 }, { -1, 2 }, { 1, -2 }, { -1, -2 } });
                    break;
                case "king":
                    OneStepPath(currentCell, new int[8,2] { { -1, -1 }, { 0, -1 }, { 1, -1 }, { 1, 0 }, { 1, 1 }, { 0, 1 }, { -1, 1 }, { -1,  0} });
                    break;
                case "rook": // bástya
                    LinearPath(currentCell);
                    break;
                case "bishop": // futó
                    DiagonalPath(currentCell);
                    break;
                case "queen":
                    LinearPath(currentCell);
                    DiagonalPath(currentCell);
                    break;
                case "pawn":
                    break;
                default:
                    break;
            }
            theGrid[currentCell.RowNumber, currentCell.ColumnNumber].CurrentlyOccupied = true;
        }
    }
}
