using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using webapi.DAL.CRepository;
using webapi.DAL.Database.DatabaseContext;
using webapi.DAL.IRepository;
using webapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EkwatisoDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUserRepository, CUserRepository>();
builder.Services.AddScoped<IAutenticacaoRepository, CAutenticacaoRepository>();
builder.Services.AddScoped<ICategoriaRepository, CCategoriaRepository>();
builder.Services.AddScoped<ICampanhaRepository, CCampanhaRepository>();
builder.Services.AddScoped<IPaisRepository, CPaisRepository>();
builder.Services.AddScoped<IProvinciaRepository, CProvinciaRepository>();
builder.Services.AddScoped<IDoacaoRepository, CDoacaoRepository>();
builder.Services.AddScoped<IGerenteRepository, CGerenteRepository>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddControllers();
builder.Services.AddMemoryCache();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( options => {
    options.SwaggerDoc("v1", new OpenApiInfo{Title = "Ekwatiso monolitic webapi", Version = "v1", Description = "This is the official Ekwatiso Crowfunding webapi solution"});
});
//Add Authentication
builder.Services.AddAuthentication(
    options =>
    {
       options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
       options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }
).AddJwtBearer(options =>{

});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Ekwatiso monolithic webapi");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
