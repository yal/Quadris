using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadris
{
    class IBlock : Block
    {
        public int rotation = 0;


        public void placeBlock(int[][] gameFieldArray, int centerIndexI, int centerIndexJ)
        {
            // center is top right block
            gameFieldArray[centerIndexI][centerIndexJ] = 1;
            gameFieldArray[centerIndexI + 1][centerIndexJ] = 1;
            gameFieldArray[centerIndexI][centerIndexJ + 1] = 1;
            gameFieldArray[centerIndexI + 1][centerIndexJ + 1] = 1;

        }

        public void rotate()
        {
            if (rotation == 1)
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
