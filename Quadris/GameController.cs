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
        static Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
        public Random rnd;
        DateTime startTime;
        public int score = 0;

        public GameController()
        {

            rnd = new Random(); // seed rnd
            startTime = DateTime.Now;

        }

        public void newGame()
        {

            score = 0;
            startTime = DateTime.Now;
            rnd = new Random();

        }

        public Block getRandomBlock()
        {

            int blockType = rnd.Next(7);
            int rorationState = rnd.Next(4);
            Block block = null;

            switch (blockType)
            {
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

        //calculate current score
        public int getScore()
        {

            DateTime endTime = DateTime.Now;
            TimeSpan duration = endTime - startTime;
            startTime = endTime;
            score = score + 170 + (100 / (duration.Seconds * 4));
            return score;
        }

        //get saved highscore
        public static int getHighScore()
        {
            return (int)localSettings.Values["score"];
        }

        // check for new score
        public bool isNewHighScore()
        {

            // check if key exists
            if (!localSettings.Values.ContainsKey("score"))
            {

                localSettings.Values["score"] = 0;

            }

            // read old highScore
            int oldScore = (int)localSettings.Values["score"];

            // check if new score is higher 
            if (oldScore < score)
            {

                //update highscore
                localSettings.Values["score"] = score;
                return true;

            }

            return false;

        }

        public bool checkIfNextMoveIsPossible(int[,] gameFiedlArray, Block block)
        {

            for (int i = 0; i < gameFiedlArray.GetLength(0); i++)
            {

                for (int j = 0; j < gameFiedlArray.GetLength(1); j++)
                {

                    if (gameFiedlArray[i, j] == 0)
                    {

                        // check for index out of range
                        if (
                            Enumerable.Range(0, 10).Contains(i + block.blockCoordinates[0 + block.rotation * 3, 0]) &&
                            Enumerable.Range(0, 10).Contains(i + block.blockCoordinates[1 + block.rotation * 3, 0]) &&
                            Enumerable.Range(0, 10).Contains(i + block.blockCoordinates[2 + block.rotation * 3, 0]) &&
                            Enumerable.Range(0, 10).Contains(j + block.blockCoordinates[0 + block.rotation * 3, 1]) &&
                            Enumerable.Range(0, 10).Contains(j + block.blockCoordinates[1 + block.rotation * 3, 1]) &&
                            Enumerable.Range(0, 10).Contains(j + block.blockCoordinates[2 + block.rotation * 3, 1])
)
                        {
                            // check if fields are free
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

        // check for full rows
        public int checkRows(int[,] gameFieldArray)
        {
            int counter = 0;
            int row = -1; // index of full row
            for (int i = 0; i < 10 ; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (gameFieldArray[j, i] == 1 && gameFieldArray[j+1, i] == 1)
                        counter++;

                    if (counter == 9)
                        row = i;
                }

                counter = 0; // reset counter for new row
            }

            return row;
        }

        // delete full Rows
        public int[,] deleteRow(int[,] gameFieldArray, int row)
        {
            int[,] helpArray = new int[10, 10];
            Array.Clear(helpArray, 0, helpArray.Length); // zero out array
            int deltaRow = 0;

            // start to fill ne new array bottomn to top, ignore the line to delete
            for (int i = gameFieldArray.GetLength(0)-1; i >= 0; i--) {
                for (int j = gameFieldArray.GetLength(1)-1; j >= 0; j--) {

                    if (i == row)
                    {
                        deltaRow = -1;
                        break;
                    }

                    else {

                            helpArray[j, i-deltaRow] = gameFieldArray[j, i];
                    }
                
                }
            }

                return helpArray;
        }

        // get xCoordinate
        internal int getX(int index)
        {
           return (int)(index / 10);
        }
       
        // get yCoordinate
        internal int getY(int index)
        {
            return index % 10;
        }
    }
}
