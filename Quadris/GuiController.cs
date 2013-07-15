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
        public static void resetSelection(Block block, GridView grid, int[,] gameFieldArray) {

            SolidColorBrush brush = new SolidColorBrush(Colors.LightGray);

            for (int i = 0; i < block.getClickedIndexes().GetLength(0); i++)
            {

                Rectangle rect = grid.Items[block.getClickedIndexes()[i]] as Rectangle;
                rect.Fill = brush;

            }

            block.resetState(gameFieldArray);

        }

        internal void setNextBlockImage(Image image, Block block) {

            image.Source = new BitmapImage(new Uri("ms-appx:/Assets/Blocks/" + block.getImageName(), UriKind.Absolute));
        
        }

        internal void updateScore(TextBlock label, int score) {
            label.Text = "Score : " + score;

        
        }

        internal void newGame(GridView grid,TextBlock label) {

            SolidColorBrush lightGray = new SolidColorBrush(Colors.LightGray);
            Rectangle rect;

            for (int i = 0; i < grid.Items.Count; i++) {

                rect = grid.Items[i] as Rectangle;
                rect.Fill = lightGray;
            
            }

            updateScore(label, 0);
       
        }



        internal static void gameOver(Canvas GameOverScreen, TextBlock GameOverPoints, TextBlock GameOverHighScoreInfo, Button GameOverNewGame, Button GameOverExitGame, int points, bool isNewHighscore)
        {
            GameController controller = new GameController();

            if (isNewHighscore)
            {

                GameOverHighScoreInfo.Text = "This is a new Highscore!";
            }

            else {

                GameOverHighScoreInfo.Text = "Your best score was " + controller.getHighScore() + "!";
            
            }
           
            GameOverPoints.Text = points + " Points";
            GameOverScreen.IsHitTestVisible = true;
            GameOverScreen.Opacity = 1;

        }

        internal void hideGameOver(Canvas GameOverScreen) {

            GameOverScreen.IsHitTestVisible = false;
            GameOverScreen.Opacity = 0;
        
        }
    }
}
