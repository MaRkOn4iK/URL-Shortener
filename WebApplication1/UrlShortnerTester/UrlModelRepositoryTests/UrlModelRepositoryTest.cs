

namespace UrlShortnerTester.UrlModelRepositoryTests
{
    [TestFixture]
    internal class UrlModelRepositoryTest
    {
        [Test]
        public void UserRepository_GetAll_ReturnsAllValues()
        {
            using ApplicationDbContext? context = new(UnitTestDbContext.GetUnitTestDbOptions());
            UrlModelRepository repository = new(context);
            IEnumerable<UrlModel>? count = repository.GetAll();
            Assert.That(count.Count, Is.EqualTo(2));
        }
        [Test]
        public void UserRepository_Add_ReturnsAllValues()
        {
            using ApplicationDbContext? context = new(UnitTestDbContext.GetUnitTestDbOptions());
            UrlModelRepository repository = new(context);
            repository.Add(new UrlModel { LongUrl = "NewLongUrl", ShortUrl = "NewShortUrl", ApplicationUserId = context.Users.FirstOrDefault().Id });
            _ = context.SaveChanges();
            IEnumerable<UrlModel>? count = repository.GetAll();
            Assert.That(count.Count, Is.EqualTo(3));
        }
        [Test]
        public void UserRepository_DeleteById_ReturnsAllValues()
        {
            using ApplicationDbContext? context = new(UnitTestDbContext.GetUnitTestDbOptions());
            UrlModelRepository repository = new(context);
            repository.DeleteById(2);
            _ = context.SaveChanges();
            IEnumerable<UrlModel>? count = repository.GetAll();
            Assert.That(count.Count, Is.EqualTo(1));
        }
    }
}
