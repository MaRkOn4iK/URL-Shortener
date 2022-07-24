using Microsoft.EntityFrameworkCore;

namespace UrlShortnerTester.Helpers
{
    internal class UnitTestDbContext
    {

        public static DbContextOptions<ApplicationDbContext> GetUnitTestDbOptions()
        {
            DbContextOptions<ApplicationDbContext>? options = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase(Guid.NewGuid().ToString())
               .Options;

            using (ApplicationDbContext? context = new(options))
            {
                SeedData(context);
            }

            return options;
        }
        public static void SeedData(ApplicationDbContext context)
        {
            _ = context.Roles.Add(new IdentityRole("user"));
            _ = context.Roles.Add(new IdentityRole("admin"));
            _ = context.SaveChanges();
            _ = context.Users.Add(new ApplicationUser
            {
                Email = "380669978812mark@gmail.com",
                UserName = "380669978812mark@gmail.com",
                PasswordHash = "AQAAAAEAACcQAAAAEBdOWtNtMsxHDZYbzUDPxo3ZTyOvoPF2U+FqE4Fn4HqMBs9oh34CoBZ91WSynHWf5g=="
            });
            _ = context.Users.Add(new ApplicationUser
            {
                Email = "115223qwe@gmail.com",
                UserName = "115223qwe@gmail.com",
                PasswordHash = "AQAAAAEAACcQAAAAEBdOWtNtMsxHDZYbzUDPxo3ZTyOvoPF2U+FqE4Fn4HqMBs9oh34CoBZ91WSynHWf5g=="
            });
            _ = context.SaveChanges();
            _ = context.UrlModels.Add(new UrlModel
            {
                LongUrl = "longUrl",
                ShortUrl = "shortUrl",
                ApplicationUserId = context.Users.FirstOrDefault().Id
            });
            _ = context.UrlModels.Add(new UrlModel
            {
                LongUrl = "longUrl2",
                ShortUrl = "shortUrl2",
                ApplicationUserId = context.Users.FirstOrDefault().Id
            });
            _ = context.SaveChanges();
        }
    }
}
