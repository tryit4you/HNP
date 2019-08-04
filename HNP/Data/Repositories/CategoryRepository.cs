using HNP.Data.Interfaces;
using HNP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HNP.Data.Repositories
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
