using FluentValidation;
using GenialNet.Api.Configurations;
using GenialNet.Application.Fornecedores.Commands.AtualizarFornecedor;
using GenialNet.Application.Fornecedores.Commands.CadastrarFornecedor;
using GenialNet.Application.Mapper;
using GenialNet.Application.Produtos.Commands.CadastrarProduto;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureDatabaseServices(builder.Configuration);
builder.Services.ConfigureServices();

builder.Services.AddAutoMapper(typeof(FornecedorProfile).Assembly);
builder.Services.AddAutoMapper(typeof(ProdutoProfile).Assembly);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(GenialNet.Application.AssemblyReference.Assembly));

builder.Services.AddValidatorsFromAssemblyContaining<CadastrarProdutoValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<CadastrarFornecedorValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<AtualizarFornecedorValidation>();

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
