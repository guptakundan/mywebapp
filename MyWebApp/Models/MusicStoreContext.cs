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

			using (MySqlConnection conn = GetConnection())
			{
				conn.Open();
				MySqlCommand cmd = new MySqlCommand("select * from pet", conn);

				using (var reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						list.Add(new Album()
						{
							Id = 1,// Convert.ToInt32(reader["Id"]),
							Name = reader["Name"].ToString(),
							ArtistName = reader["Owner"].ToString(),
							Price = 200,//Convert.ToInt32(reader["Price"]),
							Genre = reader["species"].ToString()
						});
					}
				}
			}
			return list;
		}
	}
}
