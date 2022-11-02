using Microsoft.EntityFrameworkCore;
using REST___JavaScript_from_user_stories.DBContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAll",
            		          policy =>
                      {
                        		  policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                      });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RecordContext>(opt => opt.UseSqlServer(Secrets.connectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.
    app.UseSwagger();
    app.UseSwaggerUI();

app.UseCors("AllowAll");


app.UseAuthorization();

app.MapControllers();

app.Run();
