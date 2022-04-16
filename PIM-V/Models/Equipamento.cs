using System.Collections.Generic;
using System.Data;
using PIM_V.Classes;

namespace PIM_V.Models
{
    internal class Equipamento : Model
    {
        public Equipamento()
        {
            this.SetTableName("equipamentos");
            string[] columns =
            {
                "id", "nome"
            };
            this.SetColumns(columns);
        }

        private string nome;

        public string GetNome()
        {
            return nome;
        }

        public void SetNome(string nome)
        {
            this.nome = nome;
        }
        
        public override Dictionary<string, string> ToDict()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("nome",this.GetNome());
            return dict;
        }

        protected override void SetValues(object[] value)
        {
            this.SetId((long)value[0]);
            this.SetNome((string)value[1]);
        }

    }
}
