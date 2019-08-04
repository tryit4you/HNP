using HNP.Data.Models;
using HNP.Shared;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HNP.Data
{
    public class DbSeeder
    {
        public static void Seed(DataDbContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            if (!dbContext.Users.Any())
            {
                CreateUser(dbContext, roleManager, userManager)
                   .GetAwaiter()
                   .GetResult();
            }
            if (!dbContext.Slides.Any())
            {
                CreateSlides(dbContext, userManager);
            }
            if (!dbContext.Books.Any())
            {
                CreateBook(dbContext, userManager);
            }
            if (!dbContext.Categories.Any())
            {
                CreatedCategory(dbContext);
            }
            if (!dbContext.BookTypes.Any())
            {
                CreateBookTypeByCategory(dbContext);
            }
            if (!dbContext.DownloadFormats.Any())
            {
                CreateFormat(dbContext);
            }
            if (!dbContext.Pages.Any())
            {
                CreatePage(dbContext, userManager);
            }
            if (!dbContext.Contacts.Any())
            {
                CreateContacts(dbContext, userManager);
            }
        }
        private static void CreateContacts(DataDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            var userId = userManager.FindByEmailAsync("vohung.it@gmail.com").Result.Id;
            var contact = new Contact
            {
                Name = "Liên hệ",
                Address = "Phường Tân Thạnh - Tp.Tam Kỳ - Quảng Nam",
                Email = "vohung.it@gmail.com",
                Phone = "0169 565 5783",
                Status = true,
                UserId = userId
            };
            dbContext.Contacts.Add(contact);
            dbContext.SaveChanges();
        }
        private static void CreatePage(DataDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            var userId = userManager.FindByEmailAsync("vohung.it@gmail.com").Result.Id;
            List<Page> pages = new List<Page>
            {
                new Page
                {
                    Id=Guid.NewGuid().ToString(),
                    Name="footer",
                    Content="footer",
                    CreatedDate=DateTime.Now,
                    UserId=userId,
                    Status=true
                },new Page
                {
                    Id=Guid.NewGuid().ToString(),
                    Name="contact",
                    Content="contact content seeder",
                    CreatedDate=DateTime.Now,
                    UserId=userId,
                    Status=true
                },new Page
                {
                    Id=Guid.NewGuid().ToString(),
                    Name="about",
                    Content="about content seeder",
                    CreatedDate=DateTime.Now,
                    UserId=userId,
                    Status=true
                }
            };
            pages.ForEach(x => dbContext.Pages.Add(x));
            dbContext.SaveChanges();
        }

        private static void CreateFormat(DataDbContext dbContext)
        {
            List<DownloadFormat> formats = new List<DownloadFormat>
            {
                new DownloadFormat
                {
                    DisplayName="link1",
                    PdfLink="http://www.mediafire.com/file/7vl63g7szf5opcd/advanced-aspnet-ajax-server-controls-adam-calderon.pdf/file",

                }
            };
            formats.ForEach(x => dbContext.DownloadFormats.Add(x));
            dbContext.SaveChanges();
        }
        private static void CreateBookTypeByCategory(DataDbContext dbContext)
        {
            List<BookType> type = new List<BookType>
            {
                new BookType
                {
                    Id=Guid.NewGuid().ToString(),
                    Name="Lập trình di động",
                    MetaName="Lập trình di động",
                    CategoryId=dbContext.Categories.Where(x=>x.Name=="Máy tính và Công nghệ").SingleOrDefault().Id,
                    Status=true,
                    CreatedDate=DateTime.Now,
                    ThumbnailUrl="http://www.mediafire.com/view/t8tn063vcglg808/android-300x300.png",
                    Description="Ebook về lập trình di động"
                },
                new BookType
                {
                    Id=Guid.NewGuid().ToString(),
                    Name="Lập trình website",
                    MetaName="Lập trình website",
                    CategoryId=dbContext.Categories.Where(x=>x.Name=="Máy tính và Công nghệ").SingleOrDefault().Id,
                    Status=true,
                    CreatedDate=DateTime.Now,
                    ThumbnailUrl="http://www.mediafire.com/view/dwlk4ed7vomaj02/tải%20xuống.png",
                    Description="Ebook về lập trình website"
                },
                new BookType
                {
                    Id=Guid.NewGuid().ToString(),
                    Name="Trí tuệ nhân tạo",
                    MetaName="Trí tuệ nhân tạo",
                    CategoryId=dbContext.Categories.Where(x=>x.Name=="Máy tính và Công nghệ").SingleOrDefault().Id,
                    Status=true,
                    CreatedDate=DateTime.Now,
                    ThumbnailUrl="http://www.mediafire.com/view/dwlk4ed7vomaj02/tải%20xuống.png",
                    Description="Ebook về lập trình trí tuệ nhân tạo"
                },
                 new BookType
                {
                     Id=Guid.NewGuid().ToString(),
                    Name="Kỹ năng giao tiếp",
                    MetaName="Kỹ năng giao tiếp",
                    CategoryId=dbContext.Categories.Where(x=>x.Name=="Phát triển kỹ năng").SingleOrDefault().Id,
                    Status=true,
                    CreatedDate=DateTime.Now,
                    ThumbnailUrl="http://www.mediafire.com/view/dwlk4ed7vomaj02/tải%20xuống.png",
                    Description="Ebook về lập kỹ năng giao tiếp kỹ năng thuyết trình"
                },
                new BookType
                {
                    Id=Guid.NewGuid().ToString(),
                    Name="Khai phá bản thân",
                    MetaName="Khai phá bản thân",
                    CategoryId=dbContext.Categories.Where(x=>x.Name=="Phát triển kỹ năng").SingleOrDefault().Id,
                    Status=true,
                    CreatedDate=DateTime.Now,
                    ThumbnailUrl="http://www.mediafire.com/view/dwlk4ed7vomaj02/tải%20xuống.png",
                    Description="Ebook khai phá bản thân"
                }, new BookType
                {
                    Id=Guid.NewGuid().ToString(),
                    Name="Toán học phổ thông",
                    MetaName="Toán học phổ thông",
                    CategoryId=dbContext.Categories.Where(x=>x.Name=="Toán học").SingleOrDefault().Id,
                    Status=true,
                    CreatedDate=DateTime.Now,
                    ThumbnailUrl="http://www.mediafire.com/view/dwlk4ed7vomaj02/tải%20xuống.png",
                    Description="Ebook toán học phổ thông"
                },
                new BookType
                {
                    Id=Guid.NewGuid().ToString(),
                    Name="Toán học ứng dụng",
                    MetaName="Toán học ứng dụng",
                    CategoryId=dbContext.Categories.Where(x=>x.Name=="Toán học").SingleOrDefault().Id,
                    Status=true,
                    CreatedDate=DateTime.Now,
                    ThumbnailUrl="http://www.mediafire.com/view/dwlk4ed7vomaj02/tải%20xuống.png",
                    Description="Ebook toán học ứng dụng"
                },
                 new BookType
                {
                     Id=Guid.NewGuid().ToString(),
                    Name="Chiến tranh Việt Nam",
                    MetaName="Chiến tranh Việt Nam",
                    CategoryId=dbContext.Categories.Where(x=>x.Name=="Lịch sử").SingleOrDefault().Id,
                    Status=true,
                    CreatedDate=DateTime.Now,
                    ThumbnailUrl="http://www.mediafire.com/view/dwlk4ed7vomaj02/tải%20xuống.png",
                    Description="Chiến tranh Việt Nam"
                },
                 new BookType
                {
                     Id=Guid.NewGuid().ToString(),
                    Name="Lịch sử thế giới",
                    MetaName="Lịch sử thế giới",
                    CategoryId=dbContext.Categories.Where(x=>x.Name=="Lịch sử").SingleOrDefault().Id,
                    Status=true,
                    CreatedDate=DateTime.Now,
                    ThumbnailUrl="http://www.mediafire.com/view/dwlk4ed7vomaj02/tải%20xuống.png",
                    Description="Lịch sử thế giới"
                },
                  new BookType
                {
                      Id=Guid.NewGuid().ToString(),
                    Name="Y khoa thường thức",
                    MetaName="Y khoa thường thức",
                    CategoryId=dbContext.Categories.Where(x=>x.Name=="Y khoa").SingleOrDefault().Id,
                    Status=true,
                    CreatedDate=DateTime.Now,
                    ThumbnailUrl="http://www.mediafire.com/view/dwlk4ed7vomaj02/tải%20xuống.png",
                    Description="Y khoa thường thức"
                },
                 new BookType
                {
                     Id=Guid.NewGuid().ToString(),
                    Name="Y học phương đông",
                    MetaName="Y học phương đông",
                    CategoryId=dbContext.Categories.Where(x=>x.Name=="Y khoa").SingleOrDefault().Id,
                    Status=true,
                    CreatedDate=DateTime.Now,
                    ThumbnailUrl="http://www.mediafire.com/view/dwlk4ed7vomaj02/tải%20xuống.png",
                    Description="Y học phương đông"
                },
                 new BookType
                {
                     Id=Guid.NewGuid().ToString(),
                    Name="Y học phương tây",
                    MetaName="Y học phương tây",
                    CategoryId=dbContext.Categories.Where(x=>x.Name=="Y khoa").SingleOrDefault().Id,
                    Status=true,
                    CreatedDate=DateTime.Now,
                    ThumbnailUrl="http://www.mediafire.com/view/dwlk4ed7vomaj02/tải%20xuống.png",
                    Description="Y học phương tây"
                }, new BookType
                {
                    Id=Guid.NewGuid().ToString(),
                    Name="Khởi nghiệp",
                    MetaName="Khởi nghiệp",
                    CategoryId=dbContext.Categories.Where(x=>x.Name=="Kinh doanh và Khởi nghiệp").SingleOrDefault().Id,
                    Status=true,
                    CreatedDate=DateTime.Now,
                    ThumbnailUrl="http://www.mediafire.com/view/dwlk4ed7vomaj02/tải%20xuống.png",
                    Description="Khởi nghiệp"
                },
                 new BookType
                {
                     Id=Guid.NewGuid().ToString(),
                    Name="Luật doanh nghiệp",
                    MetaName="Luật doanh nghiệp",
                    CategoryId=dbContext.Categories.Where(x=>x.Name=="Pháp luật").SingleOrDefault().Id,
                    Status=true,
                    CreatedDate=DateTime.Now,
                    ThumbnailUrl="http://www.mediafire.com/view/dwlk4ed7vomaj02/tải%20xuống.png",
                    Description="Luật doanh nghiệp"
                },new BookType
                {
                    Id=Guid.NewGuid().ToString(),
                    Name="Luật nhà nước",
                    MetaName="Luật nhà nước",
                    CategoryId=dbContext.Categories.Where(x=>x.Name=="Pháp luật").SingleOrDefault().Id,
                    Status=true,
                    CreatedDate=DateTime.Now,
                    ThumbnailUrl="http://www.mediafire.com/view/dwlk4ed7vomaj02/tải%20xuống.png",
                    Description="Luật nhà nước"
                },

            };
            type.ForEach(x => dbContext.BookTypes.Add(x));
            dbContext.SaveChanges();
        }

        public static void CreatedCategory(DataDbContext dbContext)
        {
            List<Category> cate = new List<Category> {
                new Category
                {
                    Id=Guid.NewGuid().ToString(),
                    Name="Máy tính và Công nghệ",
                    MetaName=Utils.ToUnsignString("Máy tính và Công nghệ"),
                    CreatedDate=DateTime.Now,
                    Status=true
                },
                new Category
                {
                    Id=Guid.NewGuid().ToString(),
                    Name="Phát triển kỹ năng",
                    MetaName=Utils.ToUnsignString("Phát triển kỹ năng"),
                    CreatedDate=DateTime.Now,
                    Status=true
                },
                new Category
                {
                    Id=Guid.NewGuid().ToString(),
                    Name="Toán học",
                    MetaName=Utils.ToUnsignString("Toán học"),
                    CreatedDate=DateTime.Now,
                    Status=true
                },new Category
                {
                    Id=Guid.NewGuid().ToString(),
                    Name="Lịch sử",
                    MetaName=Utils.ToUnsignString("Lịch sử"),
                    CreatedDate=DateTime.Now,
                    Status=true
                },new Category
                {
                    Id=Guid.NewGuid().ToString(),
                    Name="Y khoa",
                    MetaName=Utils.ToUnsignString("Y khoa"),
                    CreatedDate=DateTime.Now,
                    Status=true
                },new Category
                {
                    Id=Guid.NewGuid().ToString(),
                    Name="Kinh doanh và Khởi nghiệp",
                    MetaName=Utils.ToUnsignString("Kinh doanh và khởi nghiệp"),
                    CreatedDate=DateTime.Now,
                    Status=true
                },new Category
                {
                    Id=Guid.NewGuid().ToString(),
                    Name="Tiểu sử và Hồi ký",
                    MetaName=Utils.ToUnsignString("Tiểu sử và hồi ký"),
                    CreatedDate=DateTime.Now,
                    Status=true
                },new Category
                {
                    Id=Guid.NewGuid().ToString(),
                    Name="Pháp luật",
                    MetaName=Utils.ToUnsignString("Pháp luật"),
                    CreatedDate=DateTime.Now,
                    Status=true
                },new Category
                {
                    Id=Guid.NewGuid().ToString(),
                    Name="Nấu ăn",
                    MetaName=Utils.ToUnsignString("Nấu ăn"),
                    CreatedDate=DateTime.Now,
                    Status=true
                }
            };
            cate.ForEach(c => dbContext.Categories.Add(c));
            dbContext.SaveChanges();
        }
        public static void CreateBook(DataDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            IEnumerable<Book> books = new List<Book>();

        }
        public static void CreateSlides(DataDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            var userId = userManager.FindByEmailAsync("vohung.it@gmail.com").Result.Id;
            List<Slide> slides = new List<Slide>
            {
                 new Slide
            {
                Id=Guid.NewGuid().ToString(),
                Name = "slide 1",
                UserId = userId,
                Authors = "Hồ Chí Minh",
                Content = "Lao động trí óc mà không lao động chân tay, chỉ biết lý luận mà không biết thực hành thì cũng là trí thức có một nửa. Vì vậy, cho nên các cháu trong lúc học lý luận cũng phải kết hợp với thực hành và tất cả các ngành khác đều phải: lý luận kết hợp với thực hành, học tập kết hợp với lao động.",
                DisplayOrder = 1,
                Image = "http://www.mediafire.com/convkey/2b3c/cfd3i2sc2t4tr4izg.jpg",
                IsChoose = true,
                Status = true
            },
                 new Slide
            {
                     Id=Guid.NewGuid().ToString(),
                Name = "slide 2",
                UserId = userId,
                Authors = "Frank Herbert ",
                Content = "Người ta chỉ học được từ sách và các ví dụ rằng một số thứ có thể làm được. Học hỏi thực sự yêu cầu bạn phải thực hiện chúng.",
            DisplayOrder = 1,
                Image = "http://www.mediafire.com/convkey/6546/66qp4fak56c84qtzg.jpg",
                IsChoose = true,
                Status = true
            }
        };
            slides.ForEach(x => dbContext.Slides.Add(x));
            dbContext.SaveChanges();
        }
        public static async Task CreateUser(DataDbContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            string role_Administrator = "Administrator";
            string role_RegisteredUser = "RegisteredUser";
            if (!await roleManager.RoleExistsAsync(role_Administrator))
            {
                await roleManager.CreateAsync(new IdentityRole(role_Administrator));
            }
            if (!await roleManager.RoleExistsAsync(role_RegisteredUser))
            {
                await roleManager.CreateAsync(new IdentityRole(role_RegisteredUser));
            }
            //create the "Admin" ApplicationUser account
            var user_Admin = new ApplicationUser
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = "Administrator",
                Email = "vohung.it@gmail.com",
                EmailConfirmed = true,
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                Status=true,
            
        };
             if (await userManager.FindByNameAsync(user_Admin.UserName) == null)
            {

                user_Admin.EmailConfirmed = true;
                user_Admin.LockoutEnabled = false;
                IdentityResult result = await userManager.CreateAsync(user_Admin, "pass4Admin");
                if (result==IdentityResult.Success)
                {
                    await userManager.AddToRoleAsync(user_Admin, role_Administrator);
                }
          
            }
            await dbContext.SaveChangesAsync();

        }
    }
}
