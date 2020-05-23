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

        public string _color;

        public string NickName
        {
            get => _nickName;
            set => _nickName = value;
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

            string nick = "";

            for (int i = num + 1; i < line.Length; i++)
            {
                nick.Insert(nick.Length + 1 , Convert.ToString(line[i]));
            }

            NickName = nick;
        }

    }
}
