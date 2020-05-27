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
    public partial class Form1 : Form
    {
        WordsList list = new WordsList();
        List<Button> btns = new List<Button>();
        List<Button> keyboard = new List<Button>();
        List<Button> Players = new List<Button>();

        Key key = new Key();

        Form dlg = new Settings();


        PropertiesBalda prop = new PropertiesBalda();

        bool f = false;
        bool a = true;

        bool checker = false;

        public Form1()
        {
            InitializeComponent();
        }

        public void Generate_App(List<Button> btns, string startWord)
        {
            this.Size = new Size(995, 610);
            
            int size = 400;

            int CollBtns = 5;

            int Size_btn = size / CollBtns - 1;

            int pos = size / CollBtns;

            for (int i = 0; i < CollBtns; i++)
            {
                for (int j = 0; j < CollBtns; j++)
                {
                    if (j == 2)
                    {
                        Button btn = new Button();

                        string color = prop.ColorPlit;

                        btn.BackColor = Color.FromName(color);
                        btn.Text = Convert.ToString(startWord[i]);
                        btn.Size = new Size(Size_btn, Size_btn);
                        btn.Location = new Point(i * pos, j * pos);

                        panel1.Controls.Add(btn);
                        btns.Add(btn);
                    }
                    else
                    {
                        Button btn = new Button();

                        string color = prop.ColorPlit;

                        btn.BackColor = Color.FromName(color);
                        btn.Text = "";
                        btn.Size = new Size(Size_btn, Size_btn);
                        btn.Location = new Point(i * pos, j * pos);

                        btn.Click += new System.EventHandler(this.Btns_Clicks);

                        panel1.Controls.Add(btn);
                        btns.Add(btn);
                    }
                }
            }

            label1.Text = prop.NickName1;

            label3.Text = prop.NickName2;

            label2.Text = label4.Text = "0";

            Button btn1 = new Button();

            btn1.Text = "Зафиксировать букву: ";
            btn1.Location = new Point(430, 522);

            btn1.Click += new System.EventHandler(this.Save_btn);

            this.Controls.Add(btn1);
            Players.Add(btn1);
        }

        void Save_btn(object sender, EventArgs e)
        {
            if (checker)
            {
                f = true;
            }
        }

        public void Btns_Clicks(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            btn.Text = key.KeyName;

            checker = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            prop.LoadNick(textBox1);

            prop.SetColors();

            list.Input_All_Words();

            list.Generate_Start_word();

            string startWord = list.StarterWord;

            Generate_App(btns, startWord);

            this.Size = new Size(995, 610 + 340);

            Generate_Board();
        }

        private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            textBox1.Clear();
            textBox2.Clear();

            list.Generate_Start_word();

            string startWord = list.StarterWord;

            Generate_App(btns, startWord);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        public void Generate_Board()
        {
            int btn_height = 300 / 3 - 1;
            int btn_weight = 990 / 11 - 1;

            string alphabet = "абвгдуёжзийклмнопрстуфхчшщьыъэюя";

            int num = 0;

            for (int i = 0; i < 11 ; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Button btn = new Button();

                    if (j == 2 && i == 10)
                    {
                        btn.Text = "";
                    }
                    else
                    {
                        btn.Text = Convert.ToString(alphabet[num]);
                    }
                    num++;

                    string color = prop.ColorKeyBoard;

                    btn.BackColor = Color.FromName(color);
                    btn.Size = new Size(btn_weight, btn_height);
                    btn.Location = new Point(i * (btn_weight + 1), j * (btn_height + 1) + 610);

                    btn.Click += new System.EventHandler(this.KeyBoard_Click);

                    this.Controls.Add(btn);
                    keyboard.Add(btn);
                }
            }
        }

        public void KeyBoard_Click(object sender, EventArgs e)
        {
            if (!f)
            {
                string text = sender.ToString();

                textBox1.Text += text + Environment.NewLine;

                key.KeyName = text.Substring(35, 1);
            }
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dlg.Show();
        }
    }
}
