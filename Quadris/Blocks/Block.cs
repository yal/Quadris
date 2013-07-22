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
        public string blockName; // name of the block
        public int[,] clickedIndexes = new int[4, 2]; // clicked Indexes in gameArray
        public int[,] blockCoordinates; //saves coordinates accroding to upper left block ( rotationstate1 : blockCoordinates[0-2][0/1] etc. )

        // reset block status
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

        // get selected indexes converted to GridViewIndexes
        public int[] getClickedIndexes()
        {

            int[] results = new int[piecesPlaced];
            for (int i = 0; i < piecesPlaced; i++)
            {
                results[i] = (clickedIndexes[i, 0] * 10) + clickedIndexes[i, 1];
            }

            return results;
        }

        // rotate CCV
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

        // overload rotate() to rotate to a certain state (int i, 0-3)
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

        // order clicked indexes (Bubblesort)
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

        }

        // check if clicked piece can be placed
        public bool checkIfPieceCanBePlaced(int[,] gameFieldArray, int x, int y)
        {
                if (gameFieldArray[x, y] != 1)
                {
                    clickedIndexes[piecesPlaced, 0] = x;
                    clickedIndexes[piecesPlaced, 1] = y;
                    gameFieldArray[x, y] = 1;
                    piecesPlaced++;

                    if (piecesPlaced == 4) 
                        return checkIfBlockIsValid();
  
                    return true;
                }
            
            return false;
        }

        // check if block as a whole is valid
        public bool checkIfBlockIsValid()
        {

            orderClickedIndexes();

            for (int i = 1; i < clickedIndexes.GetLength(0);i++) {

                int deltaX = clickedIndexes[i,0]-clickedIndexes[0,0];
                int deltaY = clickedIndexes[i,1]-clickedIndexes[0,1];
                
                if (deltaX != blockCoordinates[(i-1) + 3 * rotation, 0] || deltaY != blockCoordinates[(i-1) + 3 * rotation, 1]) {
                    
                    return false;
                } 
            }

            return true;
        }
    }
}
