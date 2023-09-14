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
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void Signup_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Signin signin = new Signin();
            signin.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        if (textBox1.Text != "" && textBox2.Text != "")
        {
            if (textBox1.Text.Length >= 4 && textBox2.Text.Length >= 4)
            {
                using (UsersModel db = new UsersModel())
                {
                    Users users = new Users();
                    users.Login = textBox1.Text;
                    users.Password = textBox2.Text;
                    users.Role = 2;

                    db.Users.Add(users);
                    db.SaveChanges();

                    Main main = new Main("2");
                    main.Show();
                    this.Hide();
                }
            }
            else MessageBox.Show("Логин и пароль должны быть неменее 4 символов");
        }
        else MessageBox.Show("Пустые поля");    
        }
    }
}
