using PIM_V.Interfaces;

namespace PIM_V.Migrations
{
    public class Migration003 : IIMigration
    {
        private string _sql;

        public Migration003()
        {
            this._sql = "create table IF NOT EXISTS usuarios(id integer constraint usuarios_pk primary key autoincrement, nome  varchar(255),login varchar(255),senha varchar(255),email varchar(255))";
        }
        
        public string GetMigration()
        {
            return this._sql;
        }
    }
}