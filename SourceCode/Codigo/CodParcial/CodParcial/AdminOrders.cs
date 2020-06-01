using System.Windows.Forms;

namespace CodParcial
{
    public partial class AdminOrders : UserControl
    {
        public AdminOrders()
        {
            InitializeComponent();
            
            var dt = ConnectionDB.ExecuteQuery($"SELECT ao.idOrder, ao.createDate, pr.name, au.fullname, ad.address "+
                                               "FROM APPORDER ao, ADDRESS ad, PRODUCT pr, APPUSER au "+
                                               "WHERE ao.idProduct = pr.idProduct AND ao.idAddress = ad.idAddress "+
                                               "AND ad.idUser = au.idUser");

            OrdersDataGridView.DataSource = dt;
            
        }
    }
}