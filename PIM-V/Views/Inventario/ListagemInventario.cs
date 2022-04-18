using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using PIM_V.Classes;
using PIM_V.Models;
using System.Linq;

namespace PIM_V.Views.Inventario
{
    public partial class ListagemInventario : Form
    {
        private Collection _collection;

        public ListagemInventario()
        {
            InitializeComponent();
        }

        private void ListagemEquipamentos_Load(object sender, EventArgs e)
        {
            this.FillList();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            ArrayList selectedRows = this.GetSelectedRow();
            foreach (DataRow row in selectedRows)
            {
                Models.Inventario inventario = new Models.Inventario();
                inventario.Find((long)row[0]);
                inventario.Delete();
            }
            
            this.FillList();
        }

        private ArrayList GetSelectedRow()
        {
            ArrayList selectedRows = new ArrayList();
            int i = 0;
            foreach (DataGridViewCell selectedCell in this.dataGridView1.SelectedCells)
            {
                if (selectedRows.Contains(selectedCell.RowIndex))
                {
                    continue;
                }
                selectedRows.Add(selectedCell.RowIndex);
                i++;
            }


            ArrayList dataRows = new ArrayList();
            foreach (int rowId in selectedRows)
            {
                DataRow row = this._collection.GetDataTable().Rows[rowId];
                dataRows.Add(row);
            }

            return dataRows;
        }

        public void FillList()
        {
            Models.Inventario inventario = new Models.Inventario();
            Collection collection = inventario.GetAll(true);
            this.SetCollection(collection);
            this.dataGridView1.DataSource = collection.GetDataTable();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddInventario addForm = new AddInventario(this);
            addForm.Show();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            ArrayList selectedRows = this.GetSelectedRow();
            if (selectedRows.Count > 1)
            {
                MessageBox.Show("É necessário selecionar somente 1 linha para editar.");
            }
            else
            {
                foreach (DataRow row in selectedRows)
                {
                    EditInventario edit = new EditInventario(this,(long)row[0]);
                    edit.Show();
                    break;
                }
            }
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