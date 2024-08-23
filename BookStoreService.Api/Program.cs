using BookStoreService.Application;
using BookStoreService.Domain.DomainServices;
using BookStoreService.Domain.Interfaces.DomainServices;
using BookStoreService.Domain.Interfaces.Repositories;
using BookStoreService.Infrastructure.Data;
using BookStoreService.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDbContext<BookStoreDbContext>(options => options.UseSqlite("Data Source=bookstore.db"));

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookDomainService, BookDomainService>();

builder.Services.AddApplicationServices();

builder.Services.AddMemoryCache(options =>
{
    options.SizeLimit = 1024 * 1024; // 1MB
});

builder.Services.AddHealthChecks();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader(),
        new HeaderApiVersionReader("X-Api-Version"));
});

#region authentication
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//.AddJwtBearer(options =>
//{
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//        ValidIssuer = builder.Configuration["jwt:ValidIssuer"],
//        ValidAudience = builder.Configuration["jwt:ValidAudience"],
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["jwt:IssuerSigningKey"] ?? throw new Exception()))
//    };
//});
#endregion

builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "BookStore API V1");
    });
}

app.UseHealthChecks("/health");

app.UseHttpsRedirection();

#region authentication
//app.UseAuthentication();
//app.UseAuthorization();
#endregion

app.MapControllers();

app.Run();
