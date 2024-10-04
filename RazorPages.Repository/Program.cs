using Microsoft.EntityFrameworkCore;
using RazorPages.Repository.Model;
using RazorPages.Repository.Repository;

var builder = WebApplication.CreateBuilder(args);

string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));


builder.Services.AddRazorPages();

builder.Services.AddScoped<IRepository<Student>, StudentRepository>();
builder.Services.AddScoped<IRepository<Teacher>, TeacherRepository>();

var app = builder.Build();

app.UseStaticFiles();
app.MapRazorPages();
app.Run();
