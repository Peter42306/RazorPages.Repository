using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Repository.Model;
using RazorPages.Repository.Repository;

namespace RazorPages.Repository.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly IRepository<Student> _repository;

        public CreateModel(IRepository<Student> repository)
        {
            _repository = repository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                await _repository.Create(Student);
                await _repository.Save();
                return RedirectToPage("./Index");
            }
            return Page();
        }        
    }
}
