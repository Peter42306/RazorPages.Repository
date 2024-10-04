using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Repository.Model;
using RazorPages.Repository.Repository;

namespace RazorPages.Repository.Pages.Teachers
{
    public class DetailsModel : PageModel
    {
        private readonly IRepository<Teacher> _repository;

        public DetailsModel(IRepository<Teacher> repository)
        {
            _repository = repository;
        }

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
    }
}
