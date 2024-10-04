using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Repository.Model;
using RazorPages.Repository.Repository;

namespace RazorPages.Repository.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly IRepository<Student> _repository;

        public DetailsModel(IRepository<Student> repository)
        {
            _repository = repository;
        }

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
    }
}
