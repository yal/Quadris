using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadris
{
    class IBlock : BlockControl, Block
    {
        public IBlock() {

            blockCoordinates = new int[12, 2] { { 0, 1 },// rotation 0
                                                { 0, 2 },
                                                { 0, 3 },
                                                { 1, 0 },// rotation 1
                                                { 2, 0 },
                                                { 3, 0 },
                                                { 0, 1 },// rotation 2
                                                { 0, 2 },
                                                { 0, 3 },
                                                { 1, 0 },// rotation 3
                                                { 2, 0 },
                                                { 3, 0 } };

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




        public bool checkIfPieceCanBePlaced(int[,] gameFieldArray, int x, int y)
        {
            if (piecesPlaced == 0)
            {
                if (gameFieldArray[x,y] != 1)
                { 
                    clickedIndexes[0,0]=x;
                    clickedIndexes[0,1]=y;
                    piecesPlaced++;
                    return true; }
            }

            if (piecesPlaced == 1)
            {
                if (gameFieldArray[x,y] != 1)
                {
                    int deltaX = Math.Abs(clickedIndexes[0,0] - x);
                    int deltaY = Math.Abs(clickedIndexes[0,1] - y);

                    for (int i = 0 + 3 * rotation; i < 3 + 3 * rotation; i++) {

                        if (blockCoordinates[i, 0] == deltaX && blockCoordinates[i, 1] == deltaY) {

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
                if (gameFieldArray[x,y] != 1)
                {

                        int deltaX = Math.Abs(getSmallestIndex()[0] - x);
                        int deltaY = Math.Abs(getSmallestIndex()[1] - y);

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
                if (gameFieldArray[x,y] != 1)
                {

                        int deltaX = Math.Abs(getSmallestIndex()[0] - x);
                        int deltaY = Math.Abs(getSmallestIndex()[1] - y);

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
