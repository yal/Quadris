using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadris
{
    interface Block
    {

         void rotate(); //change rotationstate of block
         bool checkIfPieceCanBePlaced(int[,] gameFieldArray, int x, int y); // Check if piece can be placed

    }
}
