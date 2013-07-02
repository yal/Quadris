using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadris
{
    class BlockControl
    {
        public void drawBlock(int[][] gameFieldArray, int centerIndexI, int centerIndexJ, int delta1I, int delta1J, int delta2I, int delta2J, int delta3I, int delta3J)
        {

            gameFieldArray[centerIndexI][centerIndexJ] = 1;
            gameFieldArray[centerIndexI+delta1I][centerIndexJ+delta1J] = 1;
            gameFieldArray[centerIndexI + delta2I][centerIndexJ + delta2J] = 1;
            gameFieldArray[centerIndexI + delta2I][centerIndexJ + delta2J] = 1;


        }
    }
}
