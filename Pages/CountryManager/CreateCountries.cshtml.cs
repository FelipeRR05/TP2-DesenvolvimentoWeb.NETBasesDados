using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace DR4_TP2.Pages.CountryManager
{
    public class CreateCountriesModel : PageModel
    {
        [BindProperty]
        public List<InputModel> Countries { get; set; } = new();

        public List<Country>? SubmittedCountries { get; set; }

        public bool IsSubmitted { get; set; } = false;

        public void OnGet()
        {
            for (int i = 0; i < 5; i++)
            {
                Countries.Add(new InputModel());
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            SubmittedCountries = Countries
                .Where(c => !string.IsNullOrWhiteSpace(c.CountryName) && !string.IsNullOrWhiteSpace(c.CountryCode))
                .Select(c => new Country
                {
                    CountryName = c.CountryName,
                    CountryCode = c.CountryCode
                }).ToList();

            IsSubmitted = true;
            return Page();
        }

        public class InputModel
        {
            [Required(ErrorMessage = "O nome do pa�s � obrigat�rio.")]
            public string? CountryName { get; set; }

            [Required(ErrorMessage = "O c�digo do pa�s � obrigat�rio.")]
            [StringLength(2, MinimumLength = 2, ErrorMessage = "O c�digo deve ter exatamente 2 letras.")]
            public string? CountryCode { get; set; }
        }

        public class Country
        {
            public string? CountryName { get; set; }
            public string? CountryCode { get; set; }
        }
    }
}
