using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using StudentAdmin.DataModel;
using StudentAdmin.Interfaces;
using StudentAdmin.Repository;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();

//Validate data assembly find all validated data from solution  
builder.Services.AddValidatorsFromAssemblyContaining(typeof(Program));
 

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






builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IImageRepositiry, ImageRepository>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddAutoMapper(typeof(StartupBase).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AngularAppilication");
app.UseHttpsRedirection();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath,"Sources")),
    RequestPath = "/Sources"
});

app.UseAuthorization();

app.MapControllers();

app.Run();
