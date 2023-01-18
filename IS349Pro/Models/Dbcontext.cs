using System;
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
			_connection.Open();
			return cmd.ExecuteReader();
		}
	}
}

