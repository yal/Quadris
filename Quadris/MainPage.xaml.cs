using Quadris.Blocks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// Die Elementvorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace Quadris
{

    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet werden kann oder auf die innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public int[,] gameArray = new int[10,10];
        GameController gameController;
        GuiController guiController;
        SoundController soundController;
        SolidColorBrush blue = new SolidColorBrush(Color.FromArgb(255, 0x00, 0xAA, 0xFF));
        Block block = null; // current block
        Block nextBlock = null; //following block

        public MainPage()
        {
            this.InitializeComponent();
            Array.Clear(gameArray, 0, gameArray.Length); // zero out array
            gameController = new GameController();
            guiController = new GuiController();
            soundController = new SoundController();
            soundController.init();
            block = gameController.getRandomBlock();
            nextBlock = gameController.getRandomBlock();
            guiController.setNextBlockImage(CurrentBlockImage,block);
            guiController.setNextBlockImage(NextBlockImage, nextBlock);

        }

        /// <summary>
        /// Wird aufgerufen, wenn diese Seite in einem Rahmen angezeigt werden soll.
        /// </summary>
        /// <param name="e">Ereignisdaten, die beschreiben, wie diese Seite erreicht wurde. Die
        /// Parametereigenschaft wird normalerweise zum Konfigurieren der Seite verwendet.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async void PlayingField_ItemClick(object sender, ItemClickEventArgs e)
        {
            // play click sound
            soundController.playSelect();

            if (e.ClickedItem != null)
            {

                Rectangle rect =  e.ClickedItem as Rectangle;
                
                int index = PlayingField.Items.IndexOf(rect);

                if (block.checkIfPieceCanBePlaced(gameArray, gameController.getX(index), gameController.getY(index)))
                {

                    rect.Fill = blue;

                }

                else {

                    guiController.resetSelection(block,PlayingField,gameArray);
       
                }

                // if clicked piece was the final one
                if (block.piecesPlaced == 4) {
                    
                    // switch blocks
                    block = nextBlock;
                    nextBlock = gameController.getRandomBlock();
                    guiController.setNextBlockImage(CurrentBlockImage, block);
                    guiController.setNextBlockImage(NextBlockImage, nextBlock);
                    
                    //update score
                    guiController.updateScore(Score,gameController.getScore());

                    // check for lines to delete
                    while (gameController.checkRows(gameArray) != -1)
                    {
                        int row = gameController.checkRows(gameArray);
                        guiController.highlightRow(row, PlayingField);
                        gameArray = gameController.deleteRow(gameArray, row);

                    }

                    // wait for highlight animation to end and redraw gameArray
                    await guiController.drawGameArray(gameArray, PlayingField);

                    // check if a next move is possible
                    if (!gameController.checkIfNextMoveIsPossible(gameArray, block)) {

                        guiController.gameOver(GameOverScreen,
                                               GameOverPoints,
                                               GameOverHighScoreInfo,
                                               GameOverNewGame,
                                               GameOverExitGame,
                                               gameController.score,
                                               gameController.isNewHighScore()
                                               );
                    }
                }
            }
        }

        private void onExitClicked(object sender, RoutedEventArgs e)
        {
            App.Current.Exit();
        }

        private void onNewGameClicked(object sender, RoutedEventArgs e)
        {
            gameController.newGame();
            guiController.newGame(PlayingField, Score);
            block = gameController.getRandomBlock();
            nextBlock = gameController.getRandomBlock();
            Array.Clear(gameArray, 0, gameArray.Length);
            guiController.setNextBlockImage(NextBlockImage, nextBlock);
            guiController.setNextBlockImage(CurrentBlockImage, block);
        }

        private void onGameOverNewGameClick(object sender, RoutedEventArgs e)
        {
            guiController.hideGameOver(GameOverScreen);
            onNewGameClicked(null,null);
        }

        private void onMuteToggle(object sender, TappedRoutedEventArgs e)
        {
            soundController.toggleSound();
            guiController.toggleSound(MuteToggle);

        }
    }
}
