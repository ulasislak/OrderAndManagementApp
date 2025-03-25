using BusinnesLogic.AbstractServices;
using BusinnesLogic.ConcreteServices;
using BusinnesLogic.MappingProfiles;
using DataAccess.AbstractRepository;
using DataAccess.ConcreteRepository;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using OrderAndManagementApp.MappersProfile;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<OrderAndManagmentDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(MappingsProfile), (typeof(MappersProfile)));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(ICostumerService), typeof(CostumerService));
builder.Services.AddScoped(typeof(IOrderService), typeof(OrderService));
builder.Services.AddScoped(typeof(IOwnerService), typeof(OwnerService));
builder.Services.AddScoped(typeof(IProductService), typeof(ProductService));

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
