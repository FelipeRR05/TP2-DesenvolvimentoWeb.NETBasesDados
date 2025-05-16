using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DR4_TP2.Pages.CityManager
{
    public class CityDetailsModel : PageModel
    {
        public string? CityName { get; set; }

        public void OnGet(string cityName)
        {
            CityName = cityName;
        }
    }
}
