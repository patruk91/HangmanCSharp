using System.Collections.Generic;
using HangmanCSharp.model;

namespace HangmanCSharp.dao.dataManager
{
    public interface IDataManager
    {
        List<Country> GetCountries();
    }
}