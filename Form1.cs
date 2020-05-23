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

                        btn.Text = Convert.ToString(startWord[i]);
                        btn.Size = new Size(Size_btn, Size_btn);
                        btn.Location = new Point(i * pos, j * pos);

                        panel1.Controls.Add(btn);
                        btns.Add(btn);
                    }
                    else
                    {
                        Button btn = new Button();

                        btn.Text = "";
                        btn.Size = new Size(Size_btn, Size_btn);
                        btn.Location = new Point(i * pos, j * pos);

                        btn.Click += new System.EventHandler(this.Bnts_Clicks);

                        panel1.Controls.Add(btn);
                        btns.Add(btn);
                    }
                }
            }

            label1.Text = "Игрок 1";

            label3.Text = "Игрок 2";

            label2.Text = label4.Text = "0";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            list.Input_All_Words();

            list.Generate_Start_word();

            string startWord = list.StarterWord;

            Generate_App(btns, startWord);
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

        List<Button> keyboard = new List<Button>();

        private void Bnts_Clicks(object sender, EventArgs e)
        {
            this.Size = new Size(995, 610 + 340);

            Generate_Board();
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
            
        }
    }
}
