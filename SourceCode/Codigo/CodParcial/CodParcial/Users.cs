using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CodParcial
{
    public partial class Users : UserControl
    {
        public Users()
        {
            InitializeComponent();
            actualizarControles();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text.Length >= 5 )
                {
                    UsuarioDAO1.crearNuevo(textBox2.Text, textBox1.Text);
                    
                    MessageBox.Show("¡Usuario agregado exitosamente! Valores por defecto: " +
                                    "contrasena igual a usuario, no admin y si activo.", 
                        "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    textBox1.Clear();
                    textBox2.Clear();
                    actualizarControles();
                }
                else
                {
                    MessageBox.Show("Favor digite un usuario (longitud minima, 5 caracteres)", 
                        "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("El usuario que ha digitado, no se encuentra disponible.", 
                    "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void actualizarControles()
        {
            List<Usuario> lista = UsuarioDAO1.getLista();
            
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista;
            
        }
    }
}