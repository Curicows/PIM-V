using System;
using System.Data;
using System.Windows.Forms;
using PIM_V.Classes;
using PIM_V.Models;
using System.Linq;

namespace PIM_V.Views.Equipamentos
{
    public partial class ListagemEquipamentos : Form
    {
        private Collection _collection;
        private AddEquipamentos addForm;

        public ListagemEquipamentos()
        {
            InitializeComponent();
            this.addForm = new AddEquipamentos(this);
        }

        private void ListagemEquipamentos_Load(object sender, EventArgs e)
        {
            this.FillList();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            int[] selectedRows = new int[this.dataGridView1.SelectedCells.Count];
            int i = 0;
            foreach (DataGridViewCell selectedCell in this.dataGridView1.SelectedCells)
            {
                if (selectedRows.Contains(selectedCell.RowIndex))
                {
                    continue;
                }
                selectedRows[i] = selectedCell.RowIndex;
                i++;
            }

            foreach (int rowId in selectedRows)
            {
                if (rowId != 0) {
                    DataRow row = this._collection.GetDataTable().Rows[rowId];
                    Equipamento equipamento = new Equipamento();
                    equipamento.Find((long)row[0]);
                    equipamento.Delete();
                }
            }

            this.FillList();
        }

        public void FillList()
        {
            Equipamento equipamento = new Equipamento();
            Collection collection = equipamento.GetAll(true);
            this.SetCollection(collection);
            this.dataGridView1.DataSource = collection.GetDataTable();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            this.addForm.Show();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
        
        public void SetCollection(Collection collection)
        {
            this._collection = collection;
        }

        public Collection GetCollection()
        {
            return this._collection;
        }
    }
}