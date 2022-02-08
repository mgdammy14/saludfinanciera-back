using ApiBusinessModel.Implementation;
using ApiBusinessModel.Implementation.Client;
using ApiBusinessModel.Implementation.General;
using ApiBusinessModel.Implementation.Mensajes;
using ApiBusinessModel.Implementation.Pagos;
using ApiBusinessModel.Implementation.Permission;
using ApiBusinessModel.Implementation.Person;
using ApiBusinessModel.Implementation.Prestamos;
using ApiBusinessModel.Implementation.Rol;
using ApiBusinessModel.Implementation.Users;
using ApiBusinessModel.Interfaces.Client;
using ApiBusinessModel.Interfaces.General;
using ApiBusinessModel.Interfaces.Mensajes;
using ApiBusinessModel.Interfaces.Pagos;
using ApiBusinessModel.Interfaces.Permission;
using ApiBusinessModel.Interfaces.Person;
using ApiBusinessModel.Interfaces.Prestamos;
using ApiBusinessModel.Interfaces.Rol;
using ApiBusinessModel.Interfaces.Url;
using ApiBusinessModel.Interfaces.Users;
using ApiDataAccess.General;
using ApiUnitOfWork.General;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Factura
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
            var key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>("SecretKey"));

            services.AddAuthentication(x => {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => {
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

            services.AddScoped<ILoginLogic, LoginLogic>();
            services.AddScoped<IUsersLogic, UsersLogic>();
            services.AddScoped<IEncryptLogic, EncryptLogic>();
            services.AddScoped<IRolLogic, RolLogic>();
            services.AddScoped<IUrlLogic, UrlLogic>();
            services.AddScoped<IPermissionLogic, PermissionLogic>();
            services.AddScoped<ISMSLogic, SMSLogic>();
            services.AddScoped<IClientLogic, ClientLogic>();
            services.AddScoped<ILoanLogic, LoanLogic>();
            services.AddScoped<IPaymentScheduleLogic, PaymentScheduleLogic>();
            services.AddScoped<IPaymentLogic, PaymentLogic>();
            services.AddScoped<IMessageLogic, MessageLogic>();
            services.AddScoped<IUploadFileLogic, UploadFileLogic>();
            services.AddScoped<IBankLogic, BankLogic>();
            services.AddScoped<ILoanAmountLogic, LoanAmountLogic>();
            services.AddScoped<IPersonLogic, PersonLogic>();

            services.AddSingleton<IUnitOfWork>(option => new UnitOfWork(
                    Configuration.GetConnectionString("production-azure")
                ));

            services.AddAuthorization(auth => {
                auth.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build();
            });

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SaludFinanciera", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                        Enter 'Bearer' [space] and then your token in the text input below.
                        \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                   {
                        {
                            new OpenApiSecurityScheme
                            {
                            Reference = new OpenApiReference
                                {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                                },
                                Scheme = "oauth2",
                                Name = "Bearer",
                                In = ParameterLocation.Header,

                            },
                            new List<string>()
                            }
                   });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x
               .AllowAnyMethod()
               .AllowAnyHeader()
               .SetIsOriginAllowed(origin => true) // allow any origin
               .AllowCredentials()); // a

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SaludFinanciera v1"));
        }
    }
}
