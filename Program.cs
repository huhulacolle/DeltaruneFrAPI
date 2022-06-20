DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

var connectionString = Environment.GetEnvironmentVariable("MySQL");

#pragma warning disable CS8604 // Existence possible d'un argument de référence null.
builder.Services.AddSingleton(new DefaultSqlConnectionFactory(connectionString));
#pragma warning restore CS8604 // Existence possible d'un argument de référence null.

builder.Services.AddCors();

builder.Services.AddScoped<IStaffRepository, StaffRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
