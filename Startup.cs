using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TickabusWebApp.Database;
using TickabusWebApp.Mappers;
using TickabusWebApp.Repositories;
using TickabusWebApp.Services;

namespace TickabusWebApp
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
            var dbConnectionString = @"Server=(localdb)\mssqllocaldb;Database=Tickabus;Trusted_Connection=True;";
            services.AddDbContext<TickabusContext>(options => options.UseSqlServer(dbConnectionString));

            services.AddControllers();

            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<ITicketRepo, TicketRepo>();

            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ICityRepo, CityRepo>();

            services.AddScoped<ITrackService, TrackService>();
            services.AddScoped<ITrackRepo, TrackRepo>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAuthRepo, AuthRepo>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepo, UserRepo>();

            services.AddSingleton(AutoMapperConfig.Initialize());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
