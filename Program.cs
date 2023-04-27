using System.Text.Json.Serialization;
using enterprise.Data;
using enterprise.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EnterpriseDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnection"));
});
builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
builder.Services.AddScoped<IEmpresaService, EmpresaService>();
builder.Services.AddScoped<IDepartamentoService, DepartamentoService>();
builder.Services.AddScoped<IFuncionarioService, FuncionarioService>();
builder.Services.AddScoped<ITarefaService, TarefaService>();

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
