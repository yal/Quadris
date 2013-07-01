using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadris
{
    interface Block
    {
        // Properties:
        int rotation
        {
            get;
            set;
        }

        public void drawBlock(int[][] gameFieldArray, int centerIndex); //draw block in gameArray
        public void rotate(); //change rotationstate of block
        public void checkIfBlockCanBePlaced(int[][] gameFieldArray, int centerIndex); // Check if block can be placed around current centerIndex

    }
}
