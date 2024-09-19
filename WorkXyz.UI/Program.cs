using Microsoft.EntityFrameworkCore;
using WorkXyz.Repositories;
using WorkXyz.Repositories.Implementations;
using WorkXyz.Repositories.Interfaces;
using WorkXyz.UI.Mapper;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplictaionDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("WorkXyz.UI")));
builder.Services.AddScoped<IBranchRepo, BranchRepo>();
builder.Services.AddScoped<IStudentNewRepo, StudentNewRepo>();
builder.Services.AddScoped<ISubjectRepo, SubjectRepo>();
builder.Services.AddScoped<ITeacherRepo, TeacherRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IUtilityRepo, UtilityRepo>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
var config = new AutoMapper.MapperConfiguration(options =>
{
    options.AddProfile(new AutoMapperProfile());
});
var mapper= config.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(5);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;

});
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
