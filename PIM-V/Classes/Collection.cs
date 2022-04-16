using System;
using System.Data;

namespace PIM_V.Classes
{
    public class Collection
    {
        private Model[] models;
        private DataTable _dataTable;

        public void SetModels(Model[] models)
        {
            this.models = models;
        }

        public Model[] GetModels()
        {
            return this.models;
        }
        
        public void SetDataTable(DataTable dataTable)
        {
            this._dataTable = dataTable;
        }

        public DataTable GetDataTable()
        {
            return this._dataTable;
        }

        public void FillCollection(DataTable table, Model model)
        {
            this.SetDataTable(table);
            Model[] models = new Model[table.Rows.Count];
            int i = 0;
            foreach (DataRow tableRow in table.Rows)
            {
                Model del = (Model)Activator.CreateInstance(model.GetType());
                del.FillModel(tableRow);
                models[i] = del;
                i++;
            }
            this.SetModels(models);
        }
    }
}