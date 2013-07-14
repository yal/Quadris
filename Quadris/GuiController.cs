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



        internal static void gameOver(Canvas GameOverSreen, TextBlock GameOverPoints, Button GameOverNewGame, Button GameOverExitGame, int points)
        {

            GameOverPoints.Text = points + " Points";
            GameOverSreen.IsHitTestVisible = true;
            GameOverSreen.Opacity = 1;

        }
    }
}
