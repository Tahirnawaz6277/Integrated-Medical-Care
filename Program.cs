using imc_web_api;
using imc_web_api.AutoMapper;
using imc_web_api.Models;
using imc_web_api.Repository.AuthRepository;
using imc_web_api.Service.AdminServices.ManageAccountServices;
using imc_web_api.Service.AdminServices.ManageHCPServices;
using imc_web_api.Service.AuthService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ImcDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("IMCConnectionString"));
});

//--> Add Repositories

builder.Services.AddScoped<IRegisterRepository, RegisterRepository>();
builder.Services.AddScoped<IRegistrationService, RegisterService>();
builder.Services.AddScoped<IJWTTokenRepository, JWTTokenRepository>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IManageAccountService, ManageAccountService>();
builder.Services.AddScoped<IManageHCPService, ManageHCPServices>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
// Data protection Middleware
builder.Services.AddDataProtection();
// Now we Inject This line adds the Identity framework to your ASP.NET Core application.
builder.Services.AddIdentity<user, IdentityRole>()

    .AddTokenProvider<DataProtectorTokenProvider<user>>("IMC")
    .AddEntityFrameworkStores<ImcDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredUniqueChars = 1;
    options.Password.RequiredLength = 6;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();