using Infra;
using Domain.Users;
using Domain.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Domain.Authentication;
using Microsoft.EntityFrameworkCore;
using Domain.Exams;
using Domain.AswerExams;

namespace WebAPI
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
            services.AddCors(options =>
            {
                options.AddPolicy("any",
                    builder =>
                    {
                        builder
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowAnyOrigin();
                    }
                );
            });

            services.AddControllers();

            // services.AddSingleton(typeof (IRepository<>), typeof (RepositoryInMemory<>));
            services.AddScoped(typeof (IRepository<>), typeof (Repository<>));
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IExamsRepository, ExamsRepository>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IExamsService, ExamsService>();
            services.AddScoped<IExamsRepository, ExamsRepository>();
            services.AddScoped<IAswerExamsRepository, AswerExamsRepository>();
            services.AddScoped<IAswerExamsService, AswerExamsService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("any");
            using (var db = new BrasileiraoContext())
            {
                // Este comando irá criar o banco de dados (quando ele ainda não existir)
                db.Database.Migrate();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
