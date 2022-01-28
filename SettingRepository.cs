using Sa7kaWin.DataAccess;
using Sa7kaWin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sa7kaWin
{
    public class SettingRepository
    {
        private readonly SQLiteDataAccess _sqliteDataAccess;

        public SettingRepository()
        {
            _sqliteDataAccess = new SQLiteDataAccess();
        }

        public async Task<SettingInfo> GetSettings()
        {
            string query = @"SELECT * FROM Settings";

            var result = await _sqliteDataAccess.QueryAsync<SettingInfo>(query);
            return result.FirstOrDefault();
        }
        public async Task<int> InsertSettings(SettingInfo settings)
        {
            string command = @"INSERT INTO Settings (
                         OnStartUp,
                         KeyModifier1,
                         Key1,
                         KeyModifier2,
                         Key2,
                         KeyModifier3,
                         Key3
                     )
                     VALUES (
                         @OnStartUp,
                         @KeyModifier1,
                         @Key1,
                         @KeyModifier2,
                         @Key2,
                         @KeyModifier3,
                         @Key3
                     );
                     SELECT 1;";

            return await _sqliteDataAccess.ExecuteScalarAsync<int>(command,settings);
        }
        public async Task<int> UpdateSettings(SettingInfo settings)
        {
            string command = @"UPDATE Settings SET
                         OnStartUp = @OnStartUp,
                         KeyModifier1 = @KeyModifier1,
                         Key1 = @Key1,
                         KeyModifier2 = @KeyModifier2,
                         Key2 = @Key2,
                         KeyModifier3 = @KeyModifier3,
                         Key3 = @Key3;
                     SELECT 1;";

            return await _sqliteDataAccess.ExecuteScalarAsync<int>(command,settings);
        }

    }
}
