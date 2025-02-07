using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVehiculos_Ev_Final.Models
{
    public class SaleModel
    {
        public int IdVenta { get; set; }
        public int IdVehiculo { get; set; }
        public int IdCliente { get; set; }
        public string Fecha { get; set; }
        public decimal Monto { get; set; }
        public string NombreVehiculo { get; set; }
        public string NombreCliente { get; set; }
        public string TelefonoCliente {  get; set; }

    }
}
