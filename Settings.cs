using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Balda
{
    public partial class Settings : Form
    {
        PropertiesBalda prop = new PropertiesBalda();

        public Settings()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            prop.NickName1 = textBox1.Text;
            prop.NickName2 = textBox2.Text;
            //prop.ColorPlit =
            //prop.ColorKeyBoard =

            prop.Seve_Settings();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            textBox1.Text += prop.NickName1;
            textBox2.Text += prop.NickName2;
        }
    }
}
