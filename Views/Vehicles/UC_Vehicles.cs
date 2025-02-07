using GestionVehiculos_Ev_Final.Controllers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GestionVehiculos_Ev_Final.Views.Vehicles
{
    public partial class UC_Vehicles : UserControl
    {
        public UC_Vehicles()
        {
            InitializeComponent();
        }
        private VehiclesController vehiclesController = new VehiclesController();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmVehicles frmVehicles = new FrmVehicles(null, false);
            frmVehicles.ShowDialog();
        }
        public void loadGridViewStyles()
        {

            dgvVehicles.Dock = DockStyle.Fill;



            // Habilitar el ajuste automático de la altura de las filas al cambiar su contenido
            dgvVehicles.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvVehicles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvVehicles.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvVehicles.Dock = DockStyle.Fill;
            dgvVehicles.DefaultCellStyle.Font = new Font("DejaVu Sans", 12, FontStyle.Regular);
            dgvVehicles.AutoSize = true;
            // Aumentar el tamaño de la fuente en los encabezados
            dgvVehicles.ColumnHeadersDefaultCellStyle.Font = new Font("DejaVu Sans", 13, FontStyle.Bold);
            // Forzar la actualización de la interfaz
            dgvVehicles.Refresh();
        }
        public void fillGridView(bool search)
        {

            dgvVehicles.DataSource = "";
            dgvVehicles.Columns.Clear();
            if (!search)
            {
                dgvVehicles.DataSource = vehiclesController.getAll();
            }
            else
            {
                dgvVehicles.DataSource = vehiclesController.search(txtSearch.Text.Trim());

            }


            dgvVehicles.Columns["Anio"].HeaderText = "Año";
            dgvVehicles.Columns["Precio"].HeaderText = "Precio";
            dgvVehicles.Columns["IdVehiculo"].Visible = false;
            dgvVehicles.Columns["MarcaModelo"].Visible = false;

            var btnEdit = new DataGridViewButtonColumn
            {
                HeaderText = "Editar",
                Text = "Editar",
                UseColumnTextForButtonValue = true
            };

            var btnDelete = new DataGridViewButtonColumn
            {
                HeaderText = "Eliminar",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true
            };

            dgvVehicles.Columns.Add(btnEdit);
            dgvVehicles.Columns.Add(btnDelete);
        }
        public void editVehicle(int id)
        {
            FrmVehicles frmVehicles = new FrmVehicles(id, true);
            frmVehicles.ShowDialog();
            fillGridView(false);
        }
        public void deleteVehicle(int id)
        {
            DialogResult dialogResult = MessageBox.Show("¿Esta seguro?", "Eliminar Vehiculo", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                var result = vehiclesController.deleteOne(id);

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

        private void dgvVehicles_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {


        }

        private void dgvVehicles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dgvVehicles.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                var selectedRow = dgvVehicles.Rows[e.RowIndex];
                var vehicleId = selectedRow.Cells["IdVehiculo"].Value;


                if (dgvVehicles.Columns[e.ColumnIndex].HeaderText == "Editar")
                {
                    editVehicle((int)vehicleId);
                }

                if (dgvVehicles.Columns[e.ColumnIndex].HeaderText == "Eliminar")
                {
                    deleteVehicle((int)vehicleId);
                }

            }
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            FrmVehicles frmVehicles = new FrmVehicles(null, false);
            frmVehicles.ShowDialog();
            fillGridView(false);
        }

        private void UC_Vehicles_Load(object sender, EventArgs e)
        {
            loadGridViewStyles();
            fillGridView(false);


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            fillGridView(true);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            fillGridView(true);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
