using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using PIM_V.Classes;
using PIM_V.Helpers;

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
                "id", "nome", "login", "email", "senha"
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

        public void SetSenha(string senha, bool md5 = false) 
        {
            if (md5)
            {
                Md5Helper md5Helper = new Md5Helper();
                this._senha = md5Helper.RetornarMd5(senha);
            }
            else
            {
                this._senha = senha;
            }
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
            dict.Add("email",this.GetEmail());
            dict.Add("senha",this.GetSenha());
            return dict;
        }

        protected override void SetValues(object[] value, bool view = false)
        {
            if (value[2] == DBNull.Value)
            {
            }
            this.SetId((long)value[0]);
            this.SetNome((string)value[1]);
            this.SetLogin((string)value[2]);
            this.SetEmail((string)value[3]);
            if (!view)
            {
                this.SetSenha((string)value[4]);
            }
        }

        public bool Authenticate()
        {
            DataTable dataTable = this.GetUsuarioAuth();
            Usuario user = new Usuario();
            if (dataTable.Rows.Count > 0)
            {
                user.FillModel(dataTable);
                if (user.GetSenha() == this.GetSenha())
                {
                    return true;
                }
                MessageBox.Show("Senha incorreta!");
                return false;
            }
            MessageBox.Show("Usuário não encontrado!");
            return false;
        }

        private DataTable GetUsuarioAuth()
        {
            string sql = $"select id, nome, login, email, senha from usuarios where login = '{this.GetLogin()}'";
            return this.CustomSql(sql);
        }
    }
}