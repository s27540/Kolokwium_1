using Microsoft.Data.SqlClient;
using WebApplication1.Model;
using WebApplication1.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly IConfiguration _connectionString;

    public OrderRepository(IConfiguration connectionString)
    {
        _connectionString = connectionString;
    }

    public IEnumerable<Product> GetOrder(int id)
    {
        var products = new List<Product>();
        using (var connection = new SqlConnection(_connectionString["ConnectionStrings:DefaultConnection"]))
        {
            connection.Open();
            var query = "SELECT p.Id, p.Name AS Product, o.IdClient AS Client " +
                        "FROM [Order] o " +
                        "INNER JOIN Order_Product op ON o.IdOrder = op.IdOrder " +
                        "INNER JOIN Product p ON op.IdProduct = p.IdProduct " +
                        "WHERE p.Id = @id " + "ORDER BY p.Name DESC ";
            using (var command = new SqlCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var product = new Product()
                        {
                            IdProduct = (int)reader["IdProduct"],
                            Name = reader["Name"].ToString(),
                            IdClient = (int)reader["IdClient"]
                        };
                        products.Add(product);
                    }
                }
            }
        }
        return products;
    }

    public IEnumerable<Product> GetOrderById(int orderId)
    {
        throw new NotImplementedException();
    }

    public void DeleteOrder(int orderId)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString["ConnectionStrings:DefaultConnection"]))
        {
            string query = "DELETE FROM Orders WHERE IdOrder = @IdOrder";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@IdOrder", orderId);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}