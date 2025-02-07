using System;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using GestionVehiculos_Ev_Final.Controllers;
using GestionVehiculos_Ev_Final.Models;
namespace GestionVehiculos_Ev_Final.Views.Sales
{
    public partial class FrmSales : Form
    {
        public FrmSales()
        {
            InitializeComponent();
        }
        SalesController salesController = new SalesController();
        VehiclesController vehiclesController = new VehiclesController();
        ClientsController clientsController = new ClientsController();
        VehicleModel vehicleModel = new VehicleModel();
        private void FrmSales_Load(object sender, EventArgs e)
        {
            var clients = clientsController.getAll();
            cmbClient.Items.Clear();
            cmbClient.DataSource = clients;
            cmbClient.ValueMember = "IdCliente";
            cmbClient.DisplayMember = "Nombre";

            var vehicles = vehiclesController.getAll();
            cmbVehicles.Items.Clear();
            cmbVehicles.DataSource = vehicles;
            cmbVehicles.ValueMember = "IdVehiculo";
            cmbVehicles.DisplayMember = "MarcaModelo";

            var firstVehicle = vehiclesController.getAll()[0];
            cmbVehicles.SelectedValue = firstVehicle.IdVehiculo;

            txtAmount.Text = firstVehicle.Precio.ToString() + "$";

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cmbVehicles_SelectedValueChanged(object sender, EventArgs e)
        {

            if (cmbVehicles.SelectedValue == null || !cmbVehicles.SelectedValue.GetType().Name.Equals("Int32")) return;
            var id = Convert.ToInt32(cmbVehicles.SelectedValue);
            var vehicle = vehiclesController.getOne(id);
            vehicleModel.IdVehiculo = vehicle.IdVehiculo;
            vehicleModel.Precio = vehicle.Precio;
            txtAmount.Text = vehicle.Precio.ToString() + "$";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtAmount.Text.Length == 0 || vehicleModel.IdVehiculo <= 0) {
                MessageBox.Show("Por favor rellene escoja un vehiculo y un cliente para realizar la venta");
                return;
            }
            var message = "";
            SaleModel newSale = new SaleModel
            {
                 Fecha = DateTime.Now.ToString(),       
                 IdCliente = (int)cmbClient.SelectedValue,
                 IdVehiculo = (int)cmbVehicles.SelectedValue,
                 Monto = vehicleModel.Precio
                 
            };
            message = salesController.insert(newSale);
            if (message.Contains("OK"))
            {
                MessageBox.Show("Venta anulada correctamente");
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error");
            }
            Close();
        }

        private void cmbVehicles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
           e.Handled = true;
        }
    }
}
