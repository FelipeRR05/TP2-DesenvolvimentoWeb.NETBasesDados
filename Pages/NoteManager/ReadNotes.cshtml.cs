using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DR4_TP2.Pages.NoteManager
{
    public class ReadNotesModel : PageModel
    {
        public List<string> Files { get; set; } = new();
        public string? SelectedFileName { get; set; }
        public string? FileContent { get; set; }

        public void OnGet(string? file)
        {
            var filesDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files");

            if (Directory.Exists(filesDirectory))
            {
                Files = Directory.GetFiles(filesDirectory, "*.txt")
                    .Select(f => Path.GetFileName(f))
                    .ToList();

                if (!string.IsNullOrEmpty(file))
                {
                    var filePath = Path.Combine(filesDirectory, file);

                    if (System.IO.File.Exists(filePath))
                    {
                        SelectedFileName = file;
                        FileContent = System.IO.File.ReadAllText(filePath);
                    }
                }
            }
        }
    }
}
