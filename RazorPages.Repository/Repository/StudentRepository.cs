using Microsoft.EntityFrameworkCore;
using RazorPages.Repository.Model;

namespace RazorPages.Repository.Repository
{
	public class StudentRepository : IRepository<Student>
	{
		private readonly ApplicationContext _context;

        public StudentRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetAll()
		{
			return await _context.Students.ToListAsync();
		}

		public async Task<Student> GetById(int id)
		{
			return await _context.Students.FindAsync(id);
		}

		public async Task Create(Student item)
		{
			await _context.Students.AddAsync(item);
		}

		public void Update(Student item)
		{
			_context.Entry(item).State = EntityState.Modified;
		}

		public async Task Delete(int id)
		{
			var student = await _context.Students.FindAsync(id);

			if (student != null)
			{
				_context.Students.Remove(student);
			}
		}

		public async Task Save()
		{
			await _context.SaveChangesAsync();
		}
	}
}
