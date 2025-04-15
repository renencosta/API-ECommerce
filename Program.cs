using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

//O .NET vai criar os objetos (Injeção de dependência)
//ADDTransient - O C# cria uma instancia nova, toda vez que um método é chamado.
//ADDScoped - O C# cria uma instancia nova, toda vez que criar um Controller
//ADDSingleton
builder.Services.AddScoped<EcommerceContext, EcommerceContext>();
builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>(); 
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IItemPedidoRepository, ItemPedidoRepository>();
builder.Services.AddTransient<IPagamentoRepository, PagamentoRepository>();
builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.MapControllers();

app.Run();
