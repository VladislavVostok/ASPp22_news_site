using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Test.Pages
{
    public class RandomModel : PageModel
    {
        private static readonly Random _random = new Random();

        private static readonly List<(string Text, string Author)> quotes = new()
        {
            ("��������� ����������, � ���� ������� �� ��������", "�������� ������"),
            ("� ������� ���� ����", "����� ����"),
        };

        public string QuoteText { get; set; }
        public string QuoteAuthor { get; set; }
        public void OnGet()
        {
            var quote = quotes[_random.Next(quotes.Count)];
            QuoteText = quote.Text;
            QuoteAuthor = quote.Author;
        }
    }
}
