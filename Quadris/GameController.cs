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
        DateTime startTime;
        public int score = 0;

        public GameController() {
            
            rnd = new Random(); // seed rnd
            startTime = DateTime.Now;
        
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

        public int getScore() {

            DateTime endTime = DateTime.Now;
            TimeSpan duration = endTime - startTime;
            startTime = endTime;
            score = score + 170 + (100 / duration.Seconds);
            return  score;
        }

        public bool checkIfNextMoveIsPossible(int[,] gameFiedlArray, Block block){

            for(int i = 0; i < gameFiedlArray.GetLength(0);i++) {
                
                for (int j = 0; j < gameFiedlArray.GetLength(1); j++){

                    
                    
                        if (gameFiedlArray[i, j] == 0)
                        {

                            if (
                                Enumerable.Range(0,10).Contains(i + block.blockCoordinates[0 + block.rotation * 3, 0]) &&
                                Enumerable.Range(0,10).Contains(i + block.blockCoordinates[1 + block.rotation * 3, 0]) &&
                                Enumerable.Range(0,10).Contains(i + block.blockCoordinates[2 + block.rotation * 3, 0]) &&
                                Enumerable.Range(0,10).Contains(j + block.blockCoordinates[0 + block.rotation * 3, 1]) &&
                                Enumerable.Range(0,10).Contains(j + block.blockCoordinates[1 + block.rotation * 3, 1]) &&
                                Enumerable.Range(0,10).Contains(j + block.blockCoordinates[2 + block.rotation * 3, 1])
)
                            {

                                if (gameFiedlArray[i + block.blockCoordinates[0 + block.rotation * 3, 0], j + block.blockCoordinates[0 + block.rotation * 3, 1]] == 0 &&
                                    gameFiedlArray[i + block.blockCoordinates[1 + block.rotation * 3, 0], j + block.blockCoordinates[1 + block.rotation * 3, 1]] == 0 &&
                                    gameFiedlArray[i + block.blockCoordinates[2 + block.rotation * 3, 0], j + block.blockCoordinates[2 + block.rotation * 3, 1]] == 0)
                                    return true;
                            }
                        }
                  
                
                }
            }

            return false;
        }
    }
}
