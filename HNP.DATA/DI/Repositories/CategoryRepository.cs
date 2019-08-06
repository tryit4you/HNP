
using HNP.DATA.DI.Interfaces;
using HNP.DATA.Models;
namespace HNP.DATA.DI.Repositories
{
    public class CategoryRepository:Repository<Category>,ICategoryRepository
    {
        public CategoryRepository(DataDbContext context) : base(context)
        {

        }

        public int CountItemsByCategory(string categoryId)
        {
            return 0;
        }
    }
}
