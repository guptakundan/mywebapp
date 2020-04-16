using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace MyWebApp.Models
{
	public class MusicStoreContext
	{
		public string ConnectionString { get; set; }

		public MusicStoreContext(string connectionString)
		{
			this.ConnectionString = connectionString;
		}

		private MySqlConnection GetConnection()
		{
			return new MySqlConnection(ConnectionString);
		}

		public List<Album> GetAllAlbums()
		{
			List<Album> list = new List<Album>();
			MySqlCommand cmd=null;

			using (MySqlConnection conn = GetConnection())
			{
				try
				{
					conn.Open();
					cmd = new MySqlCommand("select * from pet", conn);
				}
				catch (Exception)
				{
					list.Add(new Album()
					{
						Id = 1,// Convert.ToInt32(reader["Id"]),
						Name = "Test",
						ArtistName = "Test",
						Price = 200,//Convert.ToInt32(reader["Price"]),
						Genre = "test"
					});
				}
				

				using (var reader = cmd.ExecuteReader())
				{
					if (reader.HasRows)
					{
						while (reader.Read())
						{
							list.Add(new Album()
							{
								Id = 1,// Convert.ToInt32(reader["Id"]),
								Name = reader["Name"].ToString(),
								ArtistName = reader["Owner"].ToString(),
								Price = 200,//Convert.ToInt32(reader["Price"]),
								Genre = Environment.GetEnvironmentVariable("HOSTNAME")//reader["species"].ToString()
							});
						}
					}
					else
					{
						list.Add(new Album()
						{
							Id = 1,// Convert.ToInt32(reader["Id"]),
							Name = "Test",
							ArtistName = "Test",
							Price = 200,//Convert.ToInt32(reader["Price"]),
							Genre = "test"
						});
					}
				}
			}
			return list;
		}
	}
}
