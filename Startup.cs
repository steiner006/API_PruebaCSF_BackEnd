using Microsoft.EntityFrameworkCore;
using PruebaCSF.Data;

namespace PruebaCSF
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // Método para configurar los servicios en el contenedor de dependencias
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", builder =>
                {
                    builder.WithOrigins("http://localhost:4200") // URL de tu frontend
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            // Configuración del contexto de Entity Framework con SQL Server
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("PruebaCSF2")));

            // Agregar controladores de API
            services.AddControllers();

            // Agregar soporte para Swagger
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // Configurar CORS si es necesario
            services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", policy =>
                {
                    policy.WithOrigins("http://localhost:4200")  // Cambia esto por tu URL de frontend
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });
        }

        // Método para configurar el pipeline de la aplicación
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Si estamos en un entorno de desarrollo, habilitar Swagger
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Middleware para HTTPS
            app.UseHttpsRedirection();

            // Configuración de routing
            app.UseRouting();

            // Habilitar CORS
            app.UseCors("AllowFrontend");

            // Habilitar autorización
            app.UseAuthorization();

            // Mapear los controladores
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

}
