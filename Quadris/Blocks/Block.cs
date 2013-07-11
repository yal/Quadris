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
        public string blockName;
        public int[,] clickedIndexes = new int[4, 2]; // clicked Indexes in gameArray
        public int[,] blockCoordinates; //saves coordinates accroding to center ( rotationstate1 : blockCoordinates[0-2][0/1] etc. )

        public void resetState(int[,] gameFieldArray)
        {
         for (int i = 0; i < piecesPlaced; i++)
            gameFieldArray[clickedIndexes[i, 0], clickedIndexes[i, 1]] = 0;
         
         piecesPlaced = 0;
         clickedIndexes = new int[4, 2];

        }

        public string getImageName()
        {

            return blockName + "_" + rotation + ".png";

        }


        public int[] getClickedIndexes()
        {

            int[] results = new int[piecesPlaced];
            for (int i = 0; i < piecesPlaced; i++)
            {

                results[i] = (clickedIndexes[i, 0] * 10) + clickedIndexes[i, 1];
            }

            return results;
        }

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

        //overload rotatefunction to rotate to certain state (int i, 0-3)
        public void rotate(int i)
        {
            // check for invalid rotation values
            if (i > 3 || i < 0)
            {
                return;
            }
            else
            {
                rotation = i;
            }

        }


        public void drawBlock(int[,] gameFieldArray, int lastClickedIndexI, int lastClickedIndexJ)
        {

            gameFieldArray[clickedIndexes[0, 0], clickedIndexes[0, 1]] = 1;
            gameFieldArray[clickedIndexes[1, 0], clickedIndexes[1, 1]] = 1;
            gameFieldArray[clickedIndexes[2, 0], clickedIndexes[2, 1]] = 1;
            gameFieldArray[lastClickedIndexI, lastClickedIndexJ] = 1;

        }

        public void orderClickedIndexes()
        {

            int[] temp = new int[2];
            int[,] cloned = new int[4,2];
            cloned = (int[,]) clickedIndexes.Clone();


            for (int i = 0; i < 4; i++)
            {
                for (int j = i + 1; j < 4; j++)
                {

                    if (clickedIndexes[i, 1] > clickedIndexes[j, 1])
                    {
                        temp[0] = clickedIndexes[i, 0];
                        temp[1] = clickedIndexes[i, 1];

                        clickedIndexes[i, 0] = clickedIndexes[j, 0];
                        clickedIndexes[i, 1] = clickedIndexes[j, 1];


                        clickedIndexes[j, 0] = temp[0];
                        clickedIndexes[j, 1] = temp[1];

                    }

                    else {

                        if (clickedIndexes[i, 1] == clickedIndexes[j, 1] && clickedIndexes[i, 0] > clickedIndexes[j, 0]) {
                            temp[0] = clickedIndexes[i, 0];
                            temp[1] = clickedIndexes[i, 1];

                            clickedIndexes[i, 0] = clickedIndexes[j, 0];
                            clickedIndexes[i, 1] = clickedIndexes[j, 1];


                            clickedIndexes[j, 0] = temp[0];
                            clickedIndexes[j, 1] = temp[1];
                        
                        
                        }
                    
                    }
                }
            }

            for (int k = 0; k < 4; k++)
            {
                System.Diagnostics.Debug.WriteLine("Old: [" + cloned[k,0] + ","+cloned[k,1]+"] New: [" + clickedIndexes[k,0] +","+clickedIndexes[k,1]+"]");
           }
        }

        public bool checkIfPieceCanBePlaced(int[,] gameFieldArray, int x, int y)
        {
            if (piecesPlaced == 0)
            {
                if (gameFieldArray[x, y] != 1)
                {
                    clickedIndexes[0, 0] = x;
                    clickedIndexes[0, 1] = y;
                    gameFieldArray[x, y] = 1;
                    piecesPlaced++;
                    return true;
                }
            }

            if (piecesPlaced == 1)
            {

                if (gameFieldArray[x, y] != 1)
                {

                    clickedIndexes[1, 0] = x;
                    clickedIndexes[1, 1] = y;
                    gameFieldArray[x, y] = 1;

                    piecesPlaced++;
                    return true;
                }
            }

            if (piecesPlaced == 2)
            {

                if (gameFieldArray[x, y] != 1)
                {
                    clickedIndexes[2, 0] = x;
                    clickedIndexes[2, 1] = y;
                    gameFieldArray[x, y] = 1;
                    piecesPlaced++;
                    return true;
                }
            }

            if (piecesPlaced == 3)
            {
                if (gameFieldArray[x, y] != 1)
                {
                    clickedIndexes[3, 0] = x;
                    clickedIndexes[3, 1] = y;
                    gameFieldArray[x, y] = 1;
                    piecesPlaced++;
                    return checkIfBlockIsValid();
                }
            }

            return false;
        }

        public bool checkIfBlockIsValid()
        {

            orderClickedIndexes();

            for (int i = 1; i < clickedIndexes.GetLength(0);i++) {
                int deltaX = clickedIndexes[i,0]-clickedIndexes[0,0];
                int deltaY = clickedIndexes[i,1]-clickedIndexes[0,1];

                System.Diagnostics.Debug.WriteLine("DeltaX: " + deltaX + " DeltaY: " + deltaY);
                
                if (deltaX != blockCoordinates[(i-1) + 3 * rotation, 0] || deltaY != blockCoordinates[(i-1) + 3 * rotation, 1]) {
                    return false;
                } 
            }
            return true;
        }
    }
}
