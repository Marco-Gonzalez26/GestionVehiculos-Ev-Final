

namespace GestionVehiculos_Ev_Final.Controllers
{
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Windows.Forms;
    using GestionVehiculos_Ev_Final.Config;
    using GestionVehiculos_Ev_Final.Models;

    class VehiclesController
    {
        private VehicleModel VehicleModel = new VehicleModel();
        private readonly DbConnection cn = new DbConnection();
        
        // Get all VehicleModels
        public List<VehicleModel> getAll()
        {
            var vehicles = new List<VehicleModel>();
            using (var connection = cn.getConnection())
            {
                connection.Open();
                string queryString = "SELECT * FROM Vehiculo;";
                using (var command = new SqlCommand(queryString, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var marcaModelo = reader["Marca"].ToString() + " " + reader["Modelo"].ToString();
                            var vehicle = new VehicleModel
                            {
                                IdVehiculo = (int)reader["IdVehiculo"],
                                Marca = reader["Marca"].ToString(),
                                Modelo = reader["Modelo"].ToString(),
                                MarcaModelo = marcaModelo.ToString(),
                                Anio = (int)reader["Año"],
                                Precio = (decimal)reader["Precio"]
                            };

                            vehicles.Add(vehicle);
                        }
                    }
                }
            }
            return vehicles;
        }

        // Get one VehicleModel by ID
        public VehicleModel getOne(int VehicleModelId)
        {
            var vehicle = new VehicleModel();
            using (var connection = cn.getConnection())
            {
                connection.Open();
                string queryString = "SELECT * FROM Vehiculo WHERE IdVehiculo = @VehicleModelId;";
                using (var command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.Add(new SqlParameter("@VehicleModelId", VehicleModelId));
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read()) return null;

                        vehicle = new VehicleModel
                        {
                            IdVehiculo = (int)reader["IdVehiculo"],
                            Marca = reader["Marca"].ToString(),

                            Modelo = reader["Modelo"].ToString(),
                            Anio = (int)reader["Año"],
                            Precio = (decimal)reader["Precio"]
                        };
                    }
                }
                return vehicle;
            }
        }

        // Insert a new VehicleModel
        public string insert(VehicleModel VehicleModelToAdd)
        {
            string queryString = "INSERT INTO Vehiculo (Marca, Modelo, Año, Precio) VALUES (@Brand, @Model, @Year, @Price);";
            using (var connection = cn.getConnection())
            {
                using (var command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Brand", VehicleModelToAdd.Marca));
                    command.Parameters.Add(new SqlParameter("@Model", VehicleModelToAdd.Modelo));
                    command.Parameters.Add(new SqlParameter("@Year", VehicleModelToAdd.Anio));
                    command.Parameters.Add(new SqlParameter("@Price", VehicleModelToAdd.Precio));
                    connection.Open();

                    return command.ExecuteNonQuery() != 0 ? "OK" : "Error";
                }
            }
        }

        // Update a VehicleModel
        public string updateOne(VehicleModel VehicleModelToUpdate)
        {
            string queryString = "UPDATE Vehiculo SET Marca=@Brand, Modelo=@Model, Año=@Year, Precio=@Price WHERE IdVehiculo = @VehicleModelId;";
            using (var connection = cn.getConnection())
            {
                using (var command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Brand", VehicleModelToUpdate.Marca));
                    command.Parameters.Add(new SqlParameter("@Model", VehicleModelToUpdate.Modelo));
                    command.Parameters.Add(new SqlParameter("@Year", VehicleModelToUpdate.Anio));
                    command.Parameters.Add(new SqlParameter("@Price", VehicleModelToUpdate.Precio));
                    command.Parameters.Add(new SqlParameter("@VehicleModelId", VehicleModelToUpdate.IdVehiculo));
                    connection.Open();
                    return command.ExecuteNonQuery() != 0 ? "OK" : "Error";
                }
            }
        }

        // Delete a VehicleModel
        public string deleteOne(int VehicleModelId)
        {
            string queryString = "DELETE FROM Vehiculo WHERE IdVehiculo = @VehicleModelId;";
            using (var connection = cn.getConnection())
            {
                using (var command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.Add(new SqlParameter("@VehicleModelId", VehicleModelId));
                    connection.Open();
                    return command.ExecuteNonQuery() != 0 ? "OK" : "Error";
                }
            }
        }
        public List<VehicleModel> search(string query)
        {
            var vehicles = new List<VehicleModel>();
            using (var connection = cn.getConnection())
            {
                connection.Open();
                string queryString = "SELECT * FROM Vehiculo WHERE Modelo LIKE @query OR Marca LIKE @query;";
                using (var command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.Add(new SqlParameter("@query", $"%{query}%"));
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var marcaModelo = reader["Marca"].ToString() + " " + reader["Modelo"].ToString();
                            var vehicle = new VehicleModel
                            {
                                IdVehiculo = (int)reader["IdVehiculo"],
                                Marca = reader["Marca"].ToString(),
                                Modelo = reader["Modelo"].ToString(),
                                MarcaModelo = marcaModelo.ToString(),
                                Anio = (int)reader["Año"],
                                Precio = (decimal)reader["Precio"]
                            };

                            vehicles.Add(vehicle);
                        }
                    }
                }
            }
            return vehicles;
        }
    }
}
