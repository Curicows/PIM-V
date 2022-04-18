using System;
using System.Windows.Forms;
using PIM_V.Models;
using PIM_V.Views;

namespace PIM_V
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string login = this.loginTextBox.Text;
            string senha = this.senhaTextBox.Text;
            this.Login(login, senha);
        }

        private void Login(string login, string senha)
        {
            Usuario usuario = new Usuario();
            usuario.SetLogin(login);
            usuario.SetSenha(senha, true);
            bool auth = usuario.Authenticate();
            if (auth)
            {
                DashboardForm dashboardForm = new DashboardForm(usuario);
                dashboardForm.Show();
                this.Hide();
            }
        }
    }
}