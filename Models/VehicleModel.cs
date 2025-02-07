

namespace GestionVehiculos_Ev_Final.Models
{
    public class VehicleModel
    {
        public int IdVehiculo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public decimal Precio { get; set; }

        public string MarcaModelo { get; set; } = string.Empty;
    }
}

