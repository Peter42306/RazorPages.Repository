using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Repository.Model;
using RazorPages.Repository.Repository;

namespace RazorPages.Repository.Pages.Teachers
{
    public class IndexModel : PageModel
    {
        public IList<Teacher> Teacher { get; set; } = default!;

        public async Task OnGetAsync([FromServices] IRepository<Teacher> repository)
        {
            Teacher=await repository.GetAll();
        }
    }
}
