using System;
using System.Data;
using System.Windows.Forms;
using PIM_V.Classes;
using PIM_V.Models;
using System.Linq;
using PIM_V.Helpers;
using PIM_V.Views.Usuarios;

namespace PIM_V.Views.Usuarios
{
    public partial class AddUsuarios : Form
    {
        private Usuario _usuario = new Usuario();
        private ListagemUsuarios list;
        
        public AddUsuarios(ListagemUsuarios list)
        {
            InitializeComponent();
            this.list = list;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string nome = this.nomeTextBox.Text;
            string login = this.loginTextBox.Text;
            string email = this.emailTextBox.Text;
            string senha = this.senhaTextBox.Text;

            this._usuario.SetNome(nome);
            this._usuario.SetLogin(login);
            this._usuario.SetEmail(email);
            this._usuario.SetSenha(senha, true);
            
            this._usuario.Save();
            
            this.list.FillList();
            this.Close();
        }
    }
}