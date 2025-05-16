using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DR4_TP2.Pages.NoteManager
{
    public class SaveNoteModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; } = new();

        public string? SavedFileName { get; set; }

        public class InputModel
        {
            [BindProperty]
            public string? Content { get; set; }
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrWhiteSpace(Input.Content))
            {
                ModelState.AddModelError("Input.Content", "O conteúdo não pode estar vazio.");
                return Page();
            }

            var fileName = $"note-{DateTime.Now:yyyyMMdd-HHmmss}.txt";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", fileName);

            Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);

            await System.IO.File.WriteAllTextAsync(filePath, Input.Content!);

            SavedFileName = fileName;
            return Page();
        }
    }
}
