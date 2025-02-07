

namespace GestionVehiculos_Ev_Final.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Windows.Forms;
    using GestionVehiculos_Ev_Final.Config;
    using GestionVehiculos_Ev_Final.Models;

    class SalesController
    {
        private SaleModel saleModel = new SaleModel();
        private readonly DbConnection cn = new DbConnection();

        // Get all sales with vehicle and customer details
        public List<SaleModel> getAll()
        {
            var sales = new List<SaleModel>();
            using (var connection = cn.getConnection())
            {
                connection.Open();
                string queryString = @"
                SELECT 
                    v.IdVenta, v.IdVehiculo, v.IdCliente, v.Fecha, v.Monto,
                    vh.Marca + ' ' + vh.Modelo AS NombreVehiculo,
                    c.Nombre AS NombreCliente, c.Telefono AS TelefonoCliente
                FROM Venta v
                INNER JOIN Vehiculo vh ON v.IdVehiculo = vh.IdVehiculo
                INNER JOIN Cliente c ON v.IdCliente = c.IdCliente;";

                using (var command = new SqlCommand(queryString, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var sale = new SaleModel
                            {
                                IdVenta = (int)reader["IdVenta"],
                                IdVehiculo = (int)reader["IdVehiculo"],
                                IdCliente = (int)reader["IdCliente"],
                                Fecha = reader["Fecha"].ToString(),
                                Monto = (decimal)reader["Monto"],
                                NombreVehiculo = reader["NombreVehiculo"].ToString(),
                                NombreCliente = reader["NombreCliente"].ToString(),
                                TelefonoCliente = reader["TelefonoCliente"].ToString()
                            };
                            sales.Add(sale);
                        }
                    }
                }
            }
            return sales;
        }

        // Get one sale by ID
        public SaleModel getOne(int saleId)
        {
            var sale = new SaleModel();
            using (var connection = cn.getConnection())
            {
                connection.Open();
                string queryString = @"
                SELECT 
                    v.IdVenta, v.IdVehiculo, v.IdCliente, v.Fecha, v.Monto,
                    vh.Marca + ' ' + vh.Modelo AS NombreVehiculo,
                    c.Nombre AS NombreCliente, c.Telefono AS TelefonoCliente
                FROM Venta v
                INNER JOIN Vehiculo vh ON v.IdVehiculo = vh.IdVehiculo
                INNER JOIN Cliente c ON v.IdCliente = c.IdCliente
                WHERE v.IdVenta = @SaleId;";

                using (var command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.Add(new SqlParameter("@SaleId", saleId));
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read()) return null;

                        sale = new SaleModel
                        {
                            IdVenta = (int)reader["IdVenta"],
                            IdVehiculo = (int)reader["IdVehiculo"],
                            IdCliente = (int)reader["IdCliente"],
                            Fecha = reader["Fecha"].ToString(),
                            Monto = (decimal)reader["Monto"],
                            NombreVehiculo = reader["NombreVehiculo"].ToString(),
                            NombreCliente = reader["NombreCliente"].ToString(),
                            TelefonoCliente = reader["TelefonoCliente"].ToString()
                        };
                    }
                }
                return sale;
            }
        }

        // Insert a new sale
        public string insert(SaleModel saleToAdd)
        {

            MessageBox.Show(saleToAdd.ToString());
            string queryString = "INSERT INTO Venta (IdVehiculo, IdCliente, Fecha, Monto) VALUES (@VehicleId, @ClientId, @Date, @Amount);";
            using (var connection = cn.getConnection())
            {
                using (var command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.Add(new SqlParameter("@VehicleId", saleToAdd.IdVehiculo));
                    command.Parameters.Add(new SqlParameter("@ClientId", saleToAdd.IdCliente));
                    command.Parameters.Add(new SqlParameter("@Date", saleToAdd.Fecha));
                    command.Parameters.Add(new SqlParameter("@Amount", saleToAdd.Monto));
                    connection.Open();
                    return command.ExecuteNonQuery() != 0 ? "OK" : "Error";
                }
            }
        }

        // Update a sale
        public string updateOne(SaleModel saleToUpdate)
        {
            string queryString = "UPDATE Venta SET IdVehiculo=@VehicleId, IdCliente=@ClientId, Fecha=@Date, Monto=@Amount WHERE IdVenta = @SaleId;";
            using (var connection = cn.getConnection())
            {
                using (var command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.Add(new SqlParameter("@VehicleId", saleToUpdate.IdVehiculo));
                    command.Parameters.Add(new SqlParameter("@ClientId", saleToUpdate.IdCliente));
                    command.Parameters.Add(new SqlParameter("@Date", saleToUpdate.Fecha));
                    command.Parameters.Add(new SqlParameter("@Amount", saleToUpdate.Monto));
                    command.Parameters.Add(new SqlParameter("@SaleId", saleToUpdate.IdVenta));
                    connection.Open();
                    return command.ExecuteNonQuery() != 0 ? "OK" : "Error";
                }
            }
        }

        // Delete a sale
        public string deleteOne(int saleId)
        {
            string queryString = "DELETE FROM Venta WHERE IdVenta = @SaleId;";
            using (var connection = cn.getConnection())
            {
                using (var command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.Add(new SqlParameter("@SaleId", saleId));
                    connection.Open();
                    return command.ExecuteNonQuery() != 0 ? "OK" : "Error";
                }
            }
        }
        public List<SaleModel> search(string query)
        {
            var sales = new List<SaleModel>();
            using (var connection = cn.getConnection())
            {
                connection.Open();
                string queryString = @"
                SELECT 
                    v.IdVenta, v.IdVehiculo, v.IdCliente, v.Fecha, v.Monto,
                    vh.Marca + ' ' + vh.Modelo AS NombreVehiculo,
                    c.Nombre AS NombreCliente, c.Telefono AS TelefonoCliente
                FROM Venta v
                INNER JOIN Vehiculo vh ON v.IdVehiculo = vh.IdVehiculo
                INNER JOIN Cliente c ON v.IdCliente = c.IdCliente
WHERE c.Nombre LIKE @query OR vh.Marca LIKE @query OR vh.Modelo LIKE @query;";

                using (var command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.Add(new SqlParameter("@query", $"%{query}%"));
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var sale = new SaleModel
                            {
                                IdVenta = (int)reader["IdVenta"],
                                IdVehiculo = (int)reader["IdVehiculo"],
                                IdCliente = (int)reader["IdCliente"],
                                Fecha = reader["Fecha"].ToString(),
                                Monto = (decimal)reader["Monto"],
                                NombreVehiculo = reader["NombreVehiculo"].ToString(),
                                NombreCliente = reader["NombreCliente"].ToString(),
                                TelefonoCliente = reader["TelefonoCliente"].ToString()
                            };
                            sales.Add(sale);
                        }
                    }
                }
            }
            return sales;
        }
    }
}
