
using HNP.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HNP.DATA.DI.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        IQueryable<Book> GetBooksByCategory(string categoryId);
        IQueryable<Book> GetBooksByType(string typeId);
        IEnumerable<Book> RelatedBooks(string id);
        IEnumerable<Book> Top5Download { get; }
    }
}
