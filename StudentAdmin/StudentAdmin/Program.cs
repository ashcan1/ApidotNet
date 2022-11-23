using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StudentAdmin.DataModel;
using StudentAdmin.Repository;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<StudentAdminContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("StudentAdminPortalDb"));
});

    builder.Services.AddCors((options) =>
 {
     options.AddPolicy("AngularAppilication", (builder) =>
     {
                            builder.WithOrigins("http://localhost:4200")
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
app.UseCors("AngularAppilication");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
