using Microsoft.EntityFrameworkCore;
using RazorPages.Repository.Model;

namespace RazorPages.Repository.Repository
{
    public class TeacherRepository : IRepository<Teacher>
    {
        private readonly ApplicationContext _context;

        public TeacherRepository(ApplicationContext context)
        {
            _context = context;
        }


        public async Task<List<Teacher>> GetAll()
        {
            return await _context.Teachers.ToListAsync();
        }

        public async Task<Teacher> GetById(int id)
        {
            return await _context.Teachers.FindAsync(id);            
        }

        public async Task Create(Teacher item)
        {
            await _context.Teachers.AddAsync(item);
        }

        public void Update(Teacher item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public async Task Delete(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher != null)
            {
                _context.Teachers.Remove(teacher);
            }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
