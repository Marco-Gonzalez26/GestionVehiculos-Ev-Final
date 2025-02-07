using GestionVehiculos_Ev_Final.Controllers;
using GestionVehiculos_Ev_Final.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionVehiculos_Ev_Final.Views.Vehicles
{
    public partial class FrmVehicles : Form
    {
        private int? vehicleId = 0;
        private bool? edit = false;
        private VehiclesController vehiclesController = new VehiclesController();
        public FrmVehicles(int? vehicleId, bool edit)
        {
            this.vehicleId = vehicleId;
            this.edit = edit;
            InitializeComponent();
        }

        private void txtYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true;
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true;
        }

        private void txtBrand_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true;
        }

        // Check if the fields are empty
        private bool checkFields() { 
            if(txtBrand.Text.Length == 0 
                || txtModel.Text.Length == 0
                || txtPrice.Text.Length == 0
                || txtYear.Text.Length == 0) return false;
        return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!checkFields())
            {
                MessageBox.Show("Por favor rellene escoja un vehiculo y un cliente para realizar la venta");
                return;
            }
            var message = "";

            VehicleModel vehicle = new VehicleModel
            {
                Anio = Convert.ToInt32(txtYear.Text),
                Marca = txtBrand.Text,
                Modelo = txtModel.Text,
                Precio = Convert.ToDecimal(txtPrice.Text),
            };
            if (!(bool)edit) { 
                message = vehiclesController.insert(vehicle);
                if (message.Contains("OK"))
                {
                    MessageBox.Show("El registro se agregó correctamente");
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error");
                }
            } else
            {
                vehicle.IdVehiculo = (int)vehicleId;
                message = vehiclesController.updateOne(vehicle);
                if (message.Contains("OK"))
                {
                    MessageBox.Show("El registro se actualizó correctamente");
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error");
                }
            }



            Close();
        }

        private void FrmVehicles_Load(object sender, EventArgs e)
        {
            if ((bool)edit)
            {
                var vehicleToEdit = vehiclesController.getOne((int)vehicleId);
                txtBrand.Text = vehicleToEdit.Marca;
                txtModel.Text = vehicleToEdit.Modelo;
                txtPrice.Text = vehicleToEdit.Precio.ToString();
                txtYear.Text = vehicleToEdit.Anio.ToString();

            }
        }
    }
}
