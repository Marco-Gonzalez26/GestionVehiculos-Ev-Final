using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionVehiculos_Ev_Final.Views.Home
{
    public partial class UC_Home : UserControl
    {
        public UC_Home()
        {
            InitializeComponent();
        }

        private void UC_Home_Load(object sender, EventArgs e)
        {
            this.vistaVentasTableAdapter.Fill(this.gestionVehiculosDataSet.VistaVentas);
            this.btnSave.RefreshReport();
        }

        private void salesReport_Load(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this.vistaVentasTableAdapter.FillBySearch(this.gestionVehiculosDataSet.VistaVentas, txtSearch.Text);
            this.btnSave.RefreshReport();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.vistaVentasTableAdapter.FillBySearch(this.gestionVehiculosDataSet.VistaVentas, txtSearch.Text);
            this.btnSave.RefreshReport();
        }
    }
}
