using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form_Snake : Form
    {
        Rectangle border = new Rectangle(50, 50, 500, 500);
        MySnake gameSnake = new MySnake();
        PictureBox Food = new PictureBox();
        LogicMap gameMap = new LogicMap();
        int factorScore = 100;
        long Score = 0;
        int nextX = 0;
        int nextY = 0;
        int pictureSize = 50;
        Keys CurrentMove = Keys.Space;

        public Form_Snake()
        {
            InitializeComponent();
            Food.BackColor = Color.Yellow;
            Food.Location = new Point(300, 300);
            Food.Size = new Size(pictureSize, pictureSize);
            Controls.Add(gameSnake.tail[0]);
            Controls.Add(Food);
            timer.Interval = 1000;
            timer.Enabled = false;
            KeyDown += new KeyEventHandler(Control);
        }

        public class MySnake
        {
            public PictureBox[] tail;
            public int size;

            public MySnake()
            {
                tail = new PictureBox[100];
                tail[0] = new PictureBox();
                tail[0].BackColor = Color.Green;
                tail[0].Location = new Point(250, 250);
                tail[0].Size = new Size(50, 50);
                for (int i = 1; i < 100; i++)
                    tail[i] = new PictureBox();
                size = 1;
            }
        }

        public class LogicMap //Примечание: 0 - пусто, 1 - змейка, 2 - еда
        {
            public int[,] map;
            
            public LogicMap()
            {
                map = new int[10, 10];
                for (int x = 0; x < 10; x++)
                    for (int y = 0; y < 10; y++)
                        map[x, y] = 0;
                map[4, 4] = 1;
                map[5, 5] = 2;
            }
        }

        private int LogicConv (int point) //Примечание: Преобразует координату в точку на логической карте
        {
            return point / pictureSize - 1;
        }

        private int LogicConvInv (int point) //Примечание: Преобразует точку на логической карте в координату
        {
            return (point + 1) * pictureSize;
        }

        private void timer_tick(object sender, EventArgs e)
        {
            Activate();
            SneakMove();
            EatFood();
        }

        private void SneakMove()
        {
            gameMap.map[LogicConv(gameSnake.tail[gameSnake.size - 1].Location.X), LogicConv(gameSnake.tail[gameSnake.size - 1].Location.Y)] = 0;
            for (int i = gameSnake.size - 1; i > 0; i--)
            {
                gameSnake.tail[i].Location = gameSnake.tail[i - 1].Location;
            }
            gameSnake.tail[0].Location = new Point(gameSnake.tail[0].Location.X + nextX * 50, gameSnake.tail[0].Location.Y + nextY * 50);
            if (CheckBorder())
            {
                if (gameMap.map[LogicConv(gameSnake.tail[0].Location.X), LogicConv(gameSnake.tail[0].Location.Y)] != 1)
                    gameMap.map[LogicConv(gameSnake.tail[0].Location.X), LogicConv(gameSnake.tail[0].Location.Y)] = 1;
                else
                {
                    timer.Enabled = false;
                    MessageBox.Show("Вы укусили самого себя!\nВы набрали " + Score + " очков!", "Игра окончена", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    Score = 0;
                    Score_TextBox.Text = "0";
                }
            }
        }

        private bool CheckBorder()
        {
            if (gameSnake.tail[0].Location.X < 50 || gameSnake.tail[0].Location.X > 500 || gameSnake.tail[0].Location.Y < 50 || gameSnake.tail[0].Location.Y > 500)
            {
                timer.Enabled = false;
                MessageBox.Show("Вы вышли из своей зоны обитания!\nВы набрали " + Score + " очков!", "Игра окончена", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                Score = 0;
                Score_TextBox.Text = "0";
                return false;
            }
            return true;
        }

        private void EatFood()
        {
            if (gameSnake.tail[0].Location == Food.Location)
            {
                gameSnake.tail[gameSnake.size] = new PictureBox();
                gameSnake.tail[gameSnake.size].Size = new Size(pictureSize, pictureSize);
                gameSnake.tail[gameSnake.size].Location = gameSnake.tail[gameSnake.size - 1].Location;
                gameSnake.tail[gameSnake.size].BackColor = Color.Orange;
                Controls.Add(gameSnake.tail[gameSnake.size]);
                gameSnake.size++;
                Score += factorScore;
                Score_TextBox.Text = Convert.ToString(Score);
                if (gameSnake.size < 100)
                    RestoreFood();
                else
                {
                    timer.Enabled = false;
                    MessageBox.Show("Вам больше некуда расти!\nВы набрали " + Score + " очков!", "Игра окончена", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    Score = 0;
                    Score_TextBox.Text = "0";
                }
            }
        }

        private void RestoreFood()
        {
            Random rnd = new Random();
            bool foodAdd = false;
            int tryCount = 0;
            int x;
            int y;
            while (!foodAdd || tryCount > 5)
            {
                x = rnd.Next(0, 9);
                y = rnd.Next(0, 9);
                if (gameMap.map[x,y] != 1)
                {
                    Food.Location = new Point(LogicConvInv(x), LogicConvInv(y));
                    gameMap.map[x, y] = 2;
                    foodAdd = true;
                }
                tryCount++;
            }

            if (!foodAdd)
            {
                switch(rnd.Next(0,1))
                {
                    case 0:
                        for (x = 0; x < 10; x++)
                        {
                            for (y = 0; y < 10; y++)
                            {
                                if (gameMap.map[x,y] != 1)
                                {
                                    Food.Location = new Point(LogicConvInv(x), LogicConvInv(y));
                                    gameMap.map[x, y] = 2;
                                    foodAdd = true;
                                    break;
                                }
                            }
                            if (foodAdd)
                                break;
                        }
                        break;
                    case 1:
                        for (x = 9; x >= 0; x--)
                        {
                            for (y = 0; y < 10; y++)
                            {
                                if (gameMap.map[x, y] != 1)
                                {
                                    Food.Location = new Point(LogicConvInv(x), LogicConvInv(y));
                                    gameMap.map[x, y] = 2;
                                    foodAdd = true;
                                    break;
                                }
                            }
                            if (foodAdd)
                                break;
                        }
                        break;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Pen blackPen = new Pen(Color.Black, 1);
            e.Graphics.DrawRectangle(blackPen, border);
        }

        private void Control(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Up:
                    if (CurrentMove != Keys.Up)
                    {
                        nextX = 0;
                        nextY = -1;
                        CurrentMove = Keys.Up;
                    }
                    break;
                case Keys.Down:
                    if (CurrentMove != Keys.Up)
                    {
                        nextX = 0;
                        nextY = 1;
                        CurrentMove = Keys.Down;
                    }
                    break;
                case Keys.Left:
                    if (CurrentMove != Keys.Right)
                    {
                        nextX = -1;
                        nextY = 0;
                        CurrentMove = Keys.Left;
                    }
                    break;
                case Keys.Right:
                    if (CurrentMove != Keys.Left)
                    {
                        nextX = 1;
                        nextY = 0;
                        CurrentMove = Keys.Right;
                    }
                    break;
                default:
                    break;
            }
        }

        private void Complexity_ValueChanged(object sender, EventArgs e)
        {
            timer.Interval = 1100 - Complexity.Value;
            factorScore = Complexity.Value;
        }

        private void Start_button_Click(object sender, EventArgs e)
        {
            nextX = 0;
            nextY = 0;
            gameMap = new LogicMap();
            Food.Location = new Point(300, 300);
            gameSnake.size = 1;
            gameSnake.tail[0].Location = new Point(250, 250);
            for (int i = 1; i < 100; i++)
                gameSnake.tail[i].Location = new Point(1000, 1000);
            Complexity.Enabled = false;
            CurrentMove = Keys.Space;
            this.ActiveControl = null;
            timer.Enabled = true;
            Stop_button.Enabled = true;
            Start_button.Enabled = false;
        }

        private void Stop_button_Click(object sender, EventArgs e)
        {
            Score = 0;
            Score_TextBox.Text = "0";
            timer.Enabled = false;
            Complexity.Enabled = true;
            Start_button.Enabled = true;
            Stop_button.Enabled = false;
        }
    }
}
