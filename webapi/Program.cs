using Microsoft.EntityFrameworkCore;
using webapi.DAL.CRepository;
using webapi.DAL.Database.DatabaseContext;
using webapi.DAL.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EkwatisoDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUserRepository, CUserRepository>();
builder.Services.AddScoped<ICategoriaRepository, CCategoriaRepository>();
builder.Services.AddScoped<ICampanhaRepository, CCampanhaRepository>();
builder.Services.AddScoped<IPaisRepository, CPaisRepository>();
builder.Services.AddScoped<IProvinciaRepository, CProvinciaRepository>();
builder.Services.AddScoped<IDoacaoRepository, CDoacaoRepository>();
builder.Services.AddScoped<IGerenteRepository, CGerenteRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Add Authentication
builder.Services.AddAuthorization(
    options =>
    {
       
    }
);
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
