﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadris.Blocks
{
    class JBlock :Block
    {

        public JBlock() {

            blockName = "JBlock";
         blockCoordinates = new int[12, 2] {    { 0, 1 },// rotation 0
                                                { -1, 2 },
                                                { 0, 2 },
                                                { 1, 0 },// rotation 1
                                                { 2, 0 },
                                                { 2, 1 },
                                                { 1, 0 },// rotation 2
                                                { 0, 1 },
                                                { 0, 2 },
                                                { 0, 1 },// rotation 3
                                                { 1, 1 },
                                                { 2, 1 } };
        }
    }
}
