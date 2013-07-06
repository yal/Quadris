using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadris.Blocks
{
    class TBlock : Block
    {
        public TBlock() {

            blockCoordinates = new int[12, 2] { { 1, 0 },// rotation 0
                                                { 1, -1 },
                                                { 2, 0 },
                                                { 0, 1 },// rotation 1
                                                { -1, 1 },
                                                { 0, 2 },
                                                { 1, 0 },// rotation 2
                                                { 1, 1 },
                                                { 2, 0 },
                                                { 0, 1 },// rotation 3
                                                { 1, 1 },
                                                { 0, 2 } };

        
        }
    }
}
