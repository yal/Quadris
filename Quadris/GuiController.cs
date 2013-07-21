using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;

namespace Quadris
{
    class GuiController
    {   

        // reset last 4 blocks selected
        public void resetSelection(Block block, GridView grid, int[,] gameFieldArray) {

            SolidColorBrush lightGray = new SolidColorBrush(Colors.LightGray);

            for (int i = 0; i < block.getClickedIndexes().GetLength(0); i++)
            {

                Rectangle rect = grid.Items[block.getClickedIndexes()[i]] as Rectangle;
                rect.Fill = lightGray;

            }

            block.resetState(gameFieldArray);

        }

        // set image for nex block
        public void setNextBlockImage(Image image, Block block) {

            image.Source = new BitmapImage(new Uri("ms-appx:/Assets/Blocks/" + block.getImageName(), UriKind.Absolute));
        
        }

        //update scoreTextBox
        public void updateScore(TextBlock label, int score) {
            
            label.Text = "Score : " + score;

        }

        // start a new game, reset color of field and score
        public void newGame(GridView grid,TextBlock label) {

            SolidColorBrush lightGray = new SolidColorBrush(Colors.LightGray);
            Rectangle rect;

            for (int i = 0; i < grid.Items.Count; i++) {

                rect = grid.Items[i] as Rectangle;
                rect.Fill = lightGray;
            
            }

            updateScore(label, 0);
       
        }

        // show gameOverScreen
        public void gameOver(Canvas GameOverScreen, TextBlock GameOverPoints, TextBlock GameOverHighScoreInfo, Button GameOverNewGame, Button GameOverExitGame, int points, bool isNewHighscore)
        {
            GameController controller = new GameController();

            if (isNewHighscore)
            {

                GameOverHighScoreInfo.Text = "This is a new Highscore!";
            }

            else {

                GameOverHighScoreInfo.Text = "Your best score was " + controller.getHighScore() + " points!";
            
            }
           
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
        internal void drawGameArray(int[,] gameArray, GridView PlayingField)
        {
            SolidColorBrush lightGray = new SolidColorBrush(Colors.LightGray);
            SolidColorBrush blue = new SolidColorBrush(Color.FromArgb(255, 0x00, 0xAA, 0xFF));
            Rectangle rect;
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

        internal async Task highlightRow(int row, GridView PlayingField)
        {
            SolidColorBrush orange = new SolidColorBrush(Colors.Orange);
            Rectangle rect;
            for (int i = 0; i < 10; i++) {

                rect = PlayingField.Items[row + (i * 10)] as Rectangle;
                rect.Fill = orange;
            }

            await Task.Delay(TimeSpan.FromSeconds(0.5));
        }
    }
}
