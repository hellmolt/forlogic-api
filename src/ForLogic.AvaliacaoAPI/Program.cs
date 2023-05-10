using AutoMapper;
using ForLogic.AvaliacaoAPI.Config;
using ForLogic.AvaliacaoAPI.Model.Context;
using ForLogic.AvaliacaoAPI.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ForLogic.AvaliacaoAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connection = builder.Configuration["SQlConnection:SQlConnectionString"];
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            // Add services to the container.
            IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
            builder.Services.AddSingleton(mapper);
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddDbContext<SQLContext>(options => options.UseSqlServer(connection, o => o.MigrationsAssembly("ForLogic.AvaliacaoAPI")));

            builder.Services.AddScoped<IAvaliacaoRepository, AvaliacaoRepository>();
            builder.Services.AddScoped<IAvaliacaoClienteRepository, AvaliacaoClienteRepository>();
            builder.Services.AddControllers();
            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ForLogic Avaliacao API", Version = "v1" });
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
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ForLogic Avaliacao API");
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}