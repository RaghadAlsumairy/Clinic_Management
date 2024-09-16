using ClinicManagementAPI.Data;
using ClinicManagementAPI.Repositories.Interfaces;
using ClinicManagementAPI.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ClinicManagement.Data;
using ClinicManagement.Application.Services;
using ClinicManagement.Application.Services.patients;

var builder = WebApplication.CreateBuilder(args);





// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ClinicDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ClinicDb")));
builder.Services.AddMediatR(typeof(Program).Assembly);
builder.Services.AddScoped(typeof(ICrudRepository<>), typeof(CrudRepository<>));
builder.Services.AddScoped<IAppointmentServices, AppointmentServices>();
builder.Services.AddScoped<IPatientServices, PatientServices>();



// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ClinicDbContext>();
    context.Database.Migrate();

    DataSeeder.Seed(context);
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
