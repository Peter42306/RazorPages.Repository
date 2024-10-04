using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPages.Repository.Model;
using RazorPages.Repository.Repository;

namespace RazorPages.Repository.Pages.Students
{
    public class DeleteModel : PageModel
    {
        private readonly IRepository<Student> _repository;

        public DeleteModel(IRepository<Student> repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || await _repository.GetAll() == null)
            {
                return NotFound();
            }

            Student = await _repository.GetById((int)id);

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (await _repository.GetAll() == null)
            {
                return NotFound();
            }

            Student = await _repository.GetById((int)id);
            
            if (Student != null)
            {
                await _repository.Delete((int)id);
                await _repository.Save();
            }
            return RedirectToPage("./Index");
        }
    }
}
