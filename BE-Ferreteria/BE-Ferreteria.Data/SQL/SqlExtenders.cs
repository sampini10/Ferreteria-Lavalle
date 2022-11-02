using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace BE_Ferreteria.Data
{
    public static class SqlExtenders
    {
        #region MSSQlServer
        public static void AddParam(this SqlCommand cmd, string parameterName, SqlDbType sqlDbType, object value = null, ParameterDirection parameterDirection = ParameterDirection.Input, int size = -1)
        {

            SqlParameter parameter = new SqlParameter()
            {
                ParameterName = parameterName,
                Direction = parameterDirection,
                Size = size,
                Value = value,
                SqlDbType = sqlDbType
            };
            cmd.Parameters.Add(parameter);
        }
        #endregion

        public static T ToObject<T>(this IDataReader reader)
        {
            T oObject = (T)Activator.CreateInstance(typeof(T));
            var assignableProperties = typeof(T).GetProperties().ToList();

            assignableProperties.ForEach(p =>
            {
                var val = reader.GetValue(reader.GetOrdinal(p.Name));
                object oVal = null;
                if (DBNull.Value.Equals(val))
                    oVal = p.PropertyType.IsValueType ? Activator.CreateInstance(p.PropertyType) : null;
                else
                    oVal = val;
                p.SetValue(oObject, oVal, null);
            });

            return oObject;
        }
    }
}
