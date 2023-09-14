using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PriatnijShelest.Forms
{
    public partial class Main : Form
    {
        public Main(string role)
        {
            InitializeComponent();

            if (role == "2")
            {
                button2.Visible = true;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // Вывод данных в comboBox1 из БД
            this.agentTypeTableAdapter.Fill(this.priatnijShelestDataSet.AgentType);

            getData(10, null);

            textBox1.Text = "Введите для поиска";
            comboBox2.Text = "Фильтрация";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Сортировка
            string selected = comboBox1.Text;

            if (selected == "Наименование (по возрастанию)")
            {
                getData(1, null);
            }
            else if (selected == "Размер скидки (по возрастанию)")
            {
                getData(2, null);
            }
            else if (selected == "Приоритет агента (по возрастанию)")
            {
                getData(3, null);
            }
            else if (selected == "Наименование (по убыванию)")
            {
                getData(4, null);
            }
            else if (selected == "Размер скидки (по убыванию)")
            {
                getData(5, null);
            }
            else if (selected == "Приоритет агента (по убыванию)")
            {
                getData(6, null);
            }      
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Берём значение для фильтрации
            string search = comboBox2.Text;

            if (comboBox2.Text == "Все типы")
            {
                getData(10, null);
            }
            else
            {
                getData(50, search);
                comboBox2.Text = "Все типы";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "Введите для поиска" && textBox1.Text != "")
            {
                // Берём значение для поиска
                string search = textBox1.Text;
                getData(50, search);
            }
            else if (textBox1.Text == "")
            {
                getData(10, null);
            }
        }

        // Функция вывод информации
        private void getData(int selected, string search)
        {
            // Переменная типа int для изменения позиции по оси Y
            int plusY = 0;

            // Создаём объект db БД
            using (PriatnijShelestDbModel db = new PriatnijShelestDbModel())
            {
                // Создаём объект agent таблицы и сортируем по столбцу Title
                var agent = db.Agent.OrderBy(item => item.ID);
                var productSale = db.ProductSale.OrderBy(it => it.ID);

                if (selected == 1)
                {
                    agent = db.Agent.OrderBy(item => item.Title);
                    flowLayoutPanel1.Controls.Clear();
                }
                else if (selected == 2)
                {
                    agent = db.Agent.OrderBy(item => item.ID);
                    flowLayoutPanel1.Controls.Clear();
                }
                else if (selected == 3)
                {
                    agent = db.Agent.OrderBy(item => item.Priority);
                    flowLayoutPanel1.Controls.Clear();
                }
                else if (selected == 4)
                {
                    agent = db.Agent.OrderByDescending(item => item.Title);
                    flowLayoutPanel1.Controls.Clear();
                }
                else if (selected == 5)
                {
                    agent = db.Agent.OrderByDescending(item => item.ID);
                    flowLayoutPanel1.Controls.Clear();
                }
                else if (selected == 6)
                {
                    agent = db.Agent.OrderByDescending(item => item.Priority);
                    flowLayoutPanel1.Controls.Clear();
                }
                else if (selected == 50)
                {
                    flowLayoutPanel1.Controls.Clear();
                }

                // Проходится по элементам таблцы agent
                foreach (var item in agent)
                {
                    // Создаём объект компонента GroupBox
                    GroupBox groupBox = new GroupBox();
                    groupBox.Size = new Size(755, 125);
                    groupBox.Text = "";
                    groupBox.Location = new Point(23, plusY);

                    // Фильтрация и поиск
                    if (selected == 50 && item.AgentType.Title == search || item.Email == search || item.Phone == search)
                    {
                        groupBox.Visible = true;
                    }
                    else if (selected != 1 && selected != 2 && selected != 3 && selected != 4 && selected != 5 && selected != 6 && selected != 10)
                    {
                        groupBox.Visible = false;
                    }

                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Size = new Size(110, 110);
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.Image = Image.FromFile("D:/Егор/Демо экзамен/PriatnijShelest/Resources" + item.Logo);
                    pictureBox.Location = new Point(1, 13);

                    // Создаём объект компонента Label
                    Label typeAgent = new Label();
                    // Прописываем размер блока
                    typeAgent.Size = new Size(70, 20);
                    // Запесываем в label данные из таблицы; imet.Таблица_с_которой_есть_связь.Поле
                    typeAgent.Text = item.AgentType.Title + " |";
                    // Задаём локацию компонета
                    typeAgent.Location = new Point(125, 25);

                    // Создаём объект наименование агента
                    Label nameAgent = new Label();
                    nameAgent.Size = new Size(250, 20);
                    nameAgent.Text = item.Title;
                    nameAgent.Location = new Point(190, 25);

                    // Создаём объект продажи за год
                    Label sale = new Label();
                    sale.Size = new Size(250, 20);
                    sale.Text = item.INN;
                    sale.Location = new Point(125, 50);

                    // Создаём объект номер телефона
                    Label phone = new Label();
                    phone.Size = new Size(250, 20);
                    phone.Text = item.Phone;
                    phone.Location = new Point(125, 70);

                    // Создаём объект приоритет
                    Label priority = new Label();
                    priority.Size = new Size(250, 20);
                    priority.Text = "Приоритетность: " + Convert.ToString(item.Priority);
                    priority.Location = new Point(125, 90);

                    // Создаём объект скидка
                    Label skidka = new Label();
                    skidka.Size = new Size(70, 40);
                    skidka.Font = new Font("Monotype Corsiva", 20);
                    skidka.Text = Convert.ToString(item.Priority) + "%";
                    skidka.Location = new Point(675, 35);

                    // Добавляем компонеты на форму
                    groupBox.Controls.Add(pictureBox);
                    groupBox.Controls.Add(typeAgent);
                    groupBox.Controls.Add(nameAgent);
                    groupBox.Controls.Add(sale);
                    groupBox.Controls.Add(phone);
                    groupBox.Controls.Add(priority);
                    groupBox.Controls.Add(skidka);
                    flowLayoutPanel1.Controls.Add(groupBox);

                    // Изменяем позицию label
                    plusY += 120;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddAgent addAgent = new AddAgent();
            addAgent.Show();
            this.Hide();
        }

        private void textBox1_MouseUp(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Signin signin = new Signin();
            signin.Show();
            this.Hide();
        }
    }
}
