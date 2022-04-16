using System.Collections.Generic;
using PIM_V.Classes;

namespace PIM_V.Models
{
    public class Reserva : Model
    {
        private string dataReserva;
        private int inventarioId;
        private int usuarioId;
        
        public Reserva()
        {
            this.SetTableName("reservas");
            string[] columns =
            {
                "id", "data_reserva", "inventario_id", "usuario_id"
            };
            this.SetColumns(columns);
        }
        
        public string GetDataReserva()
        {
            return this.dataReserva;
        }

        public void SetDataReserva(string dataCompra)
        {
            this.dataReserva = dataCompra;
        }
        
        public int GetInventarioId()
        {
            return this.inventarioId;
        }

        public void SetInventarioId(int inventarioId)
        {
            this.inventarioId = inventarioId;
        }
        
        public int GetUsuarioId()
        {
            return this.usuarioId;
        }

        public void SetUsuarioId(int usuarioId)
        {
            this.usuarioId = usuarioId;
        }
        
        public override Dictionary<string, string> ToDict()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("data_reserva",this.GetDataReserva());
            dict.Add("inventario_id",this.GetInventarioId().ToString());
            dict.Add("usuario_id", this.GetUsuarioId().ToString());
            return dict;
        }

        protected override void SetValues(object[] value)
        {
            this.SetId((long)value[0]);
            this.SetDataReserva((string)value[1]);
            this.SetInventarioId((int)value[2]);
            this.SetUsuarioId((int)value[3]);
        }
    }
}