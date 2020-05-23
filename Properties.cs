using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Balda
{
    internal class Properties
    {
        string NickName;

        string color;

        public Properties()
        {
            StreamReader fs = new StreamReader("../../Settings/NickName.txt", Encoding.GetEncoding(1251));


        }

    }
}
