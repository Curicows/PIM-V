using System;
using System.Data;
using System.Windows.Forms;
using PIM_V.Classes;
using PIM_V.Models;
using System.Linq;
using PIM_V.Helpers;
using PIM_V.Views.Usuarios;

namespace PIM_V.Views.Inventario
{
    public partial class AddInventario : Form
    {
        private Models.Inventario _inventario = new Models.Inventario();
        private ListagemInventario list;
        private Collection _collectionEquipamento;
        private Collection _collectionUsuario;

        public AddInventario(ListagemInventario list)
        {
            InitializeComponent();
            this.list = list;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string fabricante = this.fabricanteTextBox.Text;
            string modelo = this.modeloTextBox.Text;
            string dataCompra = this.dataTextBox.Text;
            string dataReserva = this.textBox1.Text;
            Equipamento selectedEqui = this.GetSelectedComboEquipamento();
            Usuario selectedUsu = this.GetSelectedComboUsuario();

            this._inventario.SetFabricante(fabricante);
            this._inventario.SetModelo(modelo);
            this._inventario.SetDataCompra(dataCompra);
            this._inventario.SetEquipamentoNome(selectedEqui.GetNome());
            this._inventario.SetEquipamentoId((long)selectedEqui.GetId());
            this._inventario.SetUsuarioNome(selectedUsu.GetNome());
            this._inventario.SetUsuarioId((long)selectedUsu.GetId());
            this._inventario.SetDataReserva(dataReserva);
            this._inventario.Save();
            this.GetSelectedComboEquipamento();
            this.list.FillList();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void AddInventario_Load(object sender, EventArgs e)
        {
            this.FillCombo();
        }

        private void FillCombo()
        {
            Equipamento equipamento = new Equipamento();
            this._collectionEquipamento = equipamento.GetAll();
            foreach (Equipamento model in this._collectionEquipamento.GetModels())
            {
                int cnt = comboBox1.Items.Count;
                comboBox1.Items.Insert(cnt, model.GetNome());
            }
            
            Usuario usuario = new Usuario();
            this._collectionUsuario = usuario.GetAll();
            foreach (Usuario model in this._collectionUsuario.GetModels())
            {
                int cnt2 = comboBox2.Items.Count;
                comboBox2.Items.Insert(cnt2, model.GetNome());
            }
        }

        private Equipamento GetSelectedComboEquipamento()
        {
            string selectedText = comboBox1.Items[this.comboBox1.SelectedIndex].ToString();
            foreach (Equipamento equipamento in this._collectionEquipamento.GetModels())
            {
                if (selectedText == equipamento.GetNome())
                {
                    return equipamento;
                }
            }
            return null;
        }
        
        private Usuario GetSelectedComboUsuario()
        {
            string selectedText = comboBox2.Items[this.comboBox2.SelectedIndex].ToString();
            foreach (Usuario usuario in this._collectionUsuario.GetModels())
            {
                if (selectedText == usuario.GetNome())
                {
                    return usuario;
                }
            }
            return null;
        }
    }
}