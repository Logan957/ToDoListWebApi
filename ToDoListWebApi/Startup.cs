using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ToDoListWebApi.DataBase;
using ToDoListWebApi.DataBase.Repositories.ToDoCollection;
using ToDoListWebApi.DataBase.Repositories.Users;
using ToDoListWebApi.Middleware;
using ToDoListWebApi.Services.ToDoCollection;
using ToDoListWebApi.Services.Users;

namespace ToDoListWebApi
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ToDoListWebApi", Version = "v1" });
            });

            services.AddDbContext<DatabaseContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("Database")));

            services.AddScoped(typeof(ToDoService));
            services.AddScoped<UserService>();

            services.AddScoped(typeof(IToDoRepository), typeof(ToDoRepository));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));

           
            services.AddAutoMapper(typeof(UserProfile));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDoListWebApi v1"));
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
                app.UseMiddleware<ExceptionHandlerMiddleware>();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
