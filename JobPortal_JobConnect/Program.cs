using JobPortal_JobConnect.DBContext;
using JobPortal_JobConnect.Models;
using JobPortal_JobConnect.Repository;
using JobPortal_JobConnect.Services;
using JobPortal_JobConnect.Services.JobPortal_JobConnect.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models; // Import OpenApiModels for Swagger

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<JobPortalDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Identity-related services
builder.Services.AddDefaultIdentity<UserAuthModel>()
    .AddEntityFrameworkStores<JobPortalDbContext>();

// Register your services
builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<IJobRepository, JobRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserAuthService, UserAuthService>();
builder.Services.AddScoped<IUserAuthRepository, UserAuthRepository>();
builder.Services.AddScoped<IApplicationService, ApplicationService>();
builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
builder.Services.AddScoped<ICandidateService, CandidateService>();
builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:3000") // Replace with your React app's origin
                          .AllowAnyMethod()
                          .AllowAnyHeader()
                          .AllowCredentials()); // Add this line to allow credentials (cookies) for CORS
});

// Configure Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Job Portal Connect API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Configure Swagger
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Job Portal Connect API V1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Enable CORS
app.UseCors("AllowSpecificOrigin");

app.MapControllers();

app.Run();
