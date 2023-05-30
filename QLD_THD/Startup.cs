using BusinesslogicLayer;
using DataAccessLayer;
using DataModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLD_THD
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
            services.AddCors(options => {
                options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            services.AddDbContext<QLD_THDContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DevConnection"));
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "<title>", Version = "v1" });
            });
            services.AddTransient<IMonHocRepository, MonHocRepository>();
            services.AddTransient<IMonHocBusiness, MonHocBusiness>();
            services.AddControllers();
            services.AddTransient<IKhoiRepository, KhoiRepository>();
            services.AddTransient<IKhoiBusiness, KhoiBusiness>();
            services.AddControllers();
            services.AddTransient<ILopRepository, LopRepository>();
            services.AddTransient<ILopBusiness, LopBusiness>();
            services.AddControllers();
            services.AddTransient<IHocSinhRepository, HocSinhRepository>();
            services.AddTransient<IHocSinhBusiness, HocSinhBusiness>();
            services.AddControllers();
            services.AddTransient<IGiaoVienRepository, GiaoVienRepository>();
            services.AddTransient<IGiaoVienBusiness, GiaoVienBusiness>();
            services.AddControllers();
            services.AddTransient<ILoaiDiemRepository, LoaiDiemRepository>();
            services.AddTransient<ILoaiDiemBusiness, LoaiDiemBusiness>();
            services.AddControllers();
            services.AddTransient<IDiemRepository, DiemRepository>();
            services.AddTransient<IDiemBusiness, DiemBusiness>();
            services.AddControllers();
            services.AddTransient<ICtietDiemRepository, CtietDiemRepository>();
            services.AddTransient<ICtietDiemBusiness, CtietDiemBusiness>();
            services.AddControllers();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserBusiness, UserBusiness>();
            services.AddControllers();
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IAccountBusiness, AccountBusiness>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "<title> v1"));
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("AllowAll");
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
