using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Windows.Forms;

namespace Balda
{
    struct WordsPoint
    {
        string _word;
        int _length;

        public string word
        {
            get => _word;
            set => _word = value;
        }

        public int lenght
        {
            get => _length;
            set => _length = value;
        }

        public WordsPoint(string word, int length)
        {
            _word = word;
            _length = length;
        }
    }

    internal class WordsList
    {
        List<WordsPoint> list = new List<WordsPoint>();
        List<string> starterWords = new List<string>();

        public string StarterWord;

        public void Add(WordsPoint sr)
        {
            list.Add(sr);
        }

        public void Input_All_Words()
        {
            StreamReader fs = new StreamReader("../../Words/Words.txt", Encoding.GetEncoding(1251));

            string str;
            int lenght;

            while ((str = fs.ReadLine()) != null)
            {
                lenght = str.Length;

                if (lenght == 5)
                {
                    starterWords.Add(str);
                }

                WordsPoint sr = new WordsPoint(str, lenght);

                list.Add(sr);
            }
        }

        public void Show_All_Words(TextBox textBox)
        {
            for (int i = 0; i < list.Count; i++)
            {
                textBox.Text += list[i].word + Environment.NewLine;
            }
        }

        public void Generate_Start_word()
        {
            Random rnd = new Random();

            int num = rnd.Next(0, starterWords.Count);

            StarterWord = starterWords[num];
        }
    }
}
