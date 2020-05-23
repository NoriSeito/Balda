using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

using System.Windows.Forms;

namespace Balda
{
    internal class PropertiesBalda
    {
        public string _nickName;

        public string _colorPlit;

        public string _colorKeyBoard;

        public string NickName
        {
            get => _nickName;
            set => _nickName = value;
        }

        public string ColorPlit
        {
            get => _colorPlit;
            set => _colorPlit = value;
        }

        public string ColorKeyBoard
        {
            get => _colorKeyBoard;
            set => _colorKeyBoard = value;
        }

        public void LoadNick(TextBox txt)
        {
            StreamReader fs = new StreamReader("../../Settings/NickName.txt", Encoding.GetEncoding(1251));

            string line = (string)fs.ReadLine();

            int num = 0;

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == ':' && line[i + 1] == ' ')
                {
                    num = i + 1;
                    return;
                }
            }

            string nick = line.Remove(0, 10);

            txt.Text += nick + Environment.NewLine;

            NickName = nick;
        }

        public void SetColors()
        {
            StreamReader fs = new StreamReader("../../Settings/Style.txt", Encoding.GetEncoding(1251));

            string colorPlit = "";
            string colorKeyBoard = "";

            for (int i = 0; i < 2; i++)
            {
                switch (i)
                {
                    case 0:
                        colorPlit = fs.ReadLine();
                        break;
                    case 1:
                        colorKeyBoard = fs.ReadLine();
                        break;
                }
            }

            ColorPlit = colorPlit;
            ColorKeyBoard = colorKeyBoard;
        }

    }
}
