using System;
using System.Windows.Forms;

namespace CodigoParcial
{
    public partial class Address : UserControl
    {
        public Address()
        {
            InitializeComponent();
            
            var dt = ConnectionDB.ExecuteQuery($"SELECT * FROM ADDRESS");

            dataGridView1.DataSource = dt;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Equals(""))
            {
                MessageBox.Show("No se pueden dejar espacios vacios");
            }
            else
            {
                try
                {
                    ConnectionDB.ExecuteNonQuery($"INSERT INTO ADDRESS(idUser, address) VALUES ('{textBox1.Text}')");
                    MessageBox.Show("Se ha registrado la dirección");
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Ha ocurrido un error");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Equals(""))
            {
                MessageBox.Show("No se pueden dejar espacios vacios");
            }
            else
            {
                try
                {
                    int id = Convert.ToInt32(textBox2);

                    ConnectionDB.ExecuteNonQuery($"DELETE FROM ADDRESS WHERE idAddress = ({id})");
                    MessageBox.Show("Se ha eliminado la dirección");
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Ha ocurrido un error");
                }
            }
        }
    }
}