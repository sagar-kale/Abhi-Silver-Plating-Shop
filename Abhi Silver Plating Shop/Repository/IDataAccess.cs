using System.Collections.Generic;
using System.Data;

namespace Abhi_Silver_Plating_Shop.Repository
{
    public interface IDataAccess
    {
        List<T> LoadData<T, U>(string sql, U parameters);
        T LoadSingleData<T, U>(string sql, U parameters);
        DataTable PopulateGrid<T>(string sql, T parameters);
        void SaveData<U>(string sql, U parameters);
    }
}