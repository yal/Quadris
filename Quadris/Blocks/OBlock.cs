using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadris.Blocks
{
    class OBlock : Block
    {

        public OBlock() {

            blockCoordinates = new int[12, 2] { { 0, 1 },// rotation 0
                                                { 1, 0 },
                                                { 1, 1 },
                                                { 0, 1 },// rotation 1
                                                { 1, 0 },
                                                { 1, 1 },
                                                { 0, 1 },// rotation 2
                                                { 1, 0 },
                                                { 1, 1 },
                                                { 0, 1 },// rotation 3
                                                { 1, 0 },
                                                { 1, 1 } };

        
        }

    }
}
