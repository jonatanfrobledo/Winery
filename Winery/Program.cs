using Winery.Repository;
using Winery.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Obtener la cadena de conexión desde appsettings.json
var connectionString = builder.Configuration.GetConnectionString("WineryConnection");

// Agregar el contexto de base de datos con SQLite
builder.Services.AddDbContext<WineryContext>(options =>
    options.UseSqlite(connectionString));

// Configuración de JWT
var secretKey = builder.Configuration["Authentication:SecretForKey"];
var key = Encoding.ASCII.GetBytes(secretKey);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = builder.Configuration["Authentication:Issuer"],
        ValidAudience = builder.Configuration["Authentication:Audience"],
        ValidateLifetime = true, // Valida la expiración del token
        ClockSkew = TimeSpan.Zero // Elimina la tolerancia para la expiración del token
    };
});

// Agregar servicios al contenedor
builder.Services.AddControllers();

// Inyectar repositorios y servicios
builder.Services.AddScoped<WineRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<IWineService, WineService>();
builder.Services.AddScoped<IUserService, UserService>();

// Agregar Swagger para documentación de la API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Middleware para la autenticación
app.UseAuthentication(); // Asegura que se use la autenticación antes de la autorización
app.UseAuthorization();

app.MapControllers();

app.Run();
