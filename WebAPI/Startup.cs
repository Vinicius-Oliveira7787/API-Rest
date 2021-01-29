using Infra;
using Domain.Users;
using Domain.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Domain.Authentication;
using Domain.AnswerSheets;
using Microsoft.EntityFrameworkCore;
using Domain.Answers;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

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

            services.AddSingleton(typeof (IRepository<>), typeof (RepositoryInMemory<>));
            // services.AddScoped(typeof (IRepository<>), typeof (Repository<>));
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IAnswersRepository, AnswersRepository>();
            services.AddScoped<IAnswersService, AnswersService>();
            services.AddScoped<IAnswerSheetsRepository, AnswerSheetsRepository>();
            services.AddScoped<IAnswerSheetsService, AnswerSheetsService>();
            services.AddScoped<IAuthService, AuthService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // app.UseCors("any");
            // using (var db = new BrasileiraoContext())
            // {
            //     db.Database.Migrate();
            // }

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
