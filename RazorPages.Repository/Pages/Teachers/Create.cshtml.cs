using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Repository.Model;
using RazorPages.Repository.Repository;

namespace RazorPages.Repository.Pages.Teachers
{
    public class CreateModel : PageModel
    {
        private readonly IRepository<Teacher> _repository;

        public CreateModel(IRepository<Teacher> repository)
        {
            _repository = repository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Teacher Teacher { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                await _repository.Create(Teacher);
                await _repository.Save();
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
