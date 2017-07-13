using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Spielwiese.Functions.Miscellaneous
{
    public class AddonDownloader
    {
        private WebClient _client;

        public AddonDownloader()
        {
            _client = null;
        }

        public void DownloadFile(string url)
        {
            if (_client != null)
                return;

            _client = new WebClient();
            string contentString = _client.DownloadString(url);

            _client.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            _client.DownloadFileAsync(new Uri(url), @"C:\Users\C136077\Desktop\Spielwiese\WoWAddonDownloads\addon.zip");
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            _client = null;
            if (e.Error != null)
                Console.WriteLine($"Error: {e.Error}");
            else
                Console.WriteLine("Download completed!");
        }
    }
}
