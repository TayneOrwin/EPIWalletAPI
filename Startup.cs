using AutoMapper;
using EPIWalletAPI.Models;
using EPIWalletAPI.Models.AccessRole;
using EPIWalletAPI.Models.Employee;
using EPIWalletAPI.Models.Identity;
using EPIWalletAPI.Models.Vendor;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EPIWalletAPI
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
            services.AddCors(options => options.AddDefaultPolicy(
                   include =>
                   {
                       include.AllowAnyHeader();
                       include.AllowAnyMethod();
                       include.AllowAnyOrigin();
                   }));




            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EPIWalletAPI", Version = "v1" });
            });


            services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.Configure<ApplicatonSettings>(Configuration.GetSection("ApplicationSettings"));

            //Injuct User 
            IdentityBuilder builder = services.AddIdentityCore<ApplicationUser>();


            builder = new IdentityBuilder(builder.UserType, builder.Services);

            builder.AddRoles<IdentityRole>();

            builder.AddSignInManager<SignInManager<ApplicationUser>>();

            builder.AddEntityFrameworkStores<AppDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
            }
            );



           
            services.AddAutoMapper(Assembly.GetExecutingAssembly());




            //Jwt Authentication

            var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWT_Secret"].ToString());

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });

















            services.AddControllers();
            

            services.AddDbContext<AppDbContext>(options => 
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IExpenseTypeRepository, ExpenseTypeRepository>();
            services.AddScoped<ISponsorRepository, SponsorRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeAddressRepository, EmployeeAddressRepository>();
            services.AddScoped<IGuestRepository, GuestRepository>();
            services.AddScoped<IVendorRepository, Models.Vendor.VendorRepository>();
            services.AddScoped<IVendorAddressRepository, Models.Vendor.VendorAddressRepository>();
            services.AddScoped<IExpenseRequestRepository, ExpenseRequestRepository>();
            services.AddScoped<IExpenseItemRepository, ExpenseItemRepository>();
            services.AddScoped<IEventInviteRepository, EventInviteRepository>();
            services.AddScoped<IAccessRoleRepository, AccessRoleRepository>();
            services.AddScoped<ITopUpRequestRepository, TopUpRequestRepository>();
            services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            services.AddScoped<IExpenseLineRepository, ExpenseLineRepository>();
            services.AddScoped<IEmployeeBankingDetailsRepository, EmployeeBankingDetailsRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EPIWalletAPI v1"));
            }

            app.UseHttpsRedirection();


            app.UseCors(x => x
           .AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader());
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
