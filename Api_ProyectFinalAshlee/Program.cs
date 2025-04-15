using Microsoft.EntityFrameworkCore;
using CapInfraestructura.Context;
using CAPdominioProyectofinal.InterfaceServicio;
using CapAplicacion.Servicio;
using CapInfraestructura.Repository;
using CapDominio.InterfaceFactory;
using CapAplicacion.Factory;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Net.Http.Headers;
using CapDominio.InterfaceRepository;
using CapDominio.InterfaceServicio;
using CapDominio.Entity;
using CapInfraestructura.Repository.CapInfraestructura.Repository;

namespace Cap_Presentacion
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("NewPolicy", app =>
                {
                    app.WithOrigins("http://127.0.0.1:5500").AllowAnyHeader().AllowAnyMethod();
                });
            });

            // Create HttpClient instance
            var client = new HttpClient();

            // Configuracion de autenticacion JWT
            string tokenGenerado = "your_generated_token_here"; // Add this line to define the token
            client.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Bearer", tokenGenerado);


            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "http://localhost:1347", // Reemplaza con el emisor de tus tokens
                        ValidAudience = "http://localhost:1347", // Reemplaza con la audiencia de tus tokens
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("claveSecretaMuyLargaYSegura12345")),
                        ClockSkew = TimeSpan.Zero
                    };
                });

            builder.Services.AddDbContext<ContextoDB>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Inyectar dependencias Servicio 
            builder.Services.AddScoped<IUsuarioServicio, ServicioUsuario>();
            builder.Services.AddScoped<ITestService, TestService>();
            builder.Services.AddScoped<IPreguntasServicio, ServicioPreguntas>();
            builder.Services.AddTransient<ITestService , TestService>();


            // Inyectar dependencias Repositorio
            builder.Services.AddScoped<IUsuarioRepositoryGenery, UsuarioRepositoryGenery>();
            builder.Services.AddScoped<ITestRepository, TestRepository>();
            builder.Services.AddScoped<IPreguntaRepositoryGenery, PreguntaRepositoryGenery>();
            builder.Services.AddScoped<IRespuestaRepositoryGenery, Respuestarepositorygenery>();

            // Inyectar dependencias Factory 
            builder.Services.AddScoped<InterfaceGenery, ServicioFactory>();

            
            // Inyectar dependencias Adapter
            builder.Services.AddScoped< ServicioRespuestaAdapters>();

            // Inyeccion de dependencias strategy 
            builder.Services.AddScoped<InterfaceGenery, ServicioFactory>();

            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("NewPolicy");

            app.MapControllers();

            app.Run();
        }
    }
}
