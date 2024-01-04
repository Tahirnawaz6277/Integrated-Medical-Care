using IMC_Integrated_Medical_Care_.DbContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DbContextClass>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("IMCConnectionString"));
});




builder.Services.AddIdentity<IdentityUser, IdentityRole>()

    .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("IMC")
    .AddEntityFrameworkStores<DbContextClass>()
    .AddDefaultTokenProviders();





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
