using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace Test.Pages
{
    public class MessageModel : PageModel
    {
        private readonly IConfiguration _configuration;
        public string Message {get; set;}        
        public string Phonk {get; set;}

        public MessageModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnGet()
        {
            Message = _configuration["CustomMessage"];
        }
    }
}
