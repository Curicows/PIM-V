using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace PIM_V.Classes
{
    public class Db
    {
        private SQLiteConnection _sqliteConnection;

        private SQLiteConnection DbConnection()
        {
            string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string directoryPath = System.IO.Path.GetDirectoryName(exePath);
            directoryPath = directoryPath.Replace("\\bin\\Debug","");
            string dataSource = $"{directoryPath}\\database.sqlite";
        
            _sqliteConnection = new SQLiteConnection($"Data Source={dataSource}; Version=3;");
            _sqliteConnection.Open();
            return _sqliteConnection;
        }

        public DataTable GetAll(Model model)
        {
            string table = model.GetTableName();
            string[] columns = model.GetColumns();
            string columnsString = this.ToColumnsString(columns);
            SQLiteDataAdapter da;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = $"SELECT {columnsString} FROM {table}";
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        
        public DataTable GetOne(Model model)
        {
            string table = model.GetTableName();
            string[] columns = model.GetColumns();
            long? id = model.GetId();
            string columnsString = this.ToColumnsString(columns);
            SQLiteDataAdapter da;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = $"SELECT {columnsString} FROM {table} Where id=" + id;
                    da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        
        public long Insert(Model model)
        {
            string table = model.GetTableName();
            string columnsString = this.ToColumnsString(model.GetColumns(),true);
            Dictionary<string, string> dict = model.ToDict();
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    string sql = $"INSERT INTO {table}({columnsString}) values (";
                    int i = 0;
                    foreach (KeyValuePair<string,string> value in dict)
                    {
                        string name = $"@{value.Key}";
                        if (i == 0)
                        {
                            sql += name;
                        }
                        else
                        {
                            sql += $",{name}";
                        }
                        cmd.Parameters.AddWithValue(name, value.Value);
                        i++;
                    }
                    sql += ")";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    return cmd.Connection.LastInsertRowId;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        
        public void Update(Model model)
        {
            string table = model.GetTableName();
            long? id = model.GetId();
            Dictionary<string, string> dict = model.ToDict();
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    if (id != null )
                    {
                        string sql = $"UPDATE {table} SET ";
                        int i = 0;
                        foreach (KeyValuePair<string,string> value in dict)
                        {
                            string name = $"@{value.Key}";
                            if (i == 0)
                            {
                                sql += $"{value.Key}={name}";
                            }
                            else
                            {
                                sql += $",{value.Key}={name}";
                            }
                            cmd.Parameters.AddWithValue(name, value.Value);
                            i++;
                        }
                        sql += " WHERE id=@id";
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                };
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        
        public void Delete(Model model)
        {
            string table = model.GetTableName();
            long? id = model.GetId();
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    if (id != null)
                    {
                        cmd.CommandText = $"DELETE FROM {table} Where id=@id";
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public string ToColumnsString(string[] columns, bool isInsert = false)
        {
            string text = "";
            int i = 0;
            foreach (string column in columns)
            {
                if (isInsert && column == "id")
                {
                    continue;
                }
                if (i == 0)
                {
                    text += column;
                }
                else
                {
                    text += $",{column}";
                }
                i++;
            }

            return text;
        }
    }
}