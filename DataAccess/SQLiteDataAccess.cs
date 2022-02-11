using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sa7kaWin.DataAccess
{
    public class SQLiteDataAccess
    {
        private const string _DatabaseFileName = "\\Sa7ka.db";
        private string ConnectionString()
        {
            return @"Data Source=" + Application.StartupPath + _DatabaseFileName
                + "; Version=3; UTF8Encoding=True; Pooling=True; Max Pool Size=100; FailIfMissing=True; Cache=Shared;";
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, DynamicParameters parameters = null,
            IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString()))
            {
                return await connection.QueryAsync<T>(sql, parameters, transaction, commandTimeout, commandType);
            }
        }
        public async Task<int> ExecuteAsync(string sql, DynamicParameters parameters = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString()))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                using (var trans = connection.BeginTransaction())
                {
                    var result = await connection.ExecuteAsync(sql, parameters, trans, commandTimeout, commandType);
                    trans.Commit();
                    return result;
                }
            }
        }
        public async Task<T> ExecuteScalarAsync<T>(string sql, DynamicParameters parameters)
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString()))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                using (var trans = connection.BeginTransaction())
                {
                    var result = await connection.ExecuteScalarAsync<T>(sql, parameters, trans);
                    trans.Commit();
                    return result;
                }
            }
        }

    }
}
