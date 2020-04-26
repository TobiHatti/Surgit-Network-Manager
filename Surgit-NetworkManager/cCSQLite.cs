using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Surgit_NetworkManager
{
    public class CSQLite : IDisposable
    {
        private readonly string conStr = null;

        public SQLiteConnection connection = null;

        public CSQLite(string pDBPath)
        {
            conStr = $@"URI=file:{pDBPath}";
            connection = new SQLiteConnection(conStr);
        }

        public void Dispose()
        {
            connection.Dispose();
        }

        public bool ConnectionTest()
        {
            try
            {
                connection.Open();
                connection.Close();
                return true;
            }
            catch
            {
                return false;
            }   
        }

        #region ExecuteNonQuery

        public void ExecuteNonQuery(string pQuery)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(pQuery, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public void ExecuteNonQueryA(string pQuery)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(pQuery, connection))
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void ExecuteNonQuery(string pQuery, params object[] values)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(pQuery, connection))
            {
                foreach (object parameter in values) cmd.Parameters.AddWithValue("", parameter);
                cmd.ExecuteNonQuery();
            }
        }

        public void ExecuteNonQueryA(string pQuery, params object[] values)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(pQuery, connection))
            {
                foreach (object parameter in values) cmd.Parameters.AddWithValue("", parameter);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        #endregion

        #region ExecuteScalar

        public object ExecuteScalar(string pQuery)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(pQuery, connection))
            {
                object o = cmd.ExecuteScalar();
                return o;
            }
            
        }

        public object ExecuteScalarA(string pQuery)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(pQuery, connection))
            {
                connection.Open();
                object o = cmd.ExecuteScalar();
                connection.Close();
                return o;
            }

        }

        public object ExecuteScalar(string pQuery, params object[] values)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(pQuery, connection))
            {
                foreach (object parameter in values) cmd.Parameters.AddWithValue("", parameter);
                object retval = cmd.ExecuteScalar();
                return retval;
            }
        }

        public object ExecuteScalarA(string pQuery, params object[] values)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(pQuery, connection))
            {
                foreach (object parameter in values) cmd.Parameters.AddWithValue("", parameter);
                connection.Open();
                object retval = cmd.ExecuteScalar();
                connection.Close();
                return retval;
            }
        }

        public DataType ExecuteScalar<DataType>(string pQuery)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(pQuery, connection))
            {
                object retval = cmd.ExecuteScalar();
                return (DataType)Convert.ChangeType(retval, typeof(DataType));
            }
        }

        public DataType ExecuteScalarA<DataType>(string pQuery)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(pQuery, connection))
            {
                connection.Open();
                object retval = cmd.ExecuteScalar();
                connection.Close();
                return (DataType)Convert.ChangeType(retval, typeof(DataType));
            }
        }

        public DataType ExecuteScalar<DataType>(string pQuery, params object[] values)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(pQuery, connection))
            {
                foreach (object parameter in values) cmd.Parameters.AddWithValue("", parameter);
                object retval = cmd.ExecuteScalar();
                return (DataType)Convert.ChangeType(retval, typeof(DataType));
            }
        }

        public DataType ExecuteScalarA<DataType>(string pQuery, params object[] values)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(pQuery, connection))
            {
                foreach (object parameter in values) cmd.Parameters.AddWithValue("", parameter);
                connection.Open();
                object retval = cmd.ExecuteScalar();
                connection.Close();
                return (DataType)Convert.ChangeType(retval, typeof(DataType));
            }
        }

        #endregion


        #region ExecuteQuery

        public SQLiteDataReader ExecuteQuery(string pQuery)
        {
            SQLiteCommand cmd = new SQLiteCommand(pQuery, connection);
            return cmd.ExecuteReader();
        }

        public SQLiteDataReader ExecuteQuery(string pQuery, params object[] values)
        {
            SQLiteCommand cmd = new SQLiteCommand(pQuery, connection);
            foreach (object parameter in values) cmd.Parameters.AddWithValue("", parameter);
            return cmd.ExecuteReader();
        }

        public DataTable CreateDT(string sql)
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        #endregion
    }

}
