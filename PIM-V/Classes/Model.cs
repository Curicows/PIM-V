using System.Collections.Generic;
using System.Data;

namespace PIM_V.Classes
{
    public abstract class Model
    {
        private Db database;
        private long? id;
        private string table_name = "";
        private string[] columns = {};

        public Model()
        {
            this.database = new Db();
        }

        public Collection GetAll()
        {
            Collection collection = new Collection();
            collection.FillCollection(this.database.GetAll(this), this);
            return collection;
        }

        private void Insert()
        {
            long id = this.database.Insert(this);
            this.SetId(id);
        }

        private void Update()
        {
            this.database.Update(this);
        }

        public void Save()
        {
            if (this.id == null)
            {
                this.Insert();
            }
            else
            {
                this.Update();
            }
        }

        public void Delete()
        {
            this.database.Delete(this);
        }

        public void Find(long id)
        {
            this.SetId(id);
            DataTable dataTable = this.database.GetOne(this);
            this.FillModel(dataTable);
        }

        public string GetTableName()
        {
            return this.table_name;
        }
        
        public void SetTableName(string table_name)
        {
            this.table_name = table_name;
        }

        public string[] GetColumns()
        {
            return this.columns;
        }
        
        public void SetColumns(string[] columns)
        {
            this.columns = columns;
        }
        
        public long? GetId()
        {
            return id;
        }

        public void SetId(long id)
        {
            this.id = id;
        }

        public abstract Dictionary<string, string> ToDict();

        public void FillModel(DataTable dataTable)
        {
            foreach (DataRow dataTableRow in dataTable.Rows)
            {
                this.FillModel(dataTableRow);
                break;
            }
        }

        public void FillModel(DataRow dataTable)
        {
            this.SetValues(dataTable.ItemArray);
        }

        protected abstract void SetValues(object[] value);
    }
}
