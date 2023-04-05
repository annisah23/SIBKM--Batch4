using MVC.Contexts;
using MVC.Models;
using MVC.Repositories.Interfaces;
using System.Data.SqlClient;

namespace MVC.Repositories;

public class CountryRepository : ICountryRepository
{
    // GET ALL COUNTRY
    public List<Country> GetAll()
    {
        List<Country> country = new List<Country>();

        var connection = MyContext.GetConnection();

        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT * FROM country;";

        connection.Open();
        using SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                country.Add(new Country()
                {
                    Id = reader.GetString(0),
                    Name = reader.GetString(1),
                    Region = reader.GetInt32(2),
                });
            }
        }
        else
        {
            return null;
        }
        reader.Close();
        connection.Close();

        return country;


    }

    // GET COUNTRY BY ID
    public Country GetById(string id)
    {
        Country country = new Country();
        var connection = MyContext.GetConnection();

        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT * FROM country WHERE id = @id;";

        SqlParameter pId = new SqlParameter();
        pId.ParameterName = "@id";
        pId.SqlDbType = System.Data.SqlDbType.VarChar;
        pId.Value = id;
        command.Parameters.Add(pId);

        connection.Open();
        using SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            reader.Read();

            country.Id = reader.GetString(0);
            country.Name = reader.GetString(1);
            country.Region = reader.GetInt32(2);
        }
        else
        {
            return null;
        }
        reader.Close();
        connection.Close();

        return country;
    }

    // INSERT COUNTRY
    public int Insert(Country country)
    {
        var result = 0;
        var connection = MyContext.GetConnection();
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "INSERT INTO country (id, name, region) values (@id, @name, @region);";
            command.Transaction = transaction;

            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = System.Data.SqlDbType.VarChar;
            pId.Value = country.Id;
            command.Parameters.Add(pId);

            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.SqlDbType = System.Data.SqlDbType.VarChar;
            pName.Value = country.Name;
            command.Parameters.Add(pName);

            SqlParameter pRegion = new SqlParameter();
            pRegion.ParameterName = "@region";
            pRegion.SqlDbType = System.Data.SqlDbType.Int;
            pRegion.Value = country.Region;
            command.Parameters.Add(pRegion);

            result = command.ExecuteNonQuery();

            transaction.Commit();
            connection.Close();
        }
        catch
        {
            try
            {
                transaction.Rollback();
            }
            catch (Exception exception)
            {
                throw;
            }
        }
        return result;
    }

    // UPDATE COUNTRY
    public int Update(Country country)
    {
        var result = 0;
        var connection = MyContext.GetConnection();
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "UPDATE country SET name = @name, region = @region WHERE id = @id;";
            command.Transaction = transaction;

            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.SqlDbType = System.Data.SqlDbType.VarChar;
            pName.Value = country.Name;
            command.Parameters.Add(pName);

            SqlParameter pRegion = new SqlParameter();
            pRegion.ParameterName = "@region";
            pRegion.SqlDbType = System.Data.SqlDbType.Int;
            pRegion.Value= country.Region;
            command.Parameters.Add(pRegion);

            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = System.Data.SqlDbType.VarChar;
            pId.Value = country.Id;
            command.Parameters.Add(pId);

            result = command.ExecuteNonQuery();

            transaction.Commit();
            connection.Close();
        }
        catch
        {
            try
            {
                transaction.Rollback();
            }
            catch (Exception exception) { throw; }
        }
        return result;
    }

    // DELETE COUNTRY
    public int Delete(string id)
    {
        var result = 0;
        var connection = MyContext.GetConnection();
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "DELETE FROM country WHERE id = @id;";
            command.Transaction = transaction;

            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = System.Data.SqlDbType.VarChar;
            pId.Value = id;
            command.Parameters.Add(pId);

            result = command.ExecuteNonQuery();

            transaction.Commit();
            connection.Close();

        }
        catch
        {
            try
            {
                transaction.Rollback();
            }
            catch (Exception exception)
            {
                throw;
            }
        }
        return result;
    }
}
