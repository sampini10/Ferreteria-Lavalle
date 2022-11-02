using System.Collections.Generic;
using System.Data;
using System.Text;
using System;
using Microsoft.Data.SqlClient;

namespace BE_Ferreteria.Data
{
    public class SqlHelper : IConnection, IDisposable
    {
        private readonly SqlConnection _connection;

        public SqlHelper(string sConectionString)
        {
            _connection = new SqlConnection(sConectionString);
        }

        public void ExecuteNonQuery(IDbCommand cmd)
        {
            cmd.Connection = _connection;
            _connection.Open();
            cmd.ExecuteNonQuery();
            _connection.Close();
        }

        public IDataReader ExecuteReader(IDbCommand cmd)
        {
            cmd.Connection = _connection;
            _connection.Open();
            cmd.CommandTimeout = 120;
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public T GetDataItem<T>(IDbCommand cmd)
        {
            T oObject = default(T);

            IDataReader reader = ExecuteReader(cmd);
            oObject = (T)(typeof(T).IsValueType ? Activator.CreateInstance(typeof(T)) : null);
            try
            {
                if (reader.Read())
                {
                    oObject = reader.ToObject<T>();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message.ToString());
            }
            finally
            {
                reader.Close();
            }

            return oObject;
        }

        public List<T> GetDataList<T>(IDbCommand cmd)
        {
            List<T> lst = new List<T>();

            IDataReader reader = ExecuteReader(cmd);
            try
            {
                while (reader.Read())
                {
                    T item = reader.ToObject<T>();
                    if (item != null)
                    {
                        lst.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.InnerException.ToString());
            }
            finally
            {
                reader.Close();
            }

            return lst;
        }

        public StringBuilder GetDataListJson<T>(IDbCommand cmd)
        {
            var jsonResult = new StringBuilder();

            IDataReader reader = ExecuteReader(cmd);
            try
            {
                while (reader.Read())
                {
                    jsonResult.Append(reader.GetValue(0).ToString());
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.InnerException.ToString());
            }
            finally
            {
                reader.Close();
            }

            return jsonResult;
        }

        public void Dispose()
        {
            if (_connection != null)
            {
                if (_connection.State != ConnectionState.Closed)
                {
                    _connection.Close();
                }
                _connection.Dispose();
            }
        }

    }
}
