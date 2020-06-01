
using System;
using System.Windows.Forms;

namespace CodParcial
{
  public partial class Form1 : Form
  {
    private UserControl current = null;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            poblarControles();
        }
        
        private void poblarControles()
        {
            // Actualizar ComboBox
            cmbUsuario.DataSource = null;
            cmbUsuario.ValueMember = "userType";
            cmbUsuario.ValueMember = "password";
            cmbUsuario.DisplayMember = "username";
            cmbUsuario.DataSource = UsuarioDAO1.getLista();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cmbUsuario.SelectedValue.Equals(textBox2.Text))
            {
                Usuario u = (Usuario) cmbUsuario.SelectedItem;

                if (u.userType.Equals(true))
                {
                    tableLayoutPanel1.Controls.Remove(current);
                    current = new Administrator();
                    tableLayoutPanel1.Controls.Add(current, 0, 0);
                    tableLayoutPanel1.SetColumnSpan(current, 3);
                    tableLayoutPanel1.SetRowSpan(current, 10);
                }
                else if (u.userType.Equals(false))
                {
                    tableLayoutPanel1.Controls.Remove(current);
                    current = new NormalUser();
                    tableLayoutPanel1.Controls.Add(current, 0, 0);
                    tableLayoutPanel1.SetColumnSpan(current, 3);
                    tableLayoutPanel1.SetRowSpan(current, 10);
                }
            }
            else
                {

                    MessageBox.Show("¡Contraseña incorrecta!", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            

        }
        
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) button2_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
