using AutoMapper;
using FileExplorer.Application.FIleStorage.Brokers;
using FileExplorer.Application.Services;
using FIleExplorer.Infrastructure.Common.MapperProfiles;
using FIleExplorer.Infrastructure.FileStorage.Brokers;
using FIleExplorer.Infrastructure.FileStorage.Services;
using System.Reflection;
using Training.FileExplorer.Application.FileStorage.Services;

namespace FileExplorer.Api.Configurations
{
    public static partial class HostConfigurations
    {
        public static WebApplicationBuilder Services(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IDirectoryBroker, DirectoryBroker>()
                .AddScoped<IFileBroker, FIleBroker>()
                .AddScoped<IDriveBroker, DriveBroker>()
                .AddScoped<IFileService, FileService>()
                .AddScoped<IDirectoryService, DirectoryServie>()
                .AddScoped<IDriveService, DriveService>()
                .AddScoped<IDirectoryProcessingService, DirectoryProcessingService>()
                .AddScoped<IDriveProcessingService, DriveProcessingService>();
            return builder;
        }
        public static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen();
            builder.Services.AddEndpointsApiExplorer();
            return builder;
        }

        public static WebApplication UseDevTools(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            return app;
        }
        public static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(policy =>
            {
                policy.AddDefaultPolicy(config =>
                {
                    config.AllowAnyOrigin();
                    config.AllowAnyMethod();
                    config.AllowAnyHeader();
                });
            });

            builder.Services.AddControllers().AddNewtonsoftJson();
            builder.Services.AddRouting();
            return builder;
        }
        public static WebApplicationBuilder AddAutoMapper(this WebApplicationBuilder builder)
        {
            var assemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(Assembly.Load).ToList();
            assemblies.Add(Assembly.GetExecutingAssembly());

            builder.Services.AddAutoMapper(assemblies);

            // Manual registration of automapper
            //var mappingConfig = new MapperConfiguration(mc =>
            //{
            //    mc.AddProfile(new DirectoryProfile());
            //  mc.AddProfile(new FileProfile());
            //    mc.AddProfile(new DriveProfile());
            //});
            //builder.Services.AddSingleton<IMapper>(sp => mappingConfig.CreateMapper());


            return builder;
        }
    }
}
