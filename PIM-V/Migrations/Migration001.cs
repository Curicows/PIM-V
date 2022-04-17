using PIM_V.Interfaces;

namespace PIM_V.Migrations
{
    public class Migration001 : IIMigration
    {
        private string _sql;

        public Migration001()
        {
            this._sql = "create table IF NOT EXISTS equipamentos ( id integer constraint equipamentos_pk primary key autoincrement, nome varchar(255) not null )";
        }
        
        public string GetMigration()
        {
            return this._sql;
        }
    }
}