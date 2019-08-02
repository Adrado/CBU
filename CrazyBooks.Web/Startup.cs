using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrazyBook.Lib.DA;
using CrazyBooks.Lib.Core;
using CrazyBooks.Lib.DA.EFCore;
using CrazyBooks.Lib.DAL;
using CrazyBooks.Lib.DAL.Repositories;
using CrazyBooks.Lib.Models;
using CrazyBooks.Lib.Services;
using CrazyBooks.Web.Helpers;
using CrazyBooks.Web.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace CrazyBooks.Web
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
            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();

            services.AddDbContext<CrazybooksContext>(options => options.UseSqlServer(appSettings.DbConnection,
                b => b.MigrationsAssembly("CrazyBooks.Web")));

            InjectDependencies(services);

            // configure jwt authentication
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void InjectDependencies(IServiceCollection services)
        {
            // DbSets
            services.AddScoped<IDbSet<Admin>, AdminsDbSet>();
            services.AddScoped<IDbSet<Book>, BooksDbSet>();
            services.AddScoped<IDbSet<Member>, MembersDbSet>();
            services.AddScoped<IDbSet<Room>, RoomsDbSet>();
            services.AddScoped<IDbSet<User>, UsersDbSet>();
            services.AddScoped<IDbSet<Lend>, LendsDbSet>();
            services.AddScoped<IDbSet<Reservation>, ReservationsDbSet>();

            // Repositories
            services.AddScoped<IRepository<Admin>, AdminsRepository>();
            services.AddScoped<IRepository<Book>, GenericRepository<Book>>();
            services.AddScoped<IRepository<Member>, GenericRepository<Member>>();
            services.AddScoped<IRepository<Room>, GenericRepository<Room>>();
            services.AddScoped<IRepository<User>, GenericRepository<User>>();
            services.AddScoped<IRepository<Lend>, GenericRepository<Lend>>();
            services.AddScoped<IRepository<Reservation>, GenericRepository<Reservation>>();

            // Crud Services
            services.AddScoped<ICrudService<Admin>, ActiveDirectoryAdminService>();
            services.AddScoped<ICrudService<Book>, GenericCrudService<Book>>();
            services.AddScoped<ICrudService<Member>, GenericCrudService<Member>>();
            services.AddScoped<ICrudService<Room>, GenericCrudService<Room>>();
            services.AddScoped<ICrudService<User>, GenericCrudService<User>>();
            services.AddScoped<ICrudService<Lend>, GenericCrudService<Lend>>();
            services.AddScoped<ICrudService<Reservation>, GenericCrudService<Reservation>>();

            // Other Services
            services.AddScoped<IRegisterService, RegisterService>();
            services.AddScoped<ILoginService, JwtLoginService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
