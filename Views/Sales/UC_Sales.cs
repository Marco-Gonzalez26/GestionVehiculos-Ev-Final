using GestionVehiculos_Ev_Final.Controllers;
using GestionVehiculos_Ev_Final.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionVehiculos_Ev_Final.Views.Sales
{
    public partial class UC_Sales : UserControl
    {
        public UC_Sales()
        {
            InitializeComponent();
        }
        SalesController salesController = new SalesController();

        public void loadGridViewStyles()
        {

            dgvSales.Dock = DockStyle.Fill;



            // Habilitar el ajuste automático de la altura de las filas al cambiar su contenido
            dgvSales.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvSales.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvSales.Dock = DockStyle.Fill;
            dgvSales.DefaultCellStyle.Font = new Font("DejaVu Sans", 12, FontStyle.Regular);

            // Aumentar el tamaño de la fuente en los encabezados
            dgvSales.ColumnHeadersDefaultCellStyle.Font = new Font("DejaVu Sans", 13, FontStyle.Bold);
            // Forzar la actualización de la interfaz
            dgvSales.Refresh();
        }
        public void fillGridView(bool search)
        {

            dgvSales.DataSource = "";
            dgvSales.Columns.Clear();
            if (!search)
            {

                dgvSales.DataSource = salesController.getAll();
            }
            else
            {
                dgvSales.DataSource = salesController.search(txtSearch.Text.Trim());

            }


            var btnDelete = new DataGridViewButtonColumn
            {
                HeaderText = "Anular",
                Text = "Anular",
                UseColumnTextForButtonValue = true
            };

            dgvSales.Columns["NombreCliente"].HeaderText = "Cliente";
            dgvSales.Columns["NombreVehiculo"].HeaderText = "Vehiculo";
            dgvSales.Columns["Monto"].HeaderText = "Monto";
            dgvSales.Columns["Fecha"].HeaderText = "Fecha";
            dgvSales.Columns["IdVenta"].Visible = false;
            dgvSales.Columns["IdVehiculo"].Visible = false;
            dgvSales.Columns["IdCliente"].Visible = false;

            dgvSales.Columns.Add(btnDelete);


        }
        public void deleteSale(int id)
        {
            DialogResult dialogResult = MessageBox.Show("¿Esta seguro?", "Anular Venta", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                var result = salesController.deleteOne(id);

                if (result.Contains("OK"))
                {
                    MessageBox.Show("Registro se ha eliminado correctamente");
                    this.fillGridView(false);
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error al eliminar");
                }
            }
            else
            {
                MessageBox.Show("El usuario canceló la eliminación");
            }
        }

        private void dgvSales_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
        }

        private void dgvSales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dgvSales.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                var selectedRow = dgvSales.Rows[e.RowIndex];
                var loanId = selectedRow.Cells["IdVenta"].Value;

                if (dgvSales.Columns[e.ColumnIndex].HeaderText == "Anular")
                {
                    deleteSale((int)loanId);
                }

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmSales frmSale = new FrmSales();
            frmSale.ShowDialog();
            fillGridView(false);
        }

        private void UC_Sales_Load(object sender, EventArgs e)
        {
            fillGridView(false);
            loadGridViewStyles();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            fillGridView(true);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            fillGridView(true);
        }
    }
}
