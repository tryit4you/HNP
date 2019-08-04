using HNP.Data.Models;
using HNP.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HNP.Data.Interfaces
{
    public interface ICategoryRepository :IRepository<Category>
    {
        int CountItemsByCategory(string categoryId);
    }
}
