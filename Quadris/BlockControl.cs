using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadris
{
    class BlockControl
    {
        public int rotation = 0; // rotation 0 - 3
        public int piecesPlaced = 0; // pieces places 0 - 3
        public int[,] clickedIndexes = new int[4, 2]; // clicked Indexes in gameArray
        public int[,] blockCoordinates; //saves coordinates accroding to center ( rotationstate1 : blockCoordinates[0-2][0/1] etc. )


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
    }
}
