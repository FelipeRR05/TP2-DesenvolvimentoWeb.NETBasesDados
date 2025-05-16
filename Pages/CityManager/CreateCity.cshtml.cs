using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace DR4_TP2.Pages.CityManager
{
    public class CreateCityModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; }

        public bool IsSubmitted { get; set; } = false;

        public string? SubmittedCityName { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "O nome da cidade � obrigat�rio.")]
            [MinLength(3, ErrorMessage = "O nome da cidade deve ter pelo menos 3 caracteres.")]
            public string? CityName { get; set; }
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            IsSubmitted = true;
            SubmittedCityName = Input.CityName;

            return Page();
        }
    }
}
