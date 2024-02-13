using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SortieApp.Application;
using SortieApp.Infrastructure;
using Microsoft.OpenApi.Models;
using AutoMapper;
using SortieWebApp;
using Microsoft.AspNetCore.Hosting;
using FluentValidation;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddAutoMapper(typeof(MappingProfile));
//Ajout de la classe d'extension ConfigureApplicationService()
builder.Services.ConfigureApplicationService()
                .ConfigureInfrastructureService();
/*builder.Services.AddAutoMapper(// Replace Program with any type within your application
    typeof(MappingProfile)
);*/
builder.Services.AddControllers();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
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
