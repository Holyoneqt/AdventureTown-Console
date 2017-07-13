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
    public class CharacterCounter
    {
        private Dictionary<char, int> _charCounter;
        private int _totalCharacters = 0;

        public CharacterCounter()
        {
            _charCounter = new Dictionary<char, int>();
        }

        [Command("url")]
        public Dictionary<char, int> CountCharatersFromUrl(string url)
        {
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            return CountChars(client.DownloadString(url));
        }

        [Command("file")]
        public Dictionary<char, int> CountCharactersFromFile(string path)
        {
            return CountChars(File.ReadAllText(path));
        }

        [Command("text")]
        public Dictionary<char, int> CountChars(string text)
        {
            return CountChars(text, true);
        }

        public Dictionary<char, int> CountChars(string text, bool print)
        {
            char[] chars = text.ToCharArray();
            foreach (char c in chars)
            {
                _totalCharacters++;
                if (_charCounter.ContainsKey(c))
                {
                    _charCounter[c]++;
                }
                else
                {
                    _charCounter.Add(c, 1);
                }
            }

            _charCounter = _charCounter.OrderByDescending(key => key.Value).ToDictionary(x => x.Key, x => x.Value);
            foreach (KeyValuePair<char, int> character in _charCounter)
            {
                int percent = (character.Value * 100) / _totalCharacters;
                if (percent >= 1 && print)
                    Console.WriteLine($"{character.Key}: {character.Value} - {percent}%");
            }

            return _charCounter;
        }

        [Command("cmp")]
        public void CompareFromUrl(string firstUrl, string secondUrl)
        {
            Dictionary<char, int> firstChars = CountCharatersFromUrl(firstUrl).Where(p => p.Value > 1000).ToDictionary(x => x.Key, x => x.Value);
            Dictionary<char, int> secondChars = CountCharatersFromUrl(secondUrl).Where(p => p.Value > 1000).ToDictionary(x => x.Key, x => x.Value);
            
            Console.WriteLine($"\t{firstUrl}\t\t{secondUrl}");
            foreach (var c in firstChars)
            {
                char current = c.Key;
                Console.WriteLine($"{current}:\t{c.Value}\t\t{secondChars[current]}");
            }
        }
    }
}