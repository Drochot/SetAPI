using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using SetAPI.Data;
using SetAPI.Data;
using SetAPI.models;
using SetAPI.Services;

namespace SetAPI
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
            services.AddDbContext<SetContext>(opt => opt.UseNpgsql
                (Configuration.GetConnectionString("SetConnection")));

            services.AddControllers().AddNewtonsoftJson(s =>
            {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<ISetRepo, SqlSetRepo>();
            services.AddScoped<ISetService, SetService>();


            services.AddCors(options =>
            {
                options.AddPolicy("AllowSet", builder =>
                    builder
                    .WithOrigins("http://localhost:4200/", "http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("AllowSet");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}