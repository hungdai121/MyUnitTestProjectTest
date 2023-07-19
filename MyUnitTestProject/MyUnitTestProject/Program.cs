using Microsoft.OpenApi.Models;
using MyUnitTestProject.Infrastructure;
using MyUnitTestProject.Models;
using MyUnitTestProject.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My_Unit_test", Version = "v1" });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Seed data
//using (var context = new ApplicationDbContext())
//{
//    var users = new List<User>
//            {
//                new User{Id = 1, Name = "Hung", Age = 24, Nation = "VietNam"},
//                new User{Id = 2, Name = "Joe", Age = 17, Nation = "NetherLand"},
//                new User{Id = 3, Name = "Sean", Age = 21, Nation = "Mexico"},
//                new User{Id = 4, Name = "Daniel", Age = 16, Nation = "Mexico"},
//                new User{Id = 5, Name = "Layla", Age = 23, Nation = "China"},
//                new User{Id = 6, Name = "Fin", Age = 30, Nation = "America"},
//                new User{Id = 7, Name = "Cassidy", Age = 41, Nation = "America"},
//                new User{Id = 8, Name = "Alex", Age = 11, Nation = "England"},
//            };
//    context.Users.AddRange(users);

//    context.SaveChanges();
//}

builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddScoped<IUserService, UserService>();


var app = builder.Build();

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
