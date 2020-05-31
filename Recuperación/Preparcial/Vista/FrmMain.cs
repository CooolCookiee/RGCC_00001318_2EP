using Preparcial.Modelo;
using Preparcial.Controlador;
using System.Windows.Forms;
using System.Linq;
using System;

namespace Preparcial.Vista
{
    public partial class FrmMain : Form
    {
        private Usuario u;

        public FrmMain(Usuario u)
        {
            InitializeComponent();
            this.u = u;
            
            //Llenando comoBox de productos 
            cmbProductMakeOrder.DataSource = null;
            cmbProductMakeOrder.ValueMember = "idArticulo";
            cmbProductMakeOrder.DisplayMember = "producto";
            cmbProductMakeOrder.DataSource = ControladorInventario.GetProductos();
            
            ActualizarOrdenes();

        }
        
        //Implemento funcion para mostrar solo las ventanas que el Admin puede accesar y el usuario no

        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (u.Admin)
            {
                tabControl1.TabPages[3].Parent = null;
            }
            else
            {
                tabControl1.TabPages[1].Parent = null;
                tabControl1.TabPages[1].Parent = null;
            }

        }

        private void bttnCreateUser_Click(object sender, EventArgs e)
        {
            if (!txtNewUser.Text.Equals(""))
            {
                ControladorUsuario.CrearUsuario(txtNewUser.Text);
                ActualizarCrearUsuario();
            }
        }

        private void ActualizarCrearUsuario()
        {
            //Mandamos a llamar a la funcion correcta
            dgvCreateUser.DataSource = ControladorUsuario.GetUsuarios();
        }

        private void ActualizarInventario()
        {
            dgvInventary.DataSource = ControladorInventario.GetProductosTable();
            ActualizarOrdenes();
            
        }

        //No inicisalizada, y a su vez separe pedidos por tipo de usuario
        private void ActualizarOrdenes()
        {

            if (u.Admin)
            {
                dgvAllOrders.DataSource = ControladorPedido.GetPedidosTable();
            }
            else
            {
                dgvAllOrders.DataSource = ControladorPedido.GetPedidosUsuarioTable(u.IdUsuario);
            }
            
        }

        private void ActualizarOrdenesUsuario()
        {
            dgvMyOrders.DataSource = ControladorPedido.GetPedidosUsuarioTable(u.IdUsuario);
            
            //Se tiene que llenar desde el principio de la ventana
            /*cmbProductMakeOrder.ValueMember = "idarticulo";
            cmbProductMakeOrder.DisplayMember = "producto";
            cmbProductMakeOrder.DataSource = ControladorInventario.GetProductos();*/
        }

        private void bttnAddInventary_Click(object sender, EventArgs e)
        {
            if (txtProductNameInventary.Text.Equals("") &&
                txtDescriptionInventary.Text.Equals("") &&
                txtPriceInventary.Text.Equals("") &&
                txtStockInventary.Text.Equals(""))
                MessageBox.Show("No puede dejar campos vacios");
            else
            {
                ControladorInventario.AnadirProducto(txtProductNameInventary.Text, txtDescriptionInventary.Text,
                    txtPriceInventary.Text, txtStockInventary.Text);

                ActualizarInventario();
            }
        }

        private void bttnDeleteInventary_Click(object sender, EventArgs e)
        {
            if(txtDeleteInventary.Text.Equals(""))
                MessageBox.Show("No puede dejar campos vacios");
            else
            {
                ControladorInventario.EliminarProducto(txtDeleteInventary.Text);
                ActualizarInventario();
            }
        }

        private void bttnUpdateStockInventary_Click(object sender, EventArgs e)
        {
            if (txtUpdateStockIdInventary.Text.Equals("") && txtUpdateStockInventary.Text.Equals(""))
                MessageBox.Show("No puede dejar campos vacios");
            else
            {
                ControladorInventario.ActualizarProducto(txtUpdateStockIdInventary.Text, txtUpdateStockInventary.Text);
                ActualizarInventario();
            }
        }

        private void bttnMakeOrder_Click(object sender, EventArgs e)
        {
            if (txtMakeOrderQuantity.Text.Equals(""))
                MessageBox.Show("No puede dejar campos vacios");
            else
            {
                ControladorPedido.HacerPedido(u.IdUsuario, cmbProductMakeOrder.SelectedValue.ToString(), txtMakeOrderQuantity.Text);
                ActualizarOrdenesUsuario();
                ActualizarOrdenes();
            }
        }

        //Codigo con malas practicas, ya que el usuario no tiene que visualizar opciones de admin
        /*private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name.Equals("createNewUserTab") && u.Admin)
                ActualizarCrearUsuario();

            else if (tabControl1.SelectedTab.Name.Equals("inventaryTab") && u.Admin)
                ActualizarInventario();

            else if (tabControl1.SelectedTab.Name.Equals("createOrderTab") && !u.Admin)
                ActualizarOrdenesUsuario();

            else if (tabControl1.SelectedTab.Name.Equals("viewOrdersTab") && u.Admin)
                ActualizarOrdenes();
            
            else
            {
                MessageBox.Show("No tiene permisos para ver esta pestana");
                tabControl1.SelectedTab = tabControl1.TabPages[0];
            }

        }*/

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
    Application.Exit();
        }
    }
}
