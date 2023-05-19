using Jumbula.Application;
using Jumbula.Application.Mappers;
using Jumbula.Infrastructure.Data;
using Jumbula.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "bearerAuth"
                        }
                    },
                    new string[] {}
                }
            });
});

builder.Services.AddDbContextFactory<DataContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), sqlOpt =>
        {
            sqlOpt.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
        });
        options.EnableDetailedErrors();
    });

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

var settings = builder.Configuration.GetSection(nameof(AppSettings)).Get<AppSettings>();
builder.Services.AddCustomIdentity(settings.IdentitySettings);
builder.Services.AddJwtAuthentication(settings.JwtSettings);

builder.Services.AddJumbulaServices();

builder.Services.AddAutoMapper(typeof(UserMapperConfiguration).Assembly);

var app = builder.Build();

var dbcontext = app.Services.GetRequiredService<IDbContextFactory<DataContext>>();
DataInitializer.Initialize(dbcontext.CreateDbContext());

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
