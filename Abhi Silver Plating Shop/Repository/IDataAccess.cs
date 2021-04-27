using System.Collections.Generic;

namespace Abhi_Silver_Plating_Shop.Repository
{
    public interface IDataAccess
    {
        List<T> LoadData<T, U>(string sql, U parameters);
        void SaveData<U>(string sql, U parameters);
    }
}