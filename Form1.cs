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

        Button btn2 = new Button();
        Button btn1 = new Button();

        WordSelected wrd = new WordSelected();

        Key key = new Key();

        Form dlg = (Settings)Application.OpenForms["Settings"];


        PropertiesBalda prop = new PropertiesBalda();

        bool f = false;//тип ввода

        bool a = true;//игрок

        bool checker = false;

        int Score1 = 0;

        int Score2 = 0;


        public Form1()
        {
            InitializeComponent();
        }

        public void Generate_App(List<Button> btns, string startWord)
        {
            this.Size = new Size(995, 610 + 340);

            f = false;//тип ввода
            
            a = true;//игрок

            checker = false;

            Score1 = 0;

            Score2 = 0;

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
                        btn.Click += new System.EventHandler(this.Btns_Clicks);

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

            if (a)
            {
                label5.Text = "Ход игрока " + prop.NickName1;
            }
            else
            {
                label5.Text = "Ход игрока " + prop.NickName2;
            }

            label1.Text = (string)prop.NickName1;

            label3.Text = (string)prop.NickName2;

            label2.Text = Convert.ToString(Score1);

            label4.Text = Convert.ToString(Score2);


            btn1.Text = "Зафиксировать букву: ";
            btn1.Location = new Point(430, 522);

            btn1.Click += new System.EventHandler(this.Save_btn);

            this.Controls.Add(btn1);
            Players.Add(btn1);

            

            btn2.Text = "закончить ход";
            btn2.Location = new Point(430, 522);
            btn2.Click += new System.EventHandler(this.next_Player);

            Players.Add(btn2);

            Generate_Board();

        }

        void Save_btn(object sender, EventArgs e)
        {
            if (checker)
            {
                f = true;
                this.Controls.Remove(btn1);
                this.Controls.Add(btn2);
            }
            else
            {
                this.Controls.Remove(btn2);
                this.Controls.Add(btn1);
            }
        }

        void next_Player(object sender, EventArgs e)
        {
            bool set_word = false;

            set_word = list.Search_Word(wrd.Word);

            string name = wrd.Word;

            if (set_word)
            {
                int length = name.Length;

                if (a)
                {
                    Score1 += length;
                    textBox1.Text += name + " : " + length + Environment.NewLine;
                    label2.Text = Convert.ToString(Score1);
                }
                else
                {
                    Score2 += length;
                    textBox2.Text += name + " : " + length + Environment.NewLine;
                    label4.Text = Convert.ToString(Score2);
                }
            }

            a = !a;

            if (a)
            {
                label5.Text = "Ход игрока " + prop.NickName1;
            }
            else
            {
                label5.Text = "Ход игрока " + prop.NickName2;
            }

            f = false;
            this.Controls.Remove(btn2);
            this.Controls.Add(btn1);
        }

        public void Btns_Clicks(object sender, EventArgs e)
        {
            if(!f)
            {
                Button btn = (Button)sender;

                if (btn.Text == "") btn.Text = key.KeyName;

                checker = true;
            }
            else
            {
                Button btn = (Button)sender;

                wrd.Word += btn.Text;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            prop.LoadNick(textBox1);

            prop.SetColors();

            list.Input_All_Words();

            list.Generate_Start_word();

            string startWord = list.StarterWord;

            Generate_App(btns, startWord);
        }

        private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            prop.LoadNick(textBox1);

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

                key.KeyName = text.Substring(35, 1);
            }
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dlg == null) // Если форма не существует, то создаём
            {
                Settings form2 = new Settings(); // Создание нового экземпляра формы
                form2.Show(); // Отображаем форму
            }
            else
                dlg.Activate(); // Активируем форму на передний план (из трея или заднего плана)
        }
    }
}
