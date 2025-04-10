using Microsoft.EntityFrameworkCore;
using CapInfraestructura.Context;
using CAPdominioProyectofinal.InterfaceServicio;
using CapAplicacion.Servicio;
using CAPdominioProyectofinal.InterfaceRepository;
using CapInfraestructura.Repository;
using CapDominio.InterfaceFactory;
using CapAplicacion.Factory;
using Cap_Presentacion.Controllers;
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

            builder.Services.AddDbContext<ContextoDB>(options =>
             options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


            // Inyectar dependencias Servicio 
            builder.Services.AddScoped<IUsuarioServicio, ServicioUsuario>();
            builder.Services.AddScoped<ICuentaServicio, ServicioCuenta>();
            builder.Services.AddScoped<IPreguntasServicio, ServicioPreguntas>();

            // Inyectar dependencias Repositorio
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddScoped<ICuentaRepository, CuentaRepository>();
            builder.Services.AddScoped<IPreguntasRepository, PreguntasRepository>();
            builder.Services.AddScoped<IRespuestaRepository, RespuestaRepository>();

            //Inyectar dependencias Factory 
            builder.Services.AddScoped<InterfaceGenery, ServicioFactory>();

            // Inyectar dependencias Adapter
            builder.Services.AddScoped<ServicioRespuestaAdapters>();

            //injection de dependencias strategy 
            builder.Services.AddScoped<InterfaceGenery, ServicioFactory>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
