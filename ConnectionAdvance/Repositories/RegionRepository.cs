using MVC.Contexts;
using MVC.Models;
using MVC.Repositories.Interfaces;
using System.Data.SqlClient;

namespace MVC.Repositories;

public class RegionRepository : IRegionRepository
{
    // GET ALL REGION
    public List<Region> GetAll()
    {
        List<Region> regions = new List<Region>();

        // Membuat Instance Sql Server Connection
        var connection = MyContext.GetConnection();

        // Membuat instance Sql Command
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT * FROM region;";

        connection.Open();
        using SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            while(reader.Read())
            {
                // alt 1
                /*Region region = new Region();
                region.Id = reader.GetInt32(0);
                region.Name = reader.GetString(1);*/

                // alt 2
                /*Region region = new Region {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                };
                regions.Add(region);*/

                regions.Add(new Region()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                });
            }
        }
        else
        {
            return null;
        }
        reader.Close();
        connection.Close();

        return regions;
    }

    // GET REGION BY ID
    public Region GetById(int id)
    {
        Region region = new Region();
        var connection = MyContext.GetConnection();

        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT * FROM region WHERE id = @id;";

        SqlParameter pId = new SqlParameter();
        pId.ParameterName = "@id";
        pId.SqlDbType = System.Data.SqlDbType.Int;
        pId.Value = id;
        command.Parameters.Add(pId);

        connection.Open();
        using SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            reader.Read();

            region.Id = reader.GetInt32(0);
            region.Name = reader.GetString(1);
        }
        else
        {
            return null;
        }
        reader.Close();
        connection.Close();
        
        return region;
    }

    // INSERT REGION
    public int Insert(Region region)
    {
        var result = 0;
        var connection = MyContext.GetConnection();
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "INSERT INTO Region (name) VALUES (@name);";
            command.Transaction = transaction;

            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.SqlDbType = System.Data.SqlDbType.VarChar;
            pName.Value = region.Name;
            command.Parameters.Add(pName);

            result = command.ExecuteNonQuery();

            transaction.Commit();
            connection.Close();
        }
        catch
        {
            try
            {
                transaction.Rollback();
            } catch (Exception exception)
            {
                throw;
            }
        }
        return result;
    }

    // UPDATE REGION
    public int Update(Region region)
    {
        var result = 0;
        var connection = MyContext.GetConnection();
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "UPDATE region SET name = @name WHERE id = @id;";
            command.Transaction = transaction;

            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.SqlDbType = System.Data.SqlDbType.VarChar;
            pName.Value = region.Name;
            command.Parameters.Add(pName);

            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = System.Data.SqlDbType.Int;
            pId.Value = region.Id;
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

    // DELETE REGION
    public int Delete(int id)
    {
        var result = 0;
        var connection = MyContext.GetConnection();
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "DELETE FROM region WHERE id = @id;";
            command.Transaction = transaction;

            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = System.Data.SqlDbType.Int;
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
