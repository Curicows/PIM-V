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
        private string _dataReserva;
        private long? _equipamentoId;
        private string _equipamentoNome;
        private Equipamento _equipamento = new Equipamento();
        private long? _usuarioId;
        private string _usuarioNome;
        private Usuario _usuario = new Usuario();
        
        public Inventario()
        {
            this.SetTableName("inventario");
            string[] columns =
            {
                "id", "fabricante", "modelo", "data_compra", "data_reserva", "nome_equipamento", "nome_usuario", "equipamento_id", "usuario_id"
            };
            string[] columnsView =
            {
                "id", "fabricante", "modelo", "data_compra", "data_reserva", "nome_equipamento", "nome_usuario"
            };
            this.SetColumns(columns);
            this.SetColumnsView(columnsView);
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

        public string GetDataReserva()
        {
            return this._dataReserva;
        }

        public void SetDataReserva(string dataReserva)
        {
            this._dataReserva = dataReserva;
        }

        public long? GetEquipamentoId()
        {
            return this._equipamentoId;
        }

        public void SetEquipamentoId(int equipamentoId)
        {
            this._equipamentoId = equipamentoId;
        }

        public string GetEquipamentoNome()
        {
            return this._equipamentoNome;
        }

        public void SetEquipamentoNome(string equipamentoNome)
        {
            this._equipamentoNome = equipamentoNome;
        }
        
        public Equipamento GetEquipamento()
        {
            return this._equipamento;
        }
        
        private void SetEquipamento()
        {
            if (this._equipamentoId != null)
            {
                this._equipamento.Find((long)this._equipamentoId);
            }       
        }
        
        public long? GetUsuarioId()
        {
            return this._usuarioId;
        }

        public void SetUsuarioId(int usuarioId)
        {
            this._usuarioId = usuarioId;
        }
        
        public string GetUsuarioNome()
        {
            return this._usuarioNome;
        }

        public void SetUsuarioNome(string usuarioNome)
        {
            this._usuarioNome = usuarioNome;
        }
        
        public Usuario GetUsuario()
        {
            return this._usuario;
        }
        
        private void SetUsuario()
        {
            if (this._usuarioId != null)
            {
                this._usuario.Find((long)this._usuarioId);
            }       
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

        protected override void SetValues(object[] value, bool view = false)
        {
            this.SetId((long)value[0]);
            this.SetFabricante((string)value[1]);
            this.SetModelo((string)value[2]);
            this.SetDataCompra((string)value[3]);
            this.SetDataReserva((string)value[4]);
            this.SetEquipamentoNome((string)value[5]);
            this.SetUsuarioNome((string)value[6]);
            if (!view)
            {
                this.SetEquipamentoId((int)value[7]);
                this.SetEquipamento();
                this.SetUsuarioId((int)value[8]);
                this.SetUsuario();
            }
        }
    }
}
