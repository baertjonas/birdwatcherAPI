using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using birdwatcherAPI.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace birdwatcherAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<BirdwatcherContext>(
            //    options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")
            //    )
            //);

            services.AddDbContext<BirdwatcherContext>(
                options => options.UseMySQL(
                    Configuration.GetConnectionString("DefaultConnection")
                )
            );

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = "https://accounts.google.com"; //uitgever van het token
                options.Audience = "770599447037-lp0oo9sl51718eimbps29v7oqk39719j.apps.googleusercontent.com"; //client-id
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateAudience = true,
                    ValidIssuer = "accounts.google.com"
                };
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, BirdwatcherContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication(); //AUTHENTICATION

            app.UseAuthorization(); //AUTHORIZATION

            app.UseCors(builder =>
                builder.AllowAnyOrigin()
                       .WithOrigins("http://birdwatcherclient.ew.r.appspot.com")
                       .WithOrigins("https://birdwatcherclient.ew.r.appspot.com")
                       .WithOrigins("http://localhost:4200")
                       .WithOrigins("https://localhost:4200")
                       .WithOrigins("http://192.168.1.43:4200")
                       .WithOrigins("https://192.168.1.43:4200")
                       .AllowAnyMethod()
                       .AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            DBInitializer.Initialize(context);          
                    
        }
    }
}
