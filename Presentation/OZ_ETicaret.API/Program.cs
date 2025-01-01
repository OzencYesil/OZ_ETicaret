using OZ_ETicaret.Application;
using OZ_ETicaret.Domain.Entities;
using OZ_ETicaret.Persistance;
using FluentValidation;
using FluentValidation.AspNetCore;
using OZ_ETicaret.Application.Validations;
using OZ_ETicaret.Infrastructure;
using OZ_ETicaret.Persistance.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using Serilog;
using Serilog.Core;
using Serilog.Context;
using Serilog.Sinks.PostgreSQL;
using NpgsqlTypes;
using OZ_ETicaret.API.Middlewares;
using OZ_ETicaret.API.CustomColumnWriters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistanceService(builder.Configuration);
builder.Services.AddApplicationService();
builder.Services.AddInfrastructureService();

builder.Services.AddIdentity<AppUser, AppRole>(opt =>
    {
        opt.Password.RequireNonAlphanumeric = false;
        opt.Password.RequireLowercase = false;
        opt.Password.RequireUppercase = false;
    })
    .AddEntityFrameworkStores<OzETicaretDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddCors(opt => opt.AddDefaultPolicy(policy => policy.WithOrigins("https://localhost:4200", "http://localhost:4200")
.AllowAnyHeader().AllowAnyMethod().AllowCredentials()));

builder.Services.AddControllers()
    .AddFluentValidation(config => config.RegisterValidatorsFromAssembly(typeof(ProductValidation).Assembly));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => options.TokenValidationParameters = new()
{
    ValidateAudience = true,
    ValidateIssuer = true,
    ValidateIssuerSigningKey = true,
    ValidateLifetime = true,

    ValidAudience = builder.Configuration["JWTToken:Audience"],
    ValidIssuer = builder.Configuration["JWTToken:Issuer"],
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTToken:SigningKey"])),
    LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires > DateTime.UtcNow ? true : false,
    NameClaimType = ClaimTypes.Name,
    RoleClaimType = ClaimTypes.Role
});

Logger log = new LoggerConfiguration()
    .WriteTo.File("logs/serilog.txt")
    .WriteTo.PostgreSQL(connectionString: builder.Configuration.GetConnectionString("PostgreSQL"),tableName:"productslog",restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information,
    columnOptions: new Dictionary<string, ColumnWriterBase>
    {
        {"message", new RenderedMessageColumnWriter(NpgsqlDbType.Text) },
        {"message_template", new MessageTemplateColumnWriter(NpgsqlDbType.Text) },
        {"level", new LevelColumnWriter(true, NpgsqlDbType.Varchar) },
        {"raise_date", new TimestampColumnWriter(NpgsqlDbType.Timestamp) },
        {"exception", new ExceptionColumnWriter(NpgsqlDbType.Text) },
        {"properties", new LogEventSerializedColumnWriter(NpgsqlDbType.Jsonb) },
        {"props_test", new PropertiesColumnWriter(NpgsqlDbType.Jsonb) },
        {"username", new UserNameColumnWriter(NpgsqlDbType.Varchar) }
    })
    .Enrich.FromLogContext()
    .MinimumLevel.Information()
    .CreateLogger();

builder.Host.UseSerilog(log);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseAuthorization();

app.UseCors();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.MyCustomMiddlewares();

app.MapControllers();

app.Run();
