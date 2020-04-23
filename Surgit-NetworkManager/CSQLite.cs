using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Surgit_NetworkManager
{
    public class CSQLite
    {
        private string conStr = null;

        public SQLiteConnection connection = null;
        public SQLiteCommand cmd = null;

        public CSQLite(string pDBPath)
        {
            conStr = $@"URI=file:{pDBPath}";
            connection = new SQLiteConnection(conStr);
            cmd = new SQLiteCommand(connection);
        }

        #region ExecuteNonQuery

        public void ExecuteNonQuery(string pQuery)
        {
            cmd.CommandText = pQuery;
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void ExecuteNonQuery(string pQuery, params object[] values)
        {
            cmd.CommandText = pQuery;
            foreach (object parameter in values) cmd.Parameters.AddWithValue("", parameter);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        #endregion

        #region ExecuteScalar

        public object ExecuteScalar(string pQuery)
        {
            cmd.CommandText = pQuery;
            connection.Open();
            object o = cmd.ExecuteScalar();
            connection.Close();
            return o;
        }

        public object ExecuteScalar(string pQuery, params object[] values)
        {
            cmd.CommandText = pQuery;
            foreach (object parameter in values) cmd.Parameters.AddWithValue("", parameter);
            connection.Open();
            object retval = cmd.ExecuteScalar();
            connection.Close();
            return retval;
        }

        public DataType ExecuteScalar<DataType>(string pQuery)
        {
            cmd.CommandText = pQuery;
            connection.Open();
            object retval = cmd.ExecuteScalar();
            connection.Close();
            return (DataType)Convert.ChangeType(retval, typeof(DataType));
        }

        public DataType ExecuteScalar<DataType>(string pQuery, params object[] values)
        {
            cmd.CommandText = pQuery;
            foreach (object parameter in values) cmd.Parameters.AddWithValue("", parameter);
            connection.Open();
            object retval = cmd.ExecuteScalar();
            connection.Close();
            return (DataType)Convert.ChangeType(retval, typeof(DataType));
        }

        #endregion


        #region ExecuteQuery

        public SQLiteDataReader ExecuteQuery(string pQuery)
        {
            cmd.CommandText = pQuery;
            return cmd.ExecuteReader();
        }

        public SQLiteDataReader ExecuteQuery(string pQuery, params object[] values)
        {
            cmd.CommandText = pQuery;
            foreach (object parameter in values) cmd.Parameters.AddWithValue("", parameter);
            return cmd.ExecuteReader();
        }

        #endregion
    }

}
