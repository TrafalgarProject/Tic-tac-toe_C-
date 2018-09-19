using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crosses_null
{
    public partial class Game3x3 : Form
    {
        int num_game; //Номер игры
        int drawgame = 0;
        int Ovin = 0; //Кол-во побед О
        int Xvin = 0; //Кол-во побед Х
        int[,] PointArea; //массив полей Х и О
        bool next = true;
        string TextBtnXod1;
        string TextBtnXod2;
        string Text_Btn;
        string X_Xod="X";
        string O_Xod="O";
        bool nextstart = true;

        public void ClickButton(Button button)
        {
            if (Text_Btn == X_Xod)
            {
                TextBtnXod1 = "X";
                TextBtnXod2 = "O";
            }

            if (Text_Btn == O_Xod)
            {

                TextBtnXod1 = "O";
                TextBtnXod2 = "X";
            }

            if (nextstart==true)
            {
                button.Enabled = true;
                refresh();
                ClearStats();
            }
            else
            {
                if (next)
                {
                    button.Text = TextBtnXod1;
                    button.Enabled = false;
                    next = false;
                }
                else
                {
                    button.Text = TextBtnXod2;
                    button.Enabled = false;
                    next = true;
                }
            }

        }
        public Game3x3()
        {
            InitializeComponent();
            PointArea = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };// массив 3 на 3 заполненный 0
            refresh();// чистим поле перед игрой
        }
        public void ClearStats() // статус игры
        {
            Ovin = 0;
            Xvin = 0;
            drawgame = 0;
            num_game = 0;

            label1.Text = num_game + " игра";
            label2.Text = "O : " + Ovin + " раз";
            label3.Text = "Количество ничьих побед : " + drawgame + " раз";
            label4.Text = "Х : " + Xvin + " раз";
        }

        public void refresh()
        {
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;

            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;

            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;

            // очистка кнопок и лейблов

            button4.Text = "";
            button4.Enabled = true;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;

            

            button5.Text = "";
            button5.Enabled = true;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;

            button6.Text = "";
            button6.Enabled = true;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;

            button7.Text = "";
            button7.Enabled = true; 
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatStyle = FlatStyle.Flat;

            button8.Text = "";
            button8.Enabled = true;
            button8.FlatAppearance.BorderSize = 0;
            button8.FlatStyle = FlatStyle.Flat;

            button9.Text = "";
            button9.Enabled = true;
            button9.FlatAppearance.BorderSize = 0;
            button9.FlatStyle = FlatStyle.Flat;

            button10.Text = "";
            button10.Enabled = true;
            button10.FlatAppearance.BorderSize = 0;
            button10.FlatStyle = FlatStyle.Flat;

            button11.Text = "";
            button11.Enabled = true;
            button11.FlatAppearance.BorderSize = 0;
            button11.FlatStyle = FlatStyle.Flat;

            button12.Text = "";
            button12.Enabled = true;
            button12.FlatAppearance.BorderSize = 0;
            button12.FlatStyle = FlatStyle.Flat;

            // очистка массива

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    PointArea[i, j] = 0;
                }
            }

            label1.Text = num_game + " игра";
            label2.Text = "O : " + Ovin + " раз";
            label3.Text = "Количество ничьих побед : " + drawgame + " раз";
            label4.Text = "Х : " + Xvin + " раз";
        }
        public bool CheckGame()
        {
            // проверка на ничью

            if (PointArea[0, 0] > 0 && PointArea[0, 1] > 0 && PointArea[0, 2] > 0 &&
                PointArea[1, 0] > 0 && PointArea[1, 1] > 0 && PointArea[1, 2] > 0 &&
                PointArea[2, 0] > 0 && PointArea[2, 1] > 0 && PointArea[2, 2] > 0)
            {

                MessageBox.Show("Пользователи завершили игру ничьей");
                drawgame += 1;
                num_game += 1;

                refresh();
                return false;
            }

            // проверка на выигрыша

            if (((PointArea[0, 0] == PointArea[0, 1] && PointArea[0, 1] == PointArea[0, 2])
                && (PointArea[0, 0] > 0
                && PointArea[0, 1] > 0
                && PointArea[0, 2] > 0))
               ||
               ((PointArea[1, 0] == PointArea[1, 1] && PointArea[1, 1] == PointArea[1, 2])
                && (PointArea[1, 0] > 0
                && PointArea[1, 1] > 0
                && PointArea[1, 2] > 0))
               ||
               ((PointArea[2, 0] == PointArea[2, 1] && PointArea[2, 1] == PointArea[2, 2])
                && (PointArea[2, 0] > 0
                && PointArea[2, 1] > 0
                && PointArea[2, 2] > 0))


               ||


               ((PointArea[0, 0] == PointArea[1, 0] && PointArea[1, 0] == PointArea[2, 0])
                && (PointArea[0, 0] > 0
                && PointArea[1, 0] > 0
                && PointArea[2, 0] > 0))
               ||
               ((PointArea[0, 1] == PointArea[1, 1] && PointArea[1, 1] == PointArea[2, 1])
                && (PointArea[0, 1] > 0
                && PointArea[1, 1] > 0
                && PointArea[2, 1] > 0))
               ||
               ((PointArea[0, 2] == PointArea[1, 2] && PointArea[1, 2] == PointArea[2, 2])
                && (PointArea[0, 2] > 0
                && PointArea[1, 2] > 0
                && PointArea[2, 2] > 0))


               ||


               ((PointArea[0, 0] == PointArea[1, 1] && PointArea[1, 1] == PointArea[2, 2])
                && (PointArea[0, 0] > 0
                && PointArea[1, 1] > 0
                && PointArea[2, 2] > 0))
               ||
               ((PointArea[0, 2] == PointArea[1, 1] && PointArea[1, 1] == PointArea[2, 0])
                && (PointArea[0, 2] > 0
                && PointArea[1, 1] > 0
                && PointArea[2, 0] > 0)))
            {
                if (Text_Btn == X_Xod)
                {
                    if (next)
                    {
                        MessageBox.Show("Выиграл пользователь играющий O");
                        Ovin += 1;
                    }
                    else
                    {
                        MessageBox.Show("Выиграл пользователь играющий X");
                        Xvin += 1;
                    }
                }
                else
                {
                    if (Text_Btn == O_Xod)
                    {
                        if (next)
                        {
                            MessageBox.Show("Выиграл пользователь играющий X");
                            Xvin += 1;
                        }
                        else
                        {
                            MessageBox.Show("Выиграл пользователь играющий O");
                            Ovin += 1;
                        }
                    }
                }
                num_game += 1;
                refresh();
            }

            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            nextstart = true;
            button1.Visible = false;
            button3.Visible = true;
            gBox.Visible = true;
            TextBtnXod1 = null;
            TextBtnXod2 = null;
            next = true;
            ClearStats();
            refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClickButton(button4);
            num_game = 0;
            if (next)
            {
                PointArea[0, 0] = 1;
            }
            else
            {
                PointArea[0, 0] = 2;
            }

            CheckGame();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            ClickButton(button5);
            num_game = 0;
            if (next)
            {
                PointArea[0, 1] = 1;
            }
            else
            {
                PointArea[0, 1] = 2;
            }

            CheckGame();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            ClickButton(button6);
            num_game = 0;
            if (next)
            {
                PointArea[0, 2] = 1;
            }
            else
            {
                PointArea[0, 2] = 2;
            }

            CheckGame();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            ClickButton(button7);
            num_game = 0;
            if (next)
            {
                PointArea[1, 0] = 1;
            }
            else
            {
                PointArea[1, 0] = 2;
            }

            CheckGame();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            ClickButton(button8);
            num_game = 0;
            if (next)
            {
                PointArea[1, 1] = 1;
            }
            else
            {
                PointArea[1, 1] = 2;
            }

            CheckGame();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            ClickButton(button9);
            num_game = 0;
            if (next)
            {
                PointArea[1, 2] = 1;
            }
            else
            {
                PointArea[1, 2] = 2;
            }
            
            CheckGame();
        }
        private void button10_Click(object sender, EventArgs e)
        {
            ClickButton(button10);
            num_game = 0;
            if (next)
            {
                PointArea[2, 0] = 1;
            }
            else
            {
                PointArea[2, 0] = 2;
            }

            CheckGame();
        }
        private void button11_Click(object sender, EventArgs e)
        {
            ClickButton(button11);
            num_game = 0;
            if (next)
            {
                PointArea[2, 1] = 1;
            }
            else
            {
                PointArea[2, 1] = 2;
            }

            CheckGame();
        }
        private void button12_Click(object sender, EventArgs e)
        {
            ClickButton(button12);
            num_game = 0;
            if (next)
            {
                PointArea[2, 2] = 1;
            }
            else
            {
                PointArea[2, 2] = 2;
            }

            CheckGame();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            refresh();
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            refresh();
            button3.Visible = false;
            button1.Visible = true;
            nextstart = false;
            gBox.Visible = false;
            if (rBtnX.Checked == true)
            {
                Text_Btn = X_Xod;
            }
            else
            {
                if (rBtnO.Checked == true)
                {
                    Text_Btn = O_Xod;
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics gPanel = panel2.CreateGraphics();
            Pen p = new Pen(Color.White, 1);
            Pen p1 = new Pen(Color.White, 2);
            gPanel.DrawLine(p, new Point(0, 0), new Point(191, 0));
            gPanel.DrawLine(p, new Point(191, 0), new Point(191, 191));
            gPanel.DrawLine(p, new Point(0, 0), new Point(0, 191));
            gPanel.DrawLine(p, new Point(0, 191), new Point(191, 191));
            gPanel.DrawLine(p1, new Point(64, 0), new Point(64, 191));
            gPanel.DrawLine(p1, new Point(128, 0), new Point(128, 191));
            gPanel.DrawLine(p1, new Point(0, 64), new Point(191, 64));
            gPanel.DrawLine(p1, new Point(0, 128), new Point(191, 128));
        }
    }
}
