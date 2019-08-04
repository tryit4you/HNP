using HNP.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HNP.Data
{
    public class DataDbContext : IdentityDbContext<ApplicationUser>
    {
        public DataDbContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookType> BookTypes { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<PostCategory> PostCategories { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<History> Histories { get; set; }
        public virtual DbSet<DownloadFormat> DownloadFormats { get; set; }
        public virtual DbSet<EmailRegister> EmailRegisters { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseCategory> CourseCategories { get; set; }
    }
}
