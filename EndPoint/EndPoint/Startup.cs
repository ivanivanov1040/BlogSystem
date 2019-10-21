using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EndPoint.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace EndPoint
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
            var conn = Configuration["ConnectionStrings:DefaultConnection"];
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddIdentity<ApplicationUserModel, ApplicationRoleModel>()
                .AddEntityFrameworkStores<BlogContext>()
                .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequiredLength = 3;
                o.Password.RequiredUniqueChars = 0;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;                
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = "https://localhost:44354",
                        ValidAudience = "https://localhost:44354/",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))
                    };
                });

            services.AddDbContext<BlogContext>(o => o.UseSqlServer(conn));
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, UserManager<ApplicationUserModel> userManager, RoleManager<ApplicationRoleModel> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }


            SeedDatabase.SeedDatabase.SeedData(userManager, roleManager);

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
