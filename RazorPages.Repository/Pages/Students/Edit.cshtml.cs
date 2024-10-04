using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using RazorPages.Repository.Model;
using RazorPages.Repository.Repository;

namespace RazorPages.Repository.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly IRepository<Student> _repository;

        public EditModel(IRepository<Student> repository)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.Update(Student);                    
                    await _repository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await StudentExists(Student.Id))
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
            List<Student> list = await _repository.GetAll();
            return (list?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
