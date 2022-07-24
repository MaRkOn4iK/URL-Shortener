namespace UrlShortnerTester.UnitOfWorkTests
{
    [TestFixture]
    internal class UnitOfWorkTest
    {
        [Test]
        public void UnitOfWork_GetAllUrls_ReturnsAllValues()
        {
            using ApplicationDbContext? context = new(UnitTestDbContext.GetUnitTestDbOptions());
            UrlModelRepository repository = new(context);
            Mock<IUnitOfWork>? uow = new();
            _ = uow.Setup(res => res.UrlModelRepository).Returns(repository);
            IEnumerable<UrlModel>? count = uow.Object.UrlModelRepository.GetAll();
            Assert.That(count.Count, Is.EqualTo(2));
        }
        [Test]
        public void UnitOfWork_AddUrl_ReturnsAllValues()
        {
            using ApplicationDbContext? context = new(UnitTestDbContext.GetUnitTestDbOptions());
            UrlModelRepository repository = new(context);
            Mock<IUnitOfWork>? uow = new();
            _ = uow.Setup(res => res.UrlModelRepository).Returns(repository);
            uow.Object.UrlModelRepository.Add(new UrlModel { LongUrl = "NewLongUrl", ShortUrl = "NewShortUrl", ApplicationUserId = context.Users.FirstOrDefault().Id });
            _ = context.SaveChanges();
            IEnumerable<UrlModel>? count = uow.Object.UrlModelRepository.GetAll();
            Assert.That(count.Count, Is.EqualTo(3));
        }
        [Test]
        public void UnitOfWork_RemoveUrl_ReturnsAllValues()
        {
            using ApplicationDbContext? context = new(UnitTestDbContext.GetUnitTestDbOptions());
            UrlModelRepository repository = new(context);
            Mock<IUnitOfWork>? uow = new();
            _ = uow.Setup(res => res.UrlModelRepository).Returns(repository);
            uow.Object.UrlModelRepository.DeleteById(2);
            _ = context.SaveChanges();
            IEnumerable<UrlModel>? count = uow.Object.UrlModelRepository.GetAll();
            Assert.That(count.Count, Is.EqualTo(1));
        }
    }
}
