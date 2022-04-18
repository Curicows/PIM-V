using System;
using System.Data;
using System.Windows.Forms;
using PIM_V.Classes;
using PIM_V.Models;
using System.Linq;

namespace PIM_V.Views.Equipamentos
{
    public partial class EditEquipamentos : Form
    {
        private Equipamento _equipamento = new Equipamento();
        private ListagemEquipamentos list;
        private long? id;
        
        public EditEquipamentos(ListagemEquipamentos list, long id)
        {
            InitializeComponent();
            this.list = list;
            this._equipamento.Find(id);
            this.id = id;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            string nome = this.nomeTextBox.Text;
            this._equipamento.SetNome(nome);
            this._equipamento.Save();
            this.list.FillList();
            this.Hide();
        }

        private void EditEquipamentos_Load(object sender, EventArgs e)
        {
            nomeTextBox.Text = this._equipamento.GetNome();
        }
    }
}