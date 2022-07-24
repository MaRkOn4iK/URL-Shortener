namespace UrlShortnerTester.ServicesTests
{
    [TestFixture]
    internal class AboutPageServiceTest
    {
        [Test]
        public void AboutPageService_GetAboutText_ReturnCorrectText()
        {
            AboutPageService aps = new();
            string? text = aps.GetAboutText();
            Assert.That(text, Is.EqualTo("Description"));
        }
        [Test]
        public void AboutPageService_SetAboutText_ReturnCorrectText()
        {
            AboutPageService aps = new();
            aps.SetAboutText("NewDescription");
            string? text = aps.GetAboutText();
            Assert.That(text, Is.EqualTo("NewDescription"));
            aps.SetAboutText("Description");
            text = aps.GetAboutText();
            Assert.That(text, Is.EqualTo("Description"));
        }
    }
}
