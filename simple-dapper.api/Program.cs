using Asp.Versioning;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using simple_dapper.application.Services.Implementations;
using simple_dapper.application.Services.Interfaces;
using simple_dapper.domain.Interfaces;
using simple_dapper.infrastructure.dapper.Repositories;
using simple_dapper.infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

#region Services

builder.Services.AddControllers();
builder.Services.AddOpenApi();


builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ReportApiVersions = true;
});

#region DI

// repos
builder.Services.AddScoped<INoteRepository, DapperNoteRepository>();

//services
builder.Services.AddScoped<INoteService, NoteService>();

#endregion

builder.Services.AddDbContext<ApplicationContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

#endregion

var app = builder.Build();

#region Middlewares

app.UseHttpsRedirection();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.MapScalarApiReference(options =>
    {
        options.WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.RestSharp);


        //.WithTheme(ScalarTheme.Purple)
        //.WithTitle("alipour")
        //.WithApiKeyAuthentication(keyOptions => keyOptions.Token = "apiToken");
        //.WithPreferredScheme("ApiKey");
    });
}

app.Run();

#endregion