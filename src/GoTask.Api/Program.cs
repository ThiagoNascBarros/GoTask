using GoTask.Api.Filter;
using GoTask.Application;
using GoTask.Infra;
using GoTask.Infra.Migrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();
builder.Services.Injection(builder.Configuration);
builder.Services.AddUseCases();
builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionGlobalFilter)));
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: "AllowAllOrigins",
//        configurePolicy: policy =>
//        {
//            policy.AllowAnyOrigin()
//                .AllowAnyHeader()
//                .AllowAnyMethod();
//        });
//    options.AddPolicy(name: "AllowOnlySomeOrigins",
//        configurePolicy: policy =>
//        {
//            policy.WithOrigins("http://localhost:4200/");
//        });
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHealthChecks("/health");

app.UseCors(configurePolicy: policy =>
{
    policy.WithOrigins("http://localhost:4200/");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await MigrateDatabase();

app.Run();

async Task MigrateDatabase()
{
    await using var scope = app.Services.CreateAsyncScope();
    await DataBaseMigration.MigrateDatabase(scope.ServiceProvider);
}