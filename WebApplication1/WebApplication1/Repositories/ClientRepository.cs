using Microsoft.Data.SqlClient;
using WebApplication1.Model;

namespace WebApplication1.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly IConfiguration _connectionString;

    public ClientRepository(IConfiguration connectionString)
    {
        _connectionString = connectionString;
    }

    public Client GetClientById(int clientId)
    {
        Client client = null;
        using (SqlConnection connection = new SqlConnection(_connectionString["ConnectionStrings:DefaultConnection"]))
        {
            string query = "SELECT * FROM Clients WHERE IdClient = @IdClient";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@IdClient", clientId);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                client = new Client
                {
                    IdClient = (int)reader["Id"],
                    FirstName = (string)reader["Name"]
                };
            }
            reader.Close();
        }
        return client;
    }

    public void DeleteClient(int clientId)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString["ConnectionStrings:DefaultConnection"]))
        {
            string query = "DELETE FROM Clients WHERE IdClient = @IdClient";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@IdClient", clientId);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}