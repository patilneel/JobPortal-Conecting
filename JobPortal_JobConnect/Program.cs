using JobPortal_JobConnect.DBContext;
using JobPortal_JobConnect.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<JobPortalDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IJobRepository, JobRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
/*builder.Services.AddSwaggerGen(c =>
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
});*/




app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
