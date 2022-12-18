using EJournal.DataAcces.DbContexts;

using EJournal.DataAcces.Interfaces;
using EJournal.DataAcces.Interfaces.Students;
using EJournal.DataAcces.Interfaces.Teachers;
using EJournal.DataAcces.Services;
using EJournal.DataAcces.Services.Students;
using EJournal.DataAcces.Services.Teachers;
using EJournal.Service.Interfaces;
using EJournal.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<IFileService, FIleService>();

//Database
string connection = builder.Configuration.GetConnectionString("database");
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connection,b => b.MigrationsAssembly("e-Journal.Api")));


var app = builder.Build();
app.UseStaticFiles();

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
