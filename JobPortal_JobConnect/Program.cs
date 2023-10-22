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

//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:3000") // Replace with your React app's origin
                          .AllowAnyMethod()
                          .AllowAnyHeader());
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
app.MapControllers();

app.Run();



/*using JobPortal_JobConnect.DBContext;
using JobPortal_JobConnect.Repository;
using JobPortal_JobConnect.Services;
using JobPortal_JobConnect.Services.JobPortal_JobConnect.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<JobPortalDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<JobService, JobService>();
builder.Services.AddScoped<IJobRepository, JobRepository>();
builder.Services.AddScoped<UserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserAuthService, UserAuthService>();
builder.Services.AddScoped<IUserAuthRepository, UserAuthRepository>();
builder.Services.AddScoped<ApplicationService, ApplicationService>();
builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
builder.Services.AddScoped<CandidateService, CandidateService>();
builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
*//*builder.Services.AddSwaggerGen(c =>
{
    // ... other configuration settings

    c.TagActionsBy(api =>
    {
        if (api.GroupName == "UserAuthenticationController")
            return "1. UserAuthenticationController"; // Order the Authentication group first
        if (api.GroupName == "User")
            return "2. User"; // Order the User group second
        return "3. Other"; // Order other controllers last
    });

    // ... other configuration settings
});*//*




app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
*/