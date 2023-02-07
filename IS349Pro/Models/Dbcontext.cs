using System;
using System.Data;
using Microsoft.Data.SqlClient;
namespace IS349Pro.Models;


public class Dbcontext
{
	private readonly SqlConnection _connection;
	public Dbcontext()
	{
		string conString = @"Server=localhost;Database=IS349HR23;
		User Id=sa;Password=Strong.Pwd-123;TrustServerCertificate=true;";
		_connection = new SqlConnection(conString);
	}
	public SqlDataReader ReadData(string sql)
	{
		using(SqlCommand cmd=new SqlCommand(sql, _connection))
		{
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
            return cmd.ExecuteReader();
		}
	}
	public int IsExist(string sql)
	{
		using(SqlCommand cmd=new SqlCommand(sql, _connection))
		{
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
            var result = cmd.ExecuteScalar();
            return int.Parse(result.ToString());
		}
	}
	public bool ExecuteQuery(string sql)
	{
        using (SqlCommand cmd = new SqlCommand(sql, _connection))
        {
			try
			{
				if (_connection.State == ConnectionState.Closed)
				{
					_connection.Open();
				}
                cmd.ExecuteNonQuery();
                return true;
			}
			catch
			{
				return false;
			}
           
        }
    }
}

