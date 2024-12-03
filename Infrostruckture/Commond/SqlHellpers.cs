using Npgsql;

namespace Infrostruckture.Commond;

public class SqlHellpers
{
    public bool CreateDatabase()
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommands.baseConnection))
        {
            connection.Open();
            NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = SqlCommands.createDataBase;
            int b = command.ExecuteNonQuery();
            if (b == -1) return true;
            else return false;
        }
    }
    public bool DropDatabase()
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommands.baseConnection))
        {
            connection.Open();
            NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = SqlCommands.dropDataBase;
            int b = command.ExecuteNonQuery();
            if (b == -1) return true;
            else return false;
        }
    }
    public bool CreateTable()
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommands.mainConnection))
        {
            connection.Open();
            NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = SqlCommands.createTable;
            int b = command.ExecuteNonQuery();
            if (b ==-1) return true;
            else return false;
        }
    }
    public bool DropTable()
    {
        using (NpgsqlConnection connection=new NpgsqlConnection(SqlCommands.mainConnection))
        {
            connection.Open();
            NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = SqlCommands.dropTable;
            int b = command.ExecuteNonQuery();
            if (b ==-1) return true;
            else return false;
        }
    }
    
}

file class SqlCommands
{
    public static string baseConnection = "Server=localhost;Port=5432;Database=postgres;Username=postgres;Password=12345";
    public static string mainConnection = "Server=localhost;Port=5432;Database=product_db;Username=postgres;Password=12345";
    public static string createDataBase = "create database product_db";
    public static string dropDataBase = "drop database product_db with(force)";
    public static string createTable = "create table product (   id serial primary key ,   product_name varchar(50) not null ,  price decimal ,  quantity int , created_at date );";
    public static string dropTable = "drop table product with(force)";
    public static string getProduct="select * from product";
}