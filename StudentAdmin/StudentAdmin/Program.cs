using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StudentAdmin.DataModel;
using StudentAdmin.Repository;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddControllers();
var connString = builder.Configuration.GetConnectionString("StudentAdminPortalDb");
builder.Services.AddDbContext<StudentAdminContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("StudentAdminPortalDb"));
});
 builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200/")
                          .AllowAnyHeader()
                          .WithMethods("GET", "POST", "PUT", "DELETE")
                          .WithExposedHeaders("*");
                          
                      });
});


builder.Services.AddScoped<IStudentRepository, SqlStudentRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
