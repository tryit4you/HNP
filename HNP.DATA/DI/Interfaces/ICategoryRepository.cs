
using HNP.DATA.Models;

namespace HNP.DATA.DI.Interfaces
{
    public interface ICategoryRepository :IRepository<Category>
    {
        int CountItemsByCategory(string categoryId);
    }
}
