using PIM_V.Interfaces;

namespace PIM_V.Migrations
{
    public class Migration002 : IIMigration
    {
        private string _sql;

        public Migration002()
        {
            this._sql = "create table inventario (id integer constraint inventario_pk primary key autoincrement, fabricante varchar(255), modelo varchar(255), data_compra varchar(255), equipamento_id   UNSIGNED BIG INT references equipamentos, data_reserva varchar(255), usuario_id unsigned big int references usuarios, nome_equipamento varchar(255), nome_usuario varchar(255))";
        }
        
        public string GetMigration()
        {
            return this._sql;
        }
    }
}