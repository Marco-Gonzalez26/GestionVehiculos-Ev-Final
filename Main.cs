
namespace GestionVehiculos_Ev_Final
{
    using GestionVehiculos_Ev_Final.Views.Clients;
    using GestionVehiculos_Ev_Final.Views.Home;
    using GestionVehiculos_Ev_Final.Views.Sales;
    using GestionVehiculos_Ev_Final.Views.Vehicles;
    using System;
    using System.Windows.Forms;

    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
           
            UC_Home uC_Home = new UC_Home();
            container.Controls.Clear();
            container.Controls.Add(uC_Home);

        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            UC_Client uC_Client = new UC_Client();
            container.Controls.Clear();
            container.Controls.Add(uC_Client);

        }

        private void btnVehicles_Click(object sender, EventArgs e)
        {
            UC_Vehicles uC_Vehicles = new UC_Vehicles();    
            container.Controls.Clear();
            container.Controls.Add(uC_Vehicles);
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            UC_Sales uC_Sales = new UC_Sales(); 
            container.Controls.Clear();
            container.Controls.Add(uC_Sales);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            UC_Home uC_Home = new UC_Home();
            container.Controls.Clear();
            container.Controls.Add(uC_Home);
        }
    }
}
