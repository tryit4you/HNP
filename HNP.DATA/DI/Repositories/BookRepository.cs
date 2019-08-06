
using HNP.DATA;
using HNP.DATA.DI.Interfaces;
using HNP.DATA.DI.Repositories;
using HNP.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HNP.Data.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(DataDbContext context):base(context)
        {
        }
        public IEnumerable<Book> Top5Download => throw new NotImplementedException();

        public IQueryable<Book> GetBooksByCategory(string categoryId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Book> GetBooksByType(string typeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> RelatedBooks(string id)
        {
            throw new NotImplementedException();
        }
    }
}
