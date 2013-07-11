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
        Block block = null;
        public MainPage()
        {
            this.InitializeComponent();
            Array.Clear(gameArray, 0, gameArray.Length);
            gameController = new GameController();
            guiController = new GuiController();
            block = gameController.getRandomBlock();
            guiController.setNextBlockImage(NextBlockImage,block);
        }

        /// <summary>
        /// Wird aufgerufen, wenn diese Seite in einem Rahmen angezeigt werden soll.
        /// </summary>
        /// <param name="e">Ereignisdaten, die beschreiben, wie diese Seite erreicht wurde. Die
        /// Parametereigenschaft wird normalerweise zum Konfigurieren der Seite verwendet.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void PlayingField_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem != null)
            {
                Rectangle rect =  e.ClickedItem as Rectangle;
                int index = PlayingField.Items.IndexOf(rect);
                int x = (int)(index / 10);
                int y = index % 10;
                if (block.checkIfPieceCanBePlaced(gameArray, x, y))
                {

                    rect.Fill = new SolidColorBrush(Color.FromArgb(255, 0x00, 0xAA, 0xFF));

                }

                else {

                    GuiController.resetSelection(block,PlayingField,gameArray);
       
                }

                if (block.piecesPlaced == 4) {

                    block = gameController.getRandomBlock();
                    guiController.setNextBlockImage(NextBlockImage, block);
                    guiController.updateScore(Score);
                
                }

            }

        }
    }
}
