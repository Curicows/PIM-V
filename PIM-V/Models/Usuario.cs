using System.Collections.Generic;
using PIM_V.Classes;

namespace PIM_V.Models
{
    public class Usuario: Model
    {
        private string nome;
        private string login;
        private string senha;
        private string email;

        public Usuario()
        {
            this.SetTableName("usuarios");
            string[] columns =
            {
                "id", "nome", "login", "senha", "email"
            };
            this.SetColumns(columns);
        }
        
        public string GetNome()
        {
            return this.nome;
        } 
        
        public string GetLogin()
        {
            return this.login;
        } 
        
        public string GetSenha()
        {
            return this.senha;
        } 
        
        public string GetEmail()
        {
            return this.email;
        } 
        
        public void SetNome(string nome) 
        {
            this.nome = nome;
        }

        public void SetLogin(string login) 
        {
            this.login = login;
        }

        public void SetSenha(string senha) 
        {
            this.senha = senha;
        }

        public void SetEmail(string email) 
        {
            this.email = email;
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

        protected override void SetValues(object[] value)
        {
            this.SetId((long)value[0]);
            this.SetNome((string)value[1]);
            this.SetLogin((string)value[2]);
            this.SetSenha((string)value[3]);
            this.SetEmail((string)value[4]);
        }
    }
}