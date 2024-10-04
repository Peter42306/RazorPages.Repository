using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Repository.Model;
using RazorPages.Repository.Repository;

namespace RazorPages.Repository.Pages.Students
{
    public class IndexModel : PageModel
    {
        public IList<Student> Student { get; set; } = default!;

        public async Task OnGetAsync([FromServices] IRepository<Student> repository)
        {
            Student=await repository.GetAll();
        }
    }
}
