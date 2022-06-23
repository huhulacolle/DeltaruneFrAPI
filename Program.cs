DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

Console.WriteLine("MySQL : " + Environment.GetEnvironmentVariable("MySQL"));

builder.Services.AddSingleton(new DefaultSqlConnectionFactory(Environment.GetEnvironmentVariable("MySQL")));

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(o =>
{
	var Key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("Token"));
	o.SaveToken = true;
	o.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuer = false,
		ValidateAudience = false,
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true,
		IssuerSigningKey = new SymmetricSecurityKey(Key)
	};
});

builder.Services.AddCors();

builder.Services.AddSwaggerDocument();

builder.Services.AddScoped<ITestRepository, TestRepository>();

builder.Services.AddScoped<IStaffRepository, StaffRepository>();

builder.Services.AddScoped<IJWTManager, JWTManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
	app.UseOpenApi();
	app.UseSwaggerUi3();
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
