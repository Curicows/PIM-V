using PIM_V.Interfaces;

namespace PIM_V.Migrations
{
    public class Migration004 : IIMigration
    {
        private string _sql;

        public Migration004()
        {
            this._sql = "INSERT INTO usuarios (nome, login, senha, email) VALUES ('Administrador', 'admin', '21232f297a57a5a743894a0e4a801fc3', 'admin@admin.com');";
        }
        
        public string GetMigration()
        {
            return this._sql;
        }
    }
}