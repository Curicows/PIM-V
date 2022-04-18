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
    public partial class EditUsuarios : Form
    {
        private Usuario _usuario = new Usuario();
        private ListagemUsuarios list;
        private long? id;

        public EditUsuarios(ListagemUsuarios list, long id)
        {
            InitializeComponent();
            this.list = list;
            this._usuario.Find(id);
            this.id = id;
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

        private void EditUsuarios_Load(object sender, EventArgs e)
        {
            this.nomeTextBox.Text = this._usuario.GetNome();
            this.loginTextBox.Text = this._usuario.GetLogin();
            this.emailTextBox.Text = this._usuario.GetEmail();
        }
    }
}