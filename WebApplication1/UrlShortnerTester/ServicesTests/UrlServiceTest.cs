namespace UrlShortnerTester.ServicesTests
{
    [TestFixture]
    internal class UrlServiceTest
    {
        [Test]
        public void UrlService_GetAllUrls_ReturnCorrectValue()
        {
            using ApplicationDbContext? context = new(UnitTestDbContext.GetUnitTestDbOptions());
            UrlModelRepository repository = new(context);
            Mock<IUnitOfWork>? uow = new();
            _ = uow.Setup(res => res.UrlModelRepository).Returns(repository);
            UrlService? us = new(uow.Object);
            IEnumerable<UrlModel>? count = us.GetAllUrls();
            Assert.That(count.Count, Is.EqualTo(2));
        }

        [Test]
        public void UrlService_AddNewUrl_ReturnCorrectValue()
        {
            using ApplicationDbContext? context = new(UnitTestDbContext.GetUnitTestDbOptions());
            UrlModelRepository repository = new(context);
            Mock<IUnitOfWork>? uow = new();
            _ = uow.Setup(res => res.UrlModelRepository).Returns(repository);
            UrlService? us = new(uow.Object);
            _ = us.AddNewUrl("NewLongUrl", context.Users.FirstOrDefault().Id);
            _ = context.SaveChanges();
            IEnumerable<UrlModel>? count = us.GetAllUrls();
            Assert.That(count.Count, Is.EqualTo(3));
        }
        [Test]
        public void UrlService_DeleteUrl_ReturnCorrectValue()
        {
            using ApplicationDbContext? context = new(UnitTestDbContext.GetUnitTestDbOptions());
            UrlModelRepository repository = new(context);
            Mock<IUnitOfWork>? uow = new();
            _ = uow.Setup(res => res.UrlModelRepository).Returns(repository);
            UrlService? us = new(uow.Object);
            _ = us.DeleteUrl(2);
            _ = context.SaveChanges();
            IEnumerable<UrlModel>? count = us.GetAllUrls();
            Assert.That(count.Count, Is.EqualTo(1));
        }
    }
}
