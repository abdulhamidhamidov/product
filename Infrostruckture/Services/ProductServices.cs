using Infrostruckture.Interface;
using Infrostruckture.Models;
using Npgsql;
namespace Infrostruckture.Services;

public class ProductServices: IProduct
{
    public bool CreateProduct(Product product)
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommands.mainConnection))
        {
            connection.Open();
            NpgsqlCommand command = connection.CreateCommand();
            command.CommandText ="insert into product(product_name, price, quantity, created_at)values (@ProductName,@Price,@Quantity,@CreatedAt);";
            command.Parameters.AddWithValue("ProductName", product.ProductName);
            command.Parameters.AddWithValue("Price", product.Price);
            command.Parameters.AddWithValue("Quantity", product.Quantity);
            command.Parameters.AddWithValue("CreatedAt", product.CreatedAt);
            int b = command.ExecuteNonQuery();
            if (b >0) return true;
            else return false;
        }
    }
    public List<Product> GetProducts()
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommands.mainConnection))
        {
            List<Product> list = new List<Product>();
            connection.Open();
            NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = SqlCommands.getProduct;
            using (NpgsqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                 Product product = new Product();
                 product.Id = reader.GetInt32(0);
                 product.ProductName = reader.GetString(1);
                 product.Price = reader.GetDecimal(2);
                 product.Quantity = reader.GetInt32(3);
                 product.CreatedAt = reader.GetDateTime(4);
                 list.Add(product);   
                }
            }

            return list;
        }
    }

    public Product GetByIdProduct(int id)
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommands.mainConnection))
        {
            connection.Open();
            Product product = new Product();
            NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = SqlCommands.getProductById;
            command.Parameters.AddWithValue("@Id", id);
            using (NpgsqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                product.Id = reader.GetInt32(0);
                product.ProductName = reader.GetString(1);
                product.Price = reader.GetDecimal(2);
                product.Quantity = reader.GetInt32(3);
                product.CreatedAt = reader.GetDateTime(4);
                }
            }
            return product;
        }
    }

    public bool Update(Product product)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.mainConnection))
        {
            connection.Open();
            NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = "update product set product_name=@ProductName,price=@Price,quantity=@Quantity,created_at=@CreatedAt where id = @Id";
            command.Parameters.AddWithValue("@Id", product.Id);
            command.Parameters.AddWithValue("@ProductName", product.ProductName);
            command.Parameters.AddWithValue("@Price", product.Price);
            command.Parameters.AddWithValue("@Quantity", product.Quantity);
            command.Parameters.AddWithValue("@CreatedAt", product.CreatedAt);
            int b = command.ExecuteNonQuery();
            if (b >0) return true;
            else return false;
        }
    }

    public bool Delete(int id)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.mainConnection))
        {
            connection.Open();
            NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = SqlCommands.deleteById;
            command.Parameters.AddWithValue("@Id", id);
            int b = command.ExecuteNonQuery();
            if (b >0) return true;
            else return false;
        }
    }
}

file class SqlCommands
{
    public static string baseConnection = "Server=localhost;Port=5432;Database=postgres;Username=postgres;Password=12345";
    public static string mainConnection = "Server=localhost;Port=5432;Database=product_db;Username=postgres;Password=12345";
    public static string insertProduct = "insert into product(product_name, price, quantity, created_at)values (@ProductName,@Price,@Quantity,@CreatedAt);";
    public static string getProduct="select * from product";
    public static string getProductById = "select * from product where id = @Id";
    public static string updateById = "update product set product_name=@ProductName,price=@Price,quantity=@Quantity,created_at=@CreatedAt where id = @Id";
    public static string deleteById = "delete from product where id=@Id";
}