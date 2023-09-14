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
    public partial class Signin : Form
    {
        public Signin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Signup signup = new Signup();
            signup.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                string role = null;

                using(UsersModel db = new UsersModel())
                {
                    var users = db.Users.FirstOrDefault(item => item.Login.Equals(textBox1.Text) && item.Password.Equals(textBox2.Text));

                    if (users != null)
                    {
                        role = Convert.ToString(users.Role);

                        switch (role)
                        {
                            case "1":
                                {
                                    AddAgent addAgent = new AddAgent();
                                    addAgent.Show();
                                    this.Hide();
                                    break;
                                }
                            case  "2":
                                {
                                    Main main = new Main(role);
                                    main.Show();
                                    this.Hide();
                                    break;
                                }
                            default:
                                {
                                    MessageBox.Show("Что-то пошло не так!");
                                    break;
                                }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль");
                    }
                }           
            }
            else MessageBox.Show("Пустые поля");
        }
    }
}
