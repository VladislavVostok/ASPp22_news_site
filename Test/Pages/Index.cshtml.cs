using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorPagesApp.Pages
{
    public class IndexModel : PageModel
    {
        // условные данные
        static List<Company> companies { get; } = new()
        {
            new Company(1, "Apple"),
            new Company(2, "Samsung"),
            new Company(3, "Google")
        };
        public SelectList Companies { get; } = new SelectList(companies, "Id", "Name");
        [BindProperty]
        public Product Product { get; set; } = new("", 1000, 0);
        public string Message { get; private set; } = "ƒобавление товара";

        public void OnPost()
        {
            // получаем производител€ товара
            Company? company = companies.FirstOrDefault(c => c.Id == Product.CompanyId);
            Message = $"ƒобавлен новый товар: {Product.Name} ({company?.Name})";
        }
    }
    public record class Product(string Name, int Price, int CompanyId);
    public record class Company(int Id, string Name);
}