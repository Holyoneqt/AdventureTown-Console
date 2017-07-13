using Spielwiese.Util.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Spielwiese.Functions.Counter
{
    public class WordCounter
    {
        private Dictionary<string, int> wordCounter;

        public WordCounter()
        {
            wordCounter = new Dictionary<string, int>();
        }

        [Command("url")]
        public void CountFromUrl(string url)
        {
            WebClient client = new WebClient();
            CountWords(client.DownloadString(url));
        }

        [Command("file")]
        public void CountWordsFromFile(string path)
        {
            CountWords(File.ReadAllText(path));
        }

        [Command("text")]
        public void CountWords(string text)
        {
            string[] words = text.Split(' ');
            foreach (string word in words)
            {
                if (wordCounter.ContainsKey(word.ToLower()))
                {
                    wordCounter[word.ToLower()]++;
                }
                else
                {
                    wordCounter.Add(word.ToLower(), 1);
                }
            }

            wordCounter = wordCounter.OrderByDescending(key => key.Value).ToDictionary(x => x.Key, x => x.Value);
            foreach (KeyValuePair<string, int> word in wordCounter)
            {
                Console.WriteLine($"{word.Key}: {word.Value}");
            }
        }
    }
}
