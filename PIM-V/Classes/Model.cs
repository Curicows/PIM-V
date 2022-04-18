using System.Collections.Generic;
using System.Data;

namespace PIM_V.Classes
{
    public abstract class Model
    {
        private Db _database;
        private long? _id;
        private string _tableName = "";
        private string[] _columns = {};
        private string[] _columnsView = {};

        public Model()
        {
            this._database = new Db();
        }

        public Collection GetAll(bool view = false)
        {
            Collection collection = new Collection();
            collection.FillCollection(this._database.GetAll(this, view), this, view);
            return collection;
        }

        private void Insert()
        {
            long id = this._database.Insert(this);
            this.SetId(id);
        }

        private void Update()
        {
            this._database.Update(this);
        }

        public void Save()
        {
            if (this._id == null)
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
            this._database.Delete(this);
        }

        public void Find(long id)
        {
            this.SetId(id);
            DataTable dataTable = this._database.GetOne(this);
            this.FillModel(dataTable);
        }

        public DataTable CustomSql(string sql, bool insert = false)
        {
            return this._database.CustomSql(sql, insert);
        }

        public string GetTableName()
        {
            return this._tableName;
        }
        
        public void SetTableName(string tableName)
        {
            this._tableName = tableName;
        }

        public string[] GetColumns()
        {
            return this._columns;
        }
        
        public void SetColumns(string[] columns)
        {
            this._columns = columns;
        }
        
        public string[] GetColumnsView()
        {
            return this._columnsView;
        }
        
        public void SetColumnsView(string[] columnsView)
        {
            this._columnsView = columnsView;
        }
        
        public long? GetId()
        {
            return _id;
        }

        public void SetId(long id)
        {
            this._id = id;
        }

        public abstract Dictionary<string, string> ToDict();

        public void FillModel(DataTable dataTable, bool view = false)
        {
            foreach (DataRow dataTableRow in dataTable.Rows)
            {
                this.FillModel(dataTableRow, view);
                break;
            }
        }

        public void FillModel(DataRow dataTable, bool view = false)
        {
            this.SetValues(dataTable.ItemArray, view);
        }

        protected abstract void SetValues(object[] value, bool view = false);
    }
}
