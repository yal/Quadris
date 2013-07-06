using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadris
{
    class IBlock : Block
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
    }
}
