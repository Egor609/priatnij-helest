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
    public partial class AddAgent : Form
    {
        public AddAgent()
        {
            InitializeComponent();
        }

        private void AddAgent_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main main = new Main(null);
            main.Show();
            this.Close();
        }

        private void agentBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.agentBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.priatnijShelestDataSet);

            MessageBox.Show("Данные успешно сохранены");
        }

        private void AddAgent_Load_1(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "priatnijShelestDataSet.AgentPriorityHistory". При необходимости она может быть перемещена или удалена.
            this.agentPriorityHistoryTableAdapter.Fill(this.priatnijShelestDataSet.AgentPriorityHistory);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "priatnijShelestDataSet.Agent". При необходимости она может быть перемещена или удалена.
            this.agentTableAdapter.Fill(this.priatnijShelestDataSet.Agent);

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Нажмите кнопку \"Сохранить\", если уверены что хотите удалить");
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            this.agentTableAdapter.Update(this.priatnijShelestDataSet);
        }

        private void titleLabel1_Click(object sender, EventArgs e)
        {

        }

        private void titleTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("После ввода данных, не забудьте нажать кнопку \"Сохранить\"");
        }
    }
}
