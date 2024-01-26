using System.Text;
using System.Text.Json.Serialization;
using imc_web_api;
using imc_web_api.AutoMapper;
using imc_web_api.middle;
using imc_web_api.Models;
using imc_web_api.Repository.AuthRepository;
using imc_web_api.Service.AdminServices.ManageAccountServices;
using imc_web_api.Service.AdminServices.ManageFeedBackServicess;
using imc_web_api.Service.AdminServices.ManageHCPServices;
using imc_web_api.Service.AdminServices.ManageOrderServices;
using imc_web_api.Service.AdminServices.ManagePromotionServices;
using imc_web_api.Service.AdminServices.NewFolder;
using imc_web_api.Service.AuthService;
using imc_web_api.Service.AuthServices;
using imc_web_api.Service.ServiceProviderService.ManageServices_Service;
using imc_web_api.Service.ServiceProviderService.ManageServices_Service.ManageServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

//add Serilog

var logger = new LoggerConfiguration()
                 .WriteTo.Console()
                 //.WriteTo.File("")
                 //.MinimumLevel.Information()
                 .MinimumLevel.Error()
                 .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "IMC API'S", Version = "v1" });

    options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = JwtBearerDefaults.AuthenticationScheme
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type =ReferenceType.SecurityScheme,
                    Id =JwtBearerDefaults.AuthenticationScheme
                } ,
                Scheme= "Oauth2",
                Name = JwtBearerDefaults.AuthenticationScheme,
                In =ParameterLocation.Header
            }    ,
            new List<string>()
        }
    });
});

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
builder.Services.AddScoped<IQualificationService, QualificationService>();
builder.Services.AddScoped<IManageService, ManageService>();
builder.Services.AddScoped<IManagePromotionService, ManagePromotionService>();

builder.Services.AddScoped<IManageFeedbackService, ManageFeedBackService>();
builder.Services.AddScoped<IManagePromotionService, ManagePromotionService>();
builder.Services.AddScoped<IManageOrderService, ManageOrderService>();

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

//--- cycle error resolve

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

//JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();