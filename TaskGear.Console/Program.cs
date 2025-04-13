﻿
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskGear.Application.Services;
using TaskGear.Application.Services.Contracts;
using TaskGear.Core.Repositories;
using TaskGear.Infrastructure.Sqlite;
using TaskGear.Infrastructure.Sqlite.Repositories;

IServiceCollection services = new ServiceCollection();

services.AddDbContext<SqliteContext>(options =>
    options.UseSqlite("Data Source=../DB/task_gear.db",
        x => x.MigrationsAssembly("TaskGear.Infrastructure")
    )
);

services.AddScoped<IUserService, UserService>();
services.AddScoped<IUserRepository, UserRepository>();

var provider = services.BuildServiceProvider();

var userService = provider.GetRequiredService<IUserService>();

await userService.AddUserAsync(
    new AddUserRequest { Name = "Homer Simpson", Email = "homer@mail.com", ImageUrl = null, PasswordHash = "doh!" }
);

var users = await userService.GetUsersAsync();

foreach (var u in users)
{
    Console.WriteLine($"{u.Name} | {u.Email}");
}




// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.DependencyInjection;
// using TaskGear.Application.Services;
// using TaskGear.Application.Services.Contracts;
// using TaskGear.Core.Repositories;
// using TaskGear.Infrastructure.Sqlite;
// using TaskGear.Infrastructure.Sqlite.Repositories;

// IServiceCollection services = new ServiceCollection();



// services.AddDbContext<SqliteContext>(options => options.UseSqlite("Data Source=taskgear.db"));

// services.AddScoped<IUserService, UserService>();
// services.AddScoped<IUserRepository, UserRepository>();

// var provider = services.BuildServiceProvider();

// using (var scope = provider.CreateScope())
// {
//     var db = scope.ServiceProvider.GetRequiredService<SqliteContext>();
//     db.Database.Migrate();
// }

// var userService = provider.GetRequiredService<IUserService>();

// await userService.AddUserAsync(
//     new AddUserRequest { Name = "Emin", Email = "emin@mail.com", ImageUrl = null, PasswordHash = "80jl834kj" }
// );

// var users = await userService.GetUsersAsync();

// foreach (var u in users)
// {
//     Console.WriteLine($"{u.Name} | {u.Email}");
// }


