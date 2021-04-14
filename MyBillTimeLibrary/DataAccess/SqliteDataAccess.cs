using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBillTimeLibrary.DataAccess
{
	public class SqliteDataAccess
	{
		// LoadData<PersonModel>("Select * from Person", null) = List<PersonModel>
		public static List<T> LoadData<T>(string sqlStatement, Dictionary<string, object> parameters, string connectionName = "Default")
		{
			DynamicParameters p = new DynamicParameters();
			parameters.ToList().ForEach(x => p.Add(x.Key, x.Value));
			using (IDbConnection cnn = new SQLiteConnection(DataAccessHelpers.LoadConnectionString(connectionName))) 
			{
				var rows = cnn.Query<T>(sqlStatement, p);

				return rows.ToList();
			}
		}
	}
}
