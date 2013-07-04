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
        IBlock block = new IBlock();
        public MainPage()
        {
            this.InitializeComponent();
            Array.Clear(gameArray, 0, gameArray.Length);


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
                rect.Fill = new SolidColorBrush(Color.FromArgb(255,0x00,0xAA,0xFF));
                System.Diagnostics.Debug.WriteLine(block.checkIfPieceCanBePlaced(gameArray, 1, 1));
                System.Diagnostics.Debug.WriteLine(block.checkIfPieceCanBePlaced(gameArray, 2, 0));
                System.Diagnostics.Debug.WriteLine(block.checkIfPieceCanBePlaced(gameArray, 1, 2));
                System.Diagnostics.Debug.WriteLine(block.checkIfPieceCanBePlaced(gameArray, 4, 4));
                System.Diagnostics.Debug.WriteLine(block.checkIfPieceCanBePlaced(gameArray, 1, 3));

            }

        }
    }
}
