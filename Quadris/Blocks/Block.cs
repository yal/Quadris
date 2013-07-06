using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadris
{
    class Block
    {
        public int rotation = 0; // rotation 0 - 3
        public int piecesPlaced = 0; // pieces places 0 - 3
        public int[,] clickedIndexes = new int[4, 2]; // clicked Indexes in gameArray
        public int[,] blockCoordinates; //saves coordinates accroding to center ( rotationstate1 : blockCoordinates[0-2][0/1] etc. )

        public void rotate()
        {
            if (rotation == 3)
            {
                rotation = 0;
            }
            else
            {
                rotation++;
            }

        }


        public void drawBlock(int[,] gameFieldArray, int lastClickedIndexI, int lastClickedIndexJ)
        {

            gameFieldArray[clickedIndexes[0, 0],clickedIndexes[0, 1]] = 1;
            gameFieldArray[clickedIndexes[1, 0],clickedIndexes[1, 1]] = 1;
            gameFieldArray[clickedIndexes[2, 0],clickedIndexes[2, 1]] = 1;
            gameFieldArray[lastClickedIndexI,lastClickedIndexJ] = 1;

        }

        public int[] getSmallestIndex() {

            int[] result = new int[2] {clickedIndexes[0,0],clickedIndexes[0,1]};


            for (int i = 1; i < piecesPlaced; i++) {
                if (result[1] > clickedIndexes[i, 1])
                {
                    result[0] = clickedIndexes[i, 0];
                    result[1] = clickedIndexes[i, 1];
                }
                else {

                    if (result[1] == clickedIndexes[i, 1] && result[0] > clickedIndexes[i, 0])
                    {
                        result[0] = clickedIndexes[i, 0];
                        result[1] = clickedIndexes[i, 1];
                    }
                
                }
            }

            return result;
        
        }

        public bool checkIfPieceCanBePlaced(int[,] gameFieldArray, int x, int y)
        {
            if (piecesPlaced == 0)
            {
                if (gameFieldArray[x, y] != 1)
                {
                    clickedIndexes[0, 0] = x;
                    clickedIndexes[0, 1] = y;
                    piecesPlaced++;
                    return true;
                }
            }

            if (piecesPlaced == 1)
            {
                if (gameFieldArray[x, y] != 1)
                {
                    int deltaX = x - clickedIndexes[0, 0];
                    int deltaY = y - clickedIndexes[0, 1];

                    for (int i = 0 + 3 * rotation; i < 3 + 3 * rotation; i++)
                    {

                        if (blockCoordinates[i, 0] == deltaX && blockCoordinates[i, 1] == deltaY)
                        {

                            clickedIndexes[1, 0] = x;
                            clickedIndexes[1, 1] = y;

                            piecesPlaced++;
                            return true;
                        }
                    }
                }
            }

            if (piecesPlaced == 2)
            {
                if (gameFieldArray[x, y] != 1)
                {

                    int deltaX = x - getSmallestIndex()[0];
                    int deltaY = y -getSmallestIndex()[1];

                    for (int j = 0 + 3 * rotation; j < 3 + 3 * rotation; j++)
                    {

                        if (blockCoordinates[j, 0] == deltaX && blockCoordinates[j, 1] == deltaY)
                        {
                            clickedIndexes[2, 0] = x;
                            clickedIndexes[2, 1] = y;
                            piecesPlaced++;
                            return true;
                        }
                    }
                }
            }

            if (piecesPlaced == 3)
            {
                if (gameFieldArray[x, y] != 1)
                {

                    int deltaX = x-getSmallestIndex()[0];
                    int deltaY = y-getSmallestIndex()[1];


                    for (int j = 0 + 3 * rotation; j < 3 + 3 * rotation; j++)
                    {

                        if (blockCoordinates[j, 0] == deltaX && blockCoordinates[j, 1] == deltaY)
                        {
                            clickedIndexes[3, 0] = x;
                            clickedIndexes[3, 1] = y;
                            piecesPlaced++;
                            return true;
                        }

                    }
                }
            }

            return false;
        }

    }
}
