using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using N64.Identity.Application.Common.Identity.Service;
using N64.Identity.Application.Common.NotificationService;
using N64.Identity.Application.Common.Settings;
using N64.Identity.Infrastructure.Common.Identity.Services;
using N64.Identity.Infrastructure.Common.NotificationService;
using N64.Identity.Persistence.DataContext;
using System.Text;

namespace N64.Identity.Api.Configurations
{
    public static partial class HostConfiguration
    {
        private static WebApplicationBuilder AddIdentityInfrastructure(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<VerificationTokenSettings>(builder.Configuration.GetSection(nameof(VerificationTokenSettings)));
            builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(nameof(JwtSettings)));

            builder.Services.AddDataProtection();

            builder.Services
                .AddTransient<IAccessTokenGeneratorService, AccessTokenGeneratorService>()
                .AddTransient<IPasswordHasher, PasswordHasher>()
                .AddTransient<IVerificationCodeGeneratorService, VerificationTokenGeneratorService>()
                .AddTransient<IVerificationCodeGeneratorService, VerificationCodeGeneratorService>();

            builder.Services
                .AddScoped<IAuthService, AuthService>()
                .AddScoped<IAccountService, AccountService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<ITokenService, TokenService>();
                

            var jwtSettings = new JwtSettings();
            builder.Configuration.GetSection(nameof(JwtSettings)).Bind(jwtSettings);
            builder
                .Services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = jwtSettings.ValidateIssuer,
                        ValidIssuer = jwtSettings.ValidIssuer,
                        ValidAudience = jwtSettings.ValidAudience,
                        ValidateAudience = jwtSettings.ValidateAudience,
                        ValidateLifetime = jwtSettings.ValidateLifetime,
                        ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSigningKey,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
                    };
                });
            return builder;
        }
        private static WebApplicationBuilder AddNotificationInfrastructure(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<EmailSenderSettings>(builder.Configuration.GetSection(nameof(EmailSenderSettings)));
            builder.Services.AddScoped<IEmailOrchestrationService, EmailOrchestrationService>();
            return builder;
        }
        private static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>();
            return builder;
        }
        private static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen();
            builder.Services.AddEndpointsApiExplorer();
            return builder;
        }
        private static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
        {
            builder.Services.AddRouting(options => options.LowercaseUrls = true);
            builder.Services.AddControllers();
            return builder;
        }
        private static WebApplication UseIdentityInfrastructure(this WebApplication app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
            return app;
        }
        private static WebApplication UseDevTools(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            return app;
        }
        private static WebApplication UseExposers(this WebApplication app)
        {
            app.MapControllers();
            return app;
        }
    }
}
