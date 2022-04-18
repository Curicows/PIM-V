

using PIM_V.Interfaces;
using PIM_V.Migrations;

namespace PIM_V.Classes
{
    public class Migration
    {
        private Db _database;
        private readonly IIMigration[] _migrations = {new Migration001(), new Migration002(), new Migration003(), new Migration004()};

        public void Migrate()
        {
            this._database = new Db();
            foreach (IIMigration migration in _migrations)
            {
                string sql = migration.GetMigration();
                this._database.CustomSql(sql,true);
            }
        }

    }
}