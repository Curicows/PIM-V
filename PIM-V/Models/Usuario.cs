using System.Collections.Generic;
using PIM_V.Classes;

namespace PIM_V.Models
{
    public class Usuario: Model
    {
        private string _nome;
        private string _login;
        private string _senha;
        private string _email;

        public Usuario()
        {
            this.SetTableName("usuarios");
            string[] columns =
            {
                "id", "nome", "login", "senha", "email"
            };
            string[] columnsView =
            {
                "id", "nome", "login", "email"
            };
            this.SetColumns(columns);
            this.SetColumnsView(columnsView);
        }
        
        public string GetNome()
        {
            return this._nome;
        } 
        
        public string GetLogin()
        {
            return this._login;
        } 
        
        public string GetSenha()
        {
            return this._senha;
        } 
        
        public string GetEmail()
        {
            return this._email;
        } 
        
        public void SetNome(string nome) 
        {
            this._nome = nome;
        }

        public void SetLogin(string login) 
        {
            this._login = login;
        }

        public void SetSenha(string senha) 
        {
            this._senha = senha;
        }

        public void SetEmail(string email) 
        {
            this._email = email;
        }

        public override Dictionary<string, string> ToDict()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("nome",this.GetNome());
            dict.Add("login",this.GetLogin());
            dict.Add("senha",this.GetSenha());
            dict.Add("email",this.GetEmail());
            return dict;
        }

        protected override void SetValues(object[] value, bool view = false)
        {
            this.SetId((long)value[0]);
            this.SetNome((string)value[1]);
            this.SetLogin((string)value[2]);
            this.SetSenha((string)value[3]);
            this.SetEmail((string)value[4]);
        }
    }
}