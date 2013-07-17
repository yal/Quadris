using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;
using Windows.UI.Xaml.Controls;

namespace Quadris
{
    class SoundController
    {
        public MediaElement snd;

        public async void init() {

            var package = Windows.ApplicationModel.Package.Current;
            var installedLocation = package.InstalledLocation;
            var storageFile = await installedLocation.GetFileAsync("Assets\\select.wav");
            if (storageFile != null)
            {
                var stream = await storageFile.OpenAsync(Windows.Storage.FileAccessMode.Read);
                snd = new MediaElement();
                snd.AutoPlay = false;
                snd.SetSource(stream, storageFile.ContentType);

            }
        
        }

        public void playSelect()
        {
            snd.Play();

        }
    } 
}
