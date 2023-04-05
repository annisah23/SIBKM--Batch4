using System.Data.SqlClient;

namespace MVC.Contexts;

public class MyContext
{
    private static SqlConnection connection;
    private static string connectionString = "Data Source=LAPTOP-8Q6E3BE3;Initial Catalog=db_hr_sibkm;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

    public static SqlConnection GetConnection()
    {
        try
        {
            connection = new SqlConnection(connectionString);
        } catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return connection;
    }
}
