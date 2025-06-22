using Microsoft.EntityFrameworkCore;
using AreaYVolumenApi.Data;       // Asegúrate que este using apunta a donde está tu DbContext
using AreaYVolumenApi.Services;   // Servicio que contiene la lógica de cálculo

var builder = WebApplication.CreateBuilder(args);

// ✅ Registrar el DbContext con la cadena de conexión "DefaultConnection"
builder.Services.AddDbContext<MangaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ Registrar los servicios personalizados
builder.Services.AddScoped<AreaYVolumenService>();

// ✅ Registrar los controladores
builder.Services.AddControllers();

// ✅ Configurar Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ✅ Configurar puerto local
builder.WebHost.UseUrls("http://localhost:5000");

// ✅ Habilitar Swagger siempre
app.UseSwagger();
app.UseSwaggerUI();

// ✅ Redirección HTTPS y mapeo de rutas
app.UseHttpsRedirection();
app.MapControllers();

Console.WriteLine("La API está por iniciar...");
app.Run();