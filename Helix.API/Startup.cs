using System.Reflection;
using Helix.Core.Commands.Posts;
using Helix.Core.Queries.Posts;
using Helix.Infrastructure.Database;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Helix.API
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
            var appSettings = ReadAppSettings(Configuration);
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("Policy1",
            //    builder => builder.WithOrigins("http://localhost:8080"));
            //});

            services.AddMediatR(typeof(Startup));
            services.AddControllers();

            services.AddSingleton<ICommandHandler>(factory => new CommandHandler(appSettings.HelixDBConnection));
            services.AddSingleton<IQueryHandler>(factory => new QueryHandler(appSettings.HelixDBConnection));


            // Commands
            services.AddMediatR(typeof(CreatePostCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdatePostCommand).GetTypeInfo().Assembly);

            // Queries
            services.AddTransient<IPostQueries>(factory => new PostQueries(factory.GetRequiredService<IQueryHandler>()));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseCors("AllowMyOrigin");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private AppSettings ReadAppSettings(IConfiguration configuration)
        {
            var appSettings = new AppSettings();

            appSettings.HelixDBConnection = configuration.GetConnectionString("HelixDB");

            return appSettings;
        }
    }
}
