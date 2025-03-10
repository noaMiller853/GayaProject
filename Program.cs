using WebApplicationUser.Models;
using GayaProject.Interfaces;
using GayaProject.Repository;
using GayaProject.Services;
using Microsoft.EntityFrameworkCore; // Add this using directive

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton<IOperatorFactoryService, OperatorFactoryService>();
builder.Services.AddSingleton<IOperatorService, AddOperatorService>();
builder.Services.AddSingleton<IOperatorService, SubtractOperationService>();
builder.Services.AddSingleton<IOperatorService, MultiplyOperationService>();
builder.Services.AddSingleton<IOperatorService, DivideOperationService>();
builder.Services.AddSingleton<IOperatorFactoryService, OperatorFactoryService>();

builder.Services.AddScoped<ICalculateRepository, CalculateRepository>();
builder.Services.AddScoped<ICalculateService, CalculateService>();




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
               policy =>
               {
                   policy.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
               });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
