using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PIM_V.Models;
using PIM_V.Views.Equipamentos;
using PIM_V.Views.Inventario;
using PIM_V.Views.Usuarios;

namespace PIM_V.Views
{
    public partial class DashboardForm : Form
    {
        private Usuario _usuario;
        public DashboardForm(Usuario usuario)
        {
            InitializeComponent();
            this._usuario = usuario;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListagemEquipamentos equipamentos = new ListagemEquipamentos();
            equipamentos.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListagemUsuarios usuarios = new ListagemUsuarios();
            usuarios.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ListagemInventario inventario = new ListagemInventario();
            inventario.Show();
        }

        private void DashboardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}