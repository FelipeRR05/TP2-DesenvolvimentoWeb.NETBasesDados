using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DR4_TP2.Pages.CityManager
{
    public class CityListModel : PageModel
    {
        public List<string> Cities { get; set; } = new()
        {
            "Rio",
            "São Paulo",
            "Brasília"
        };

        public void OnGet()
        {
        }
    }
}
