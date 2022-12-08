using System.Collections.Generic;

namespace RainingCatsAndDogsOnWeb.Services.Data.Contracts
{
    public interface ICategoriesService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();

        IEnumerable<T> GetAllCategories<T>();

        T GetByName<T>(string name);
    }
}
