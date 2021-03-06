﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;

namespace Quadris
{
    class GuiController
    {
        int rowsHighlighted = 0; // count of currently highlightet rows
        SolidColorBrush lightGray = new SolidColorBrush(Colors.LightGray);
        SolidColorBrush blue = new SolidColorBrush(Color.FromArgb(255, 0x00, 0xAA, 0xFF));
        SolidColorBrush orange = new SolidColorBrush(Colors.Orange);
        Rectangle rect;

        // reset last 4 blocks selected
        public void resetSelection(Block block, GridView grid, int[,] gameFieldArray) {


            for (int i = 0; i < block.getClickedIndexes().GetLength(0); i++)
            {

                rect = grid.Items[block.getClickedIndexes()[i]] as Rectangle;
                rect.Fill = lightGray;

            }

            block.resetState(gameFieldArray);

        }

        // set image for next block
        public void setNextBlockImage(Image image, Block block) {

            image.Source = new BitmapImage(new Uri("ms-appx:/Assets/Blocks/" + block.getImageName(), UriKind.Absolute));
        
        }

        //update scoreTextBox
        public void updateScore(TextBlock label, int score) {
            
            label.Text = "Score : " + score;

        }

        // start a new game, reset color of field and score
        public void newGame(GridView grid,TextBlock label) {

            for (int i = 0; i < grid.Items.Count; i++) {

                rect = grid.Items[i] as Rectangle;
                rect.Fill = lightGray;
            
            }

            updateScore(label, 0);
       
        }

        // show gameOverScreen
        public void gameOver(Canvas GameOverScreen, TextBlock GameOverPoints, TextBlock GameOverHighScoreInfo, Button GameOverNewGame, Button GameOverExitGame, int points, bool isNewHighscore)
        {

            if (isNewHighscore)
            {

                GameOverHighScoreInfo.Text = "This is a new Highscore!";
            }

            else {

                GameOverHighScoreInfo.Text = "Your best score was " + GameController.getHighScore() + " points!";
            
            }

            // set size of game over window
            GameOverScreen.Height = Window.Current.Bounds.Height;
            GameOverScreen.Width = Window.Current.Bounds.Width;

            GameOverPoints.Text = points + " Points";
            GameOverScreen.IsHitTestVisible = true;
            GameOverScreen.Opacity = 1;

        }

        //hide GameOverScreen
        public void hideGameOver(Canvas GameOverScreen) {

            GameOverScreen.IsHitTestVisible = false;
            GameOverScreen.Opacity = 0;
        
        }

        //togle Sound icon
        internal void toggleSound(Canvas MuteToggle)
        {
            ImageBrush ib = new ImageBrush();

            if (SoundController.isEnabled)
            {
                ib.ImageSource = new BitmapImage(new Uri("ms-appx:/Assets/sound.png", UriKind.Absolute));
            }

            else {

                ib.ImageSource = new BitmapImage(new Uri("ms-appx:/Assets/noSound.png", UriKind.Absolute));

            }

            MuteToggle.Background = ib;
        }

        //draw game array
        internal async Task drawGameArray(int[,] gameArray, GridView PlayingField)
        {
            // wait for 1 second
            await Task.Delay(TimeSpan.FromSeconds(1));

            // reset rows and count
            rowsHighlighted = 0;
            int count = 0;

            for (int i = 0; i < gameArray.GetLength(0); i++) {

                for (int j = 0; j <gameArray.GetLength(1); j++) {

                    rect = PlayingField.Items[count] as Rectangle;
                    if (gameArray[i, j] == 1) {
                        rect.Fill = blue;
                    }
                    else {
                        rect.Fill = lightGray;
                    }
                    count++;
                }
            }
        }

        // highlight rows
        internal void highlightRow(int row, GridView PlayingField)
        {
            for (int i = 0; i < 10; i++) {

                rect = PlayingField.Items[row -rowsHighlighted + (i * 10)] as Rectangle;
                rect.Fill = orange;
            }

            rowsHighlighted++;

        }
    }
}
