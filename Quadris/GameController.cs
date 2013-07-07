using Quadris.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadris
{
    class GameController
    {
        public Random rnd;


        public GameController() {
            
            rnd = new Random(); // seed rnd
        
        }

        public Block getRandomBlock() {

            int blockType = rnd.Next(7);
            int rorationState = rnd.Next(4);
            Block block = null;

            switch (blockType) {
                case 0:
                    block = new OBlock();
                    break;
                case 1:
                    block = new IBlock();
                    break;
                case 2:
                    block = new SBlock();
                    break;
                case 3:
                    block = new ZBlock();
                    break;
                case 4:
                    block = new JBlock();
                    break;
                case 5:
                    block = new LBlock();
                    break;
                case 6:
                    block = new TBlock();
                    break;
            }

            block.rotate(rorationState);
            return block;
        }
    }
}
