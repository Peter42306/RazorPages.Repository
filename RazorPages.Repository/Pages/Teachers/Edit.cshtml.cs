using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPages.Repository.Model;
using RazorPages.Repository.Repository;

namespace RazorPages.Repository.Pages.Teachers
{
    public class EditModel : PageModel
    {
        private readonly IRepository<Teacher> _repository;

        public EditModel(IRepository<Teacher> repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public Teacher Teacher { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || await _repository.GetAll() == null)
            {
                return NotFound();
            }

            Teacher = await _repository.GetById((int)id);

            if (Teacher == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.Update(Teacher);
                    await _repository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await StudentExists(Teacher.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToPage("./Index");
            }
            return Page();
        }

        private async Task<bool> StudentExists(int id)
        {
            List<Teacher> list = await _repository.GetAll();
            return (list?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
