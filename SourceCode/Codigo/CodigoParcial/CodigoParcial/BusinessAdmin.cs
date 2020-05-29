using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CodigoParcial
{
    public partial class BusinessAdmin : UserControl
    {
        public BusinessAdmin()
        {
            InitializeComponent();
            actualizarControles();
            
            comboBox1.DataSource = null;
            comboBox1.DisplayMember = "name";
            comboBox1.DataSource = getLista();
            
            
            comboBox2.DataSource = null;
            comboBox2.ValueMember = "idBusiness";
            comboBox2.DisplayMember = "name";
            comboBox2.DataSource = getLista();
            
            comboBox3.DisplayMember = "name";
            comboBox3.DataSource = getListaProductos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length >= 5 )
                {
                    crearNuevoNegocio(textBox1.Text, textBox2.Text);
                    
                    MessageBox.Show("¡Negocio agregado exitosamente!","", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    textBox1.Clear();
                    textBox2.Clear();
                    actualizarControles();
                }
                else
                {
                    MessageBox.Show("Favor digite un negocio (longitud minima, 5 caracteres)", 
                        "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Ha ocurrido un error", 
                    "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text.Length >= 3 )
                {
                    crearNuevoProducto(comboBox2.SelectedValue.ToString(), textBox3.Text);
                    
                    MessageBox.Show("¡Producto agregado exitosamente!","", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    textBox3.Clear();
                    actualizarControles();
                }
                else
                {
                    MessageBox.Show("Favor digite un producto (longitud minima, 3 caracteres)", 
                        "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Ha ocurrido un error.", 
                    "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea eliminar el negocio " + comboBox2.Text + "?", 
                  "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                eliminarNegocio(comboBox2.Text);
                
                MessageBox.Show("¡Negocio eliminado exitosamente!", 
                    "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
                actualizarControles();
            }
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea eliminar el producto " + comboBox3.Text + "?", 
                "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                eliminarProducto(comboBox3.Text);
                
                MessageBox.Show("¡Producto eliminado exitosamente!", 
                    "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
                actualizarControles();
            }
        }
        
        public static void crearNuevoNegocio(string nombre, string descripcion)
        {
            string sql = String.Format("INSERT INTO BUSINESS(name , description) VALUES( "+
                                       $"'{nombre}',"+
                                       $"'{descripcion}')");


            ConnectionDB.ExecuteNonQuery(sql);
        }
        
        public static void crearNuevoProducto(string idBusiness, string name)
        {
            string sql = String.Format("INSERT INTO PRODUCT(idBusiness , name) VALUES( "+
                                       $"'{idBusiness}',"+
                                       $"'{name}')");


            ConnectionDB.ExecuteNonQuery(sql);
        }
        
        private void actualizarControles()
        {
            List<Negocios> lista = getLista();
            
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista;
            
        }
        
        public static List<Negocios> getLista()
        {
            string sql = "SELECT * FROM BUSINESS";
            DataTable dt = ConnectionDB.ExecuteQuery(sql);
                    
            List<Negocios> lista = new List<Negocios>();
                    
            foreach(DataRow fila in dt.Rows)
            {
                Negocios u = new Negocios();

                u.idBusiness = fila[0].ToString();
                u.name = fila[1].ToString();
                u.description = fila[2].ToString();

                lista.Add(u);

            }

            return lista;
        }
        
        public static List<Productos> getListaProductos()
        {
            string sql = "SELECT * FROM PRODUCT";
            DataTable dt = ConnectionDB.ExecuteQuery(sql);
                    
            List<Productos> listaProduct = new List<Productos>();
                    
            foreach(DataRow fila in dt.Rows)
            {
                Productos u = new Productos();

                u.idProduct = fila[0].ToString();
                u.idBusiness = fila[1].ToString();
                u.name = fila[2].ToString();
                u.fk_product_business = fila[3].ToString();

                listaProduct.Add(u);

            }

            return listaProduct;
        }
        
        public static void eliminarNegocio(string negocio)
        {
            string sql = String.Format(
                "DELETE FROM BUSINESS WHERE name = '{0}'",negocio);
            
            ConnectionDB.ExecuteNonQuery(sql);
        }
        
        public static void eliminarProducto(string producto)
        {
            string sql = String.Format(
                "DELETE FROM PRODUCT WHERE name = '{0}'",producto);
            
            ConnectionDB.ExecuteNonQuery(sql);
        }
        
    }
}