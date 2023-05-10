using AutoMapper;
using ForLogic.ClienteAPI.Config;
using ForLogic.ClienteAPI.Model.Context;
using ForLogic.ClienteAPI.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ForLogic.ClienteAPI
{
    public class Program
    {
        public IConfiguration Configuration { get; }

        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            var connection = builder.Configuration["SQlConnection:SQlConnectionString"];
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            // Add services to the container.
            IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
            builder.Services.AddSingleton(mapper);
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddDbContext<SQLContext>(options => options.UseSqlServer(connection, o => o.MigrationsAssembly("ForLogic.ClienteAPI")));

            builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ForLogic Client API", Version = "v1" });
            });
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader();
                                  });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ForLogic Client API");
                });
            }

            app.UseHttpsRedirection();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}