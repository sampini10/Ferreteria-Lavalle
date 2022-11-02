using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BE_Ferreteria.Data
{
    public interface IConnection
    {
        IDataReader ExecuteReader(IDbCommand cmd);
        void ExecuteNonQuery(IDbCommand cmd);
        T GetDataItem<T>(IDbCommand cmd);
        List<T> GetDataList<T>(IDbCommand cmd);
        StringBuilder GetDataListJson<T>(IDbCommand cmd);
    }
}
