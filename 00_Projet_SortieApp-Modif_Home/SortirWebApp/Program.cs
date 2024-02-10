using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SortieApp.Application;
using SortieApp.Infrastructure;
using Microsoft.OpenApi.Models;
using AutoMapper;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Ajout de la classe d'extension ConfigureApplicationService()
builder.Services.ConfigureApplicationService()
                .ConfigureInfrastructureService();
builder.Services.AddControllers();
//builder.Services.AddAutoMapper();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});
// builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());

//app.UseAuthorization();
/*
app.MapRazorPages();*/

app.Run();
