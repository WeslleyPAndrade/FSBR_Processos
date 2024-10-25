using FSBR_Processos.Domain.Interfaces;
using FSBR_Processos.Domain;
using FSBR_Processos.Models.Context;
using FSBR_Processos.Repository.Interfaces;
using FSBR_Processos.Repository;
using FSBR_Processos.Services.Interfaces;
using FSBR_Processos.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();
builder.Services.AddScoped<IIBGEService, IBGEService>();
builder.Services.AddScoped<IProcessoRepository, ProcessoRepository>();
builder.Services.AddScoped<IProcessosDomain, ProcessosDomain>();

builder.Services.AddDbContext<ProcessoDbContext>(options =>
    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Processos}/{action=Index}/{id?}");

app.Run();
