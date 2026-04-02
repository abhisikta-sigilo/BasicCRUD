using StudentManagementSystem.Data;
using StudentManagementSystem.Repositories.Abstractions;
using StudentManagementSystem.Repositories.Implementations;
using StudentManagementSystem.Services.Abstractions;
using StudentManagementSystem.Services.Implementations;

using StudentManagementSystem.Mappings;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddSingleton<DapperContext>();

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();

builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();


//builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(
    cfg => { },
    //typeof(MappingProfile).Assembly
    AppDomain.CurrentDomain.GetAssemblies()
);

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
