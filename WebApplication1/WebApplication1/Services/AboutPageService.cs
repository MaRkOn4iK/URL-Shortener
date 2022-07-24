using WebApplication1.Interfaces;

namespace WebApplication1.Services
{
    public class AboutPageService : IAboutPageService
    {
        public string GetAboutText()
        {
            string contents = File.ReadAllText(@"Resources\About.txt");
            return contents;
        }

        public void SetAboutText(string text)
        {
            if (text != null)
            {
                File.WriteAllText(@"Resources\About.txt", text);
            }
        }
    }
}
