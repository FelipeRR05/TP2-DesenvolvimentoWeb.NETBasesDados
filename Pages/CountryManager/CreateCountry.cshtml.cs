using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DR4_TP2.Pages.CountryManager
{
    public class CreateCountryModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; } = new();

        public Country? SubmittedCountry { get; set; }

        public void OnPost()
        {
            if (!string.IsNullOrWhiteSpace(Input.CountryName) &&
                !string.IsNullOrWhiteSpace(Input.CountryCode))
            {
                char nameFirst = char.ToUpper(Input.CountryName[0]);
                char codeFirst = char.ToUpper(Input.CountryCode[0]);

                if (nameFirst != codeFirst)
                {
                    ModelState.AddModelError("Input.CountryCode", "O c�digo do pa�s deve come�ar com a mesma letra do nome do pa�s.");
                }
            }

            if (!ModelState.IsValid)
            {
                return;
            }

            SubmittedCountry = new Country
            {
                CountryName = Input.CountryName,
                CountryCode = Input.CountryCode
            };
        }

        public class InputModel
        {
            [Required(ErrorMessage = "Nome do pa�s � obrigat�rio.")]
            public string CountryName { get; set; } = string.Empty;

            [Required(ErrorMessage = "C�digo do pa�s � obrigat�rio.")]
            [StringLength(2, MinimumLength = 2, ErrorMessage = "O c�digo do pa�s deve ter 2 letras.")]
            public string CountryCode { get; set; } = string.Empty;
        }

        public class Country
        {
            public string CountryName { get; set; } = string.Empty;
            public string CountryCode { get; set; } = string.Empty;
        }
    }
}
