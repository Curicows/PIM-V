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
        private string _fabricante;
        private string _modelo;
        private string _dataCompra;
        private int _equipamentoId;
        private string _equipamentoNome;
        private Equipamento _equipamento;
        private int _usuarioId;
        private string _usuarioNome;
        private Usuario _usuario;
        
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
            return this._fabricante;
        }

        public void SetFabricante(string fabricante)
        {
            this._fabricante = fabricante;
        }
        
        public string GetModelo()
        {
            return this._modelo;
        }

        public void SetModelo(string modelo)
        {
            this._modelo = modelo;
        }

        public string GetDataCompra()
        {
            return this._dataCompra;
        }

        public void SetDataCompra(string dataCompra)
        {
            this._dataCompra = dataCompra;
        }

        public int GetEquipamentoId()
        {
            return this._equipamentoId;
        }

        public void SetEquipamentoId(int equipamentoId)
        {
            this._equipamentoId = equipamentoId;
        }

        public string GetEquipamentoNome()
        {
            return this._modelo;
        }

        public void SetEquipamentoNome(string modelo)
        {
            this._modelo = modelo;
        }
        
        public int GetUsuarioId()
        {
            return this._usuarioId;
        }

        public void SetUsuarioId(int usuarioId)
        {
            this._usuarioId = usuarioId;
        }
        
        public string GetUsuarioNome()
        {
            return this._modelo;
        }

        public void SetUsuarioNome(string modelo)
        {
            this._modelo = modelo;
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
