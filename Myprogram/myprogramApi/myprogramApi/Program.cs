using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using myprogramApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddFluentValidation(x =>
{
    x.ImplicitlyValidateChildProperties = true;
    x.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
}
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyProgramDbContext>(Options =>
Options.UseSqlServer(builder.Configuration.GetConnectionString("MyprogramConnectionString")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseAuthorization();

app.MapControllers();

app.Run();
