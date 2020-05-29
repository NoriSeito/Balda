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

        private void Settings_Load(object sender, EventArgs e)
        {
            prop.LoadNick(textBox1);

            textBox1.Text = (string)prop.NickName1;
            textBox2.Text = (string)prop.NickName2;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            prop.NickName1 = textBox1.Text;
            prop.NickName2 = textBox2.Text;
            //prop.ColorPlit =
            //prop.ColorKeyBoard =

            prop.Seve_Settings();

            this.Close();
        }
    }
}
