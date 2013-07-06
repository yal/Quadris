using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadris.Blocks
{
    class SBlock : Block
    {

        public SBlock() {

            blockCoordinates = new int[12, 2] { { 1, 0 },// rotation 0
                                                { 0, 1 },
                                                { -1, 1 },
                                                { 0, 1 },// rotation 1
                                                { 1, 1 },
                                                { 1, 2 },
                                                { 1, 0 },// rotation 2
                                                { 0, 1 },
                                                { -1, 1 },
                                                { 0, 1 },// rotation 3
                                                { 1, 1 },
                                                { 1, 2 } };

        
        }

    }
}
