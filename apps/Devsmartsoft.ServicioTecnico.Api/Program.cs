using Devsmartsoft.ServicioTecnico.Api.Middleware;
using Devsmartsoft.ServicioTecnicoApi.Core.Application.Dependences;
using Devsmartsoft.ServicioTecnicoApi.Infrastructure.Persistence.Dependences;
using Devsmartsoft.ServicioTecnicoApi.Infrastructure.Persistence.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Configura JSON options aquí
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

// Add services to the container.
builder.Services.InjectApplication();
builder.Services.InjectPersistence();
builder.Services.AddSignalR();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("SignalRCorsPolicy", builder =>
//    {
//        // En desarrollo, puedes abrir todo; en producción, restringir a dominios concretos
//        builder
//            .WithOrigins("https://localhost:7055", "http://localhost:7055", "https://10.0.2.2:7055", "http://10.0.2.2:5000")
//            .AllowAnyHeader()
//            .AllowAnyMethod()
//            .AllowCredentials(); // Necesario para SignalR con Auth/cookies
//    });
//});


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

//app.UseCors("SignalRCorsPolicy");

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseAuthorization();

app.MapHub<OrderHub>("/orderHub");
app.MapHub<ChatHub>("/chatHub");

app.MapControllers();

app.Run();
