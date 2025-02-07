

namespace GestionVehiculos_Ev_Final.Controllers
{

    using System.Collections.Generic;
    using System.Data.SqlClient;
    using GestionVehiculos_Ev_Final.Config;
    using GestionVehiculos_Ev_Final.Models;

    class ClientsController
    {
        private readonly DbConnection cn = new DbConnection();

        // Get all clients
        public List<ClientModel> getAll()
        {
            var clients = new List<ClientModel>();
            using (var connection = cn.getConnection())
            {
                connection.Open();
                string queryString = "SELECT IdCliente, Nombre, Telefono FROM Cliente;";

                using (var command = new SqlCommand(queryString, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var client = new ClientModel
                            {
                                IdCliente = (int)reader["IdCliente"],
                                Nombre = reader["Nombre"].ToString(),
                                Telefono = reader["Telefono"].ToString()
                            };
                            clients.Add(client);
                        }
                    }
                }
            }
            return clients;
        }

        // Get one client by ID
        public ClientModel getOne(int clientId)
        {
            var client = new ClientModel();
            using (var connection = cn.getConnection())
            {
                connection.Open();
                string queryString = "SELECT IdCliente, Nombre, Telefono FROM Cliente WHERE IdCliente = @ClientId;";

                using (var command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.Add(new SqlParameter("@ClientId", clientId));
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read()) return null;

                        client = new ClientModel
                        {
                            IdCliente = (int)reader["IdCliente"],
                            Nombre = reader["Nombre"].ToString(),
                            Telefono = reader["Telefono"].ToString()
                        };
                    }
                }
                return client;
            }
        }

        // Insert a new client
        public string insert(ClientModel clientToAdd)
        {
            string queryString = "INSERT INTO Cliente (Nombre, Telefono) VALUES (@Name, @Phone);";
            using (var connection = cn.getConnection())
            {
                using (var command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Name", clientToAdd.Nombre));
                    command.Parameters.Add(new SqlParameter("@Phone", clientToAdd.Telefono));
                    connection.Open();
                    return command.ExecuteNonQuery() != 0 ? "OK" : "Error";
                }
            }
        }

        // Update a client
        public string updateOne(ClientModel clientToUpdate)
        {
            string queryString = "UPDATE Cliente SET Nombre=@Name, Telefono=@Phone WHERE IdCliente = @ClientId;";
            using (var connection = cn.getConnection())
            {
                using (var command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Name", clientToUpdate.Nombre));
                    command.Parameters.Add(new SqlParameter("@Phone", clientToUpdate.Telefono));
                    command.Parameters.Add(new SqlParameter("@ClientId", clientToUpdate.IdCliente));
                    connection.Open();
                    return command.ExecuteNonQuery() != 0 ? "OK" : "Error";
                }
            }
        }

        // Delete a client
        public string deleteOne(int clientId)
        {
            string queryString = "DELETE FROM Cliente WHERE IdCliente = @ClientId;";
            using (var connection = cn.getConnection())
            {
                using (var command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.Add(new SqlParameter("@ClientId", clientId));
                    connection.Open();
                    return command.ExecuteNonQuery() != 0 ? "OK" : "Error";
                }
            }
        }
    }
}
