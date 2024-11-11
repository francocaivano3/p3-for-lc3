using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Services;
using Infrastructure;
using Infrastructure.Data.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using static Infrastructure.Services.AuthenticationService;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options => //para conectar la api con lc3
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:5174") // Permite el origen del frontend
                          .AllowAnyMethod()
                          .AllowAnyHeader()
                          .AllowCredentials()); // Permite enviar cookies si es necesario
});
builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.AddSecurityDefinition("EventManagerApiBearerAuth", new OpenApiSecurityScheme() //Esto va a permitir usar swagger con el token.
    {
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        Description = "Pegar el token generado al loguearse."
    });

    setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "EventManagerApiBearerAuth" } //Tiene que coincidir con el id seteado arriba en la definici�n
                }, new List<string>() }
    });

});


var connection = new SqliteConnection("Data Source = DB-Ejemplo.db");
connection.Open();

using (var command = connection.CreateCommand())
{
    command.CommandText = "PRAGMA journal_mode = DELETE;";
    command.ExecuteNonQuery();
}

builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlite(connection, b => b.MigrationsAssembly("Infrastructure")));

builder.Services.AddAuthentication("Bearer") //"Bearer" es el tipo de auntenticaci�n que tenemos que elegir despu�s en PostMan para pasarle el token
    .AddJwtBearer(options => //Ac� definimos la configuraci�n de la autenticaci�n. le decimos qu� cosas queremos comprobar. La fecha de expiraci�n se valida por defecto.
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["AutenticacionService:Issuer"],
            ValidAudience = builder.Configuration["AutenticacionService:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["AutenticacionService:SecretForKey"]))
        };
    }
);

builder.Services.AddAuthorization(options => {
    options.AddPolicy("Client", policy => policy.RequireRole("Client", "SuperAdmin"));
    options.AddPolicy("EventOrganizer", policy => policy.RequireRole("EventOrganizer", "SuperAdmin"));
    options.AddPolicy("SuperAdmin", policy => policy.RequireRole("SuperAdmin"));
});

builder.Services.AddScoped<IEventRepository, EventRepository>(); 
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.Configure<AutenticacionServiceOptions>(
    builder.Configuration.GetSection(AutenticacionServiceOptions.AutenticacionService));
builder.Services.AddScoped<IEventOrganizerRepository,  EventOrganizerRepository>();
builder.Services.AddScoped<IEventOrganizerService, EventOrganizerService>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();


var app = builder.Build();
app.UseCors("AllowSpecificOrigin"); //lc3
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
