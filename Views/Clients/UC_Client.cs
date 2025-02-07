using GestionVehiculos_Ev_Final.Controllers;
using GestionVehiculos_Ev_Final.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionVehiculos_Ev_Final.Views.Clients
{
    public partial class UC_Client : UserControl
    {
        public UC_Client()
        {
            InitializeComponent();
        }
        private ClientsController clientsController = new ClientsController();
        private ClientModel clientModel = new ClientModel();
        private void loadClients()
        {

            var users = clientsController.getAll();
            lstClients.DataSource = users;


            lstClients.ValueMember = "IdCliente";
            lstClients.DisplayMember = "Nombre";
            lstClients.ClearSelected();
        }

        public void edit()
        {
            if (lstClients.SelectedIndex == -1)
            {
                MessageBox.Show("Elija a un usuario de la lista");
                return;
            }

            clientModel = clientsController.getOne((int)lstClients.SelectedValue);
            txtName.Text = clientModel.Nombre;

            txtPhoneNum.Text = clientModel.Telefono;

        }
        private void clear()
        {
            txtName.Text = "";

            txtPhoneNum.Text = "";

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (
                txtName.Text == "" ||
                txtPhoneNum.Text == "")
            {
                MessageBox.Show("Rellene todos los campos");
                return;
            }

            if (txtPhoneNum.Text.Length < 10 || !txtPhoneNum.Text.StartsWith("0"))
            {
                MessageBox.Show("Numero de teléfono invalido");
                return;
            }
            var message = "";

            if (clientModel.IdCliente == 0)
            {
                clientModel = new ClientModel
                {
                    Nombre = txtName.Text,

                    Telefono = txtPhoneNum.Text
                };
                message = clientsController.insert(clientModel);
                clear();

            }
            else
            {
                clientModel.Nombre = txtName.Text;
                clientModel.Telefono = txtPhoneNum.Text;
                message = clientsController.updateOne(clientModel);
            }

            if (message == "OK")
            {
                MessageBox.Show("Se ha guardado exitosamente");
                loadClients();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al guardar");
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            edit();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstClients.SelectedIndex == -1)
            {
                MessageBox.Show("Elija un usuario para la eliminación");
                return;
            }

            var userId = lstClients.SelectedValue;

            DialogResult dialogBox = MessageBox.Show("¿Está seguro?, esta operacion no se puede revertir", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogBox == DialogResult.Yes)
            {
                var message = clientsController.deleteOne((int)userId);

                if (message.Contains("OK"))
                {
                    MessageBox.Show("Registro eliminado correctamente");
                    loadClients();
                    clear();
                }
                else
                {
                    MessageBox.Show($"{message} - No se pudo eliminar el registro");
                }
            }
        }

        private void lstClients_DoubleClick(object sender, EventArgs e)
        {
            edit();
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;

            }
        }


        private void txtPhoneNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;

            }
        }

        private void UC_Client_Load(object sender, EventArgs e)
        {
            loadClients();
            lstClients.ClearSelected();
        }
    }
}
