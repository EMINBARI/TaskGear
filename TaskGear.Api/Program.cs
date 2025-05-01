using Microsoft.EntityFrameworkCore;
using TaskGear.Application.Services;
using TaskGear.Core.Repositories;
using TaskGear.Infrastructure.Sqlite;
using TaskGear.Infrastructure.Sqlite.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SqliteContext>(options =>
    options.UseSqlite ("Data Source=../DB/task_gear.db",
        x => x.MigrationsAssembly("TaskGear.Infrastructure")
    )
);

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();

