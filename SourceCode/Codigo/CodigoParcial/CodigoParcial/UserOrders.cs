using System;
using System.Windows.Forms;

namespace CodigoParcial
{
    public partial class UserOrders : UserControl
    {
        public UserOrders()
        {
            InitializeComponent();
            
            var dt = ConnectionDB.ExecuteQuery($"SELECT ao.idOrder, ao.createDate, pr.name, au.fullname, ad.address "+
                                               $"FROM APPORDER ao, ADDRESS ad, PRODUCT pr, APPUSER au "+
                                               $"WHERE ao.idProduct = pr.idProduct AND ao.idAddress = ad.idAddress "+
                                               $"AND ad.idUser = au.idUser;");

            OrdersDataGridView.DataSource = dt;
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
                    int id = Convert.ToInt32(textBox1);

                    ConnectionDB.ExecuteNonQuery($"DELETE FROM APPORDER WHERE idOrder = ('{id}')");
                    MessageBox.Show("Se ha eliminadoo la orden");
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Ha ocurrido un error");
                }
            }
        }
    }
}