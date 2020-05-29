using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CodigoParcial
{
    public partial class Business : UserControl
    {
        public Business()
        {
            InitializeComponent();
            
        }

        private void Business_Load(object sender, EventArgs e)
        {
            var business = ConnectionDB.ExecuteQuery($"SELECT name FROM BUSINESS");
            
            var businessCombo = new List<string>();

            foreach (DataRow dr in business.Rows)
            {
                businessCombo.Add(dr[0].ToString());
            }

            comboBox1.DataSource =businessCombo;
        }
        
        private void Products_Load(object sender, EventArgs e)
        {
            var idBusines = ConnectionDB.ExecuteQuery($"SELECT idBusiness FROM BUSINESS WHERE name = '{businessComboBox.SelectedItem.ToString()}'");
            var product = ConnectionDB.ExecuteQuery($"SELECT idProduct, name FROM PRODUCT WHERE idBusiness = '{idBusines}'");
            var productCombo = new List<string>();

            foreach (DataRow dr in product.Rows)
            {
                productCombo.Add(dr[0].ToString());
            }

            comboBox1.DataSource =productCombo;
        }
        
        private void OrderButton_Click(object sender, EventArgs e)
        {
            try
                {
                    var idProduct = ConnectionDB.ExecuteQuery($"SELECT idProduct FROM PRODUCT WHERE name = '{comboBox1.SelectedItem.ToString()}'");
                    string query = $"SELECT idMateria FROM materia WHERE nombre = '{comboBox1.SelectedItem.ToString()}'";
                    //COLOCAR ID USER
                    var idAddress = ConnectionDB.ExecuteQuery($"SELECT idAddress FROM ADDRESS WHERE name = '{comboBox1.SelectedItem.ToString()}'");

                    var dt = ConnectionDB.ExecuteQuery(query);
                    var dr = dt.Rows[0];
                    var idMateria = Convert.ToInt32(dr[0].ToString());
                    
                    string nonQuery = $"INSERT INTO APPORDER(createDate, idProduct, idAddress) VALUES(" + 
                                      $"{DateTime.Now},"+
                                      $"'{idProduct}'"+
                                      $"'{idAddress}')";
                    
                    ConnectionDB.ExecuteNonQuery(nonQuery);

                    MessageBox.Show("Orden realizada con exito!");
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Ha ocurrido un error");

                }
        }
    }
}