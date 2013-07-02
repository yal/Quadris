using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadris
{
    class SBlock : BlockControl, Block
    {
        public int rotation = 0;


        public void placeBlock(int[][] gameFieldArray, int centerIndexI, int centerIndexJ)
        {
            if (!checkIfBlockCanBePlaced(gameFieldArray, centerIndexI, centerIndexJ))
                return;
            // center is edge
            switch (rotation)
            {
                case 0:
                    drawBlock(gameFieldArray, centerIndexI, centerIndexJ, 0, -1, 1, 0, 1, -1);
                    break;
                case 1:
                    drawBlock(gameFieldArray, centerIndexI, centerIndexJ, 1, 0, 0, 1, -1, 1);
                    break;
                default:
                    break;

            }
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

        public bool checkIfBlockCanBePlaced(int[][] gameFieldArray, int centerIndexI, int centerIndexJ)
        {
            if (gameFieldArray[centerIndexI][centerIndexJ] == 1)
            {
                return false;
            }

            if (gameFieldArray[centerIndexI + 1][centerIndexJ] == 1)
            {
                return false;
            }

            if (gameFieldArray[centerIndexI][centerIndexJ + 1] == 1)
            {
                return false;
            }

            if (gameFieldArray[centerIndexI + 1][centerIndexJ + 1] == 1)
            {
                return false;
            }

            return true;
        }

        int Block.rotation
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
