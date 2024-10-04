using Microsoft.EntityFrameworkCore;

namespace RazorPages.Repository.Model
{
	public class ApplicationContext : DbContext
	{
		public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{
			if (Database.EnsureCreated())
			{
				Students?.Add(new Student { Name = "Иван", Surname = "Иванов", Age = 20, GPA = 10.5 });
				Students?.Add(new Student { Name = "Сергей", Surname = "Сергеев", Age = 23, GPA = 11.5 });
				Students?.Add(new Student { Name = "Петр", Surname = "Петров", Age = 25, GPA = 12 });

                Teachers?.Add(new Teacher { Name="Мария", Surname="Васильева", Subject="Базы данных", Experience=8, Age=38 });
                Teachers?.Add(new Teacher { Name="Валентина", Surname="Тихонова", Subject="C#", Experience=16, Age=45 });
                Teachers?.Add(new Teacher { Name="Николай", Surname="Николаев", Subject="ASP.NET", Experience=5, Age=27 });

                SaveChanges();
			}
		}
	}
}
