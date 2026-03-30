using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concreate;
using Business.DependencyResolvers.Autofac;
using DataAccess.Abstract;
using DataAccess.Concreate.EntityFramework;

var builder = WebApplication.CreateBuilder(args);


// 1. ADIM: Autofac'i Fabrika Olarak Tanýtýyoruz
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// 2. ADIM: Yazdýðýmýz Modülü Sisteme Kaydediyoruz
builder.Host.ConfigureContainer<ContainerBuilder>(options =>
{
    options.RegisterModule(new AutofacBusinessModule());
});

// builder.Services.AddSingleton<IProductService, ProductManager>();
// builder.Services.AddSingleton<IProductDal, EfProductDal>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
