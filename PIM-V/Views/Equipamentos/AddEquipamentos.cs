using System;
using System.Data;
using System.Windows.Forms;
using PIM_V.Classes;
using PIM_V.Models;
using System.Linq;

namespace PIM_V.Views.Equipamentos
{
    public partial class AddEquipamentos : Form
    {
        private Equipamento _equipamento = new Equipamento();
        private ListagemEquipamentos list;
        
        public AddEquipamentos(ListagemEquipamentos list)
        {
            InitializeComponent();
            this.list = list;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string nome = this.nomeTextBox.Text;
            this._equipamento.SetNome(nome);
            this._equipamento.Save();
            this.list.FillList();
            this.Close();
        }
    }
}