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
        public string _nickName1;
        public string _nickName2;

        public string _colorPlit;

        public string _colorKeyBoard;

        public string NickName1
        {
            get => _nickName1;
            set => _nickName1 = value;
        }
        
        public string NickName2
        {
            get => _nickName2;
            set => _nickName2 = value;
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

            string nick = (string)fs.ReadLine();

            NickName1 = nick;

            nick = (string)fs.ReadLine();

            NickName2 = nick;
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

        public void Seve_Settings()
        {
            StreamWriter fd = new StreamWriter("../../Settings/NickName.txt", Encoding.GetEncoding(1251));


        }

    }
}
