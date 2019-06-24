using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using server.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace server.Configurations
{
    public class Authentication : StartupConfig
    {

        public Authentication(IHostingEnvironment env, IConfiguration config) : base(env, config) { }

        public override IServiceProvider ConfigureServices(IServiceCollection services)
        {

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();//clear default settings

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = Config["Issuer"],
                    ValidAudience = Config["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Config["Key"])),
                    ClockSkew = TimeSpan.Zero // remove delay of token when expire
                };
            });

            return null;
        }

        public override void Configure(IApplicationBuilder app)
        {
            app.UseAuthentication();
        }

    }
}