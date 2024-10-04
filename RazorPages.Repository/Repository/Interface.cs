using RazorPages.Repository.Model;

namespace RazorPages.Repository.Repository
{
	public interface IRepository<T> where T : class
	{
		Task<List<T>> GetAll();
		Task<T> GetById(int id);
		Task Create(T item);
		void Update(T item);
		Task Delete(int id);
		Task Save();
	}
}
