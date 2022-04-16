using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIM_V.Classes;

namespace PIM_V.Models
{
    internal class Inventario : Model
    {
        private string fabricante;
        private string modelo;
        private string dataCompra;
        private int equipamentoId;
        
        public Inventario()
        {
            this.SetTableName("inventario");
            string[] columns =
            {
                "id", "fabricante", "modelo", "data_compra", "equipamento_id"
            };
            this.SetColumns(columns);
        }

        public string GetFabricante()
        {
            return this.fabricante;
        }

        public void SetFabricante(string fabricante)
        {
            this.fabricante = fabricante;
        }
        
        public string GetModelo()
        {
            return this.modelo;
        }

        public void SetModelo(string modelo)
        {
            this.modelo = modelo;
        }

        public string GetDataCompra()
        {
            return this.dataCompra;
        }

        public void SetDataCompra(string dataCompra)
        {
            this.dataCompra = dataCompra;
        }

        public int GetEquipamentoId()
        {
            return this.equipamentoId;
        }

        public void SetEquipamentoId(int equipamentoId)
        {
            this.equipamentoId = equipamentoId;
        }

        public override Dictionary<string, string> ToDict()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("fabricante",this.GetFabricante());
            dict.Add("modelo",this.GetModelo());
            dict.Add("data_compra",this.GetDataCompra());
            dict.Add("equipamento_id",this.GetEquipamentoId().ToString());
            return dict;
        }

        protected override void SetValues(object[] value)
        {
            this.SetId((long)value[0]);
            this.SetFabricante((string)value[1]);
            this.SetModelo((string)value[2]);
            this.SetDataCompra((string)value[3]);
            this.SetEquipamentoId((int)value[4]);
        }
    }
}
