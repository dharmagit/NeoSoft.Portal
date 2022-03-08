using HDFC.Core.CacheProvider;
using HDFC.Core.CacheProvider.Interface;
using HDFC.Core.Common;
using HDFC.WebCommon;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using System;
using System.Text;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Internal;
using NeoSoft.Portal.Data;
using NeoSoft.Portal.Data.Interface;
using NeoSoft.Portal.Business;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.AspNetCore.Mvc.Authorization;




namespace NeoSoft.Portal.Service
{
    public class Startup
    {
        readonly string CorsPolicy = "CorsPolicy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            var contentRoot = configuration.GetValue<string>(WebHostDefaults.ContentRootKey);
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            var key = Encoding.ASCII.GetBytes("NeoSoftMapProject");

            //services.AddCors(options =>
            //{
            //    options.AddPolicy(CorsPolicy,
            //        builder =>
            //        {
            //            builder
            //            .AllowAnyOrigin()
            //            .AllowAnyHeader()
            //            .AllowAnyMethod()
            //            .AllowCredentials();
            //            //.WithOrigins("http://localhost:4200/")
            //        });
            //});



            services.AddHttpContextAccessor();
            services.AddTransient<IMasterRepository, MasterRepository>();


            services.AddTransient<MasterManager>();


            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
            });

            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NeoSoft API", Version = "v1" });
            });

   


            services.AddCors();


            //services.AddMvc(
            //    config =>
            //    {
            //        config.Filters.Add(typeof(MvcExceptionHandler));
            //        //config.Filters.Add(typeof(WebApiErrorHandlerAttribute));
            //    }).AddJsonOptions(opt =>
            //    {
            //        var resolver = opt.SerializerSettings.ContractResolver;
            //        if (resolver != null)
            //        {
            //            var res = resolver as DefaultContractResolver;
            //            res.NamingStrategy = null;  // <<!-- this removes the camelcasing
            //        }
            //    });
            //JWT Token Start

            //services.AddAuthorization(auth =>
            //{
            //    auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
            //        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
            //        .RequireAuthenticatedUser().Build());
            //});

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //})


            //.AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true,
            //        ValidIssuer = Configuration["JsonWebToken:Issuer"],
            //        ValidAudience = Configuration["JsonWebToken:Issuer"],
            //        IssuerSigningKey = new SymmetricSecurityKey(key)
            //    };
            //});
            services.AddMvc();

            //END

       
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {

            app.Use(async (ctx, next) =>
            {
                await next();
                if (ctx.Response.StatusCode == 204)
                {
                    ctx.Response.ContentLength = 0;
                }

              
            });

            // app.use();
            //app.UseDefaultFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                OnPrepareResponse = context =>
                {
                    context.Context.Response.Headers.Add("Cache-Control", "no-cache, no-store");
                    context.Context.Response.Headers.Add("Expires", "-1");
                }
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "NeoSoft API V1");
                c.RoutePrefix = string.Empty;
            });

            NLog.GlobalDiagnosticsContext.Set("defaultConnection", ConfigHelper.AppSetting("PORTAL_LOG", CommonConstants.connectionStrings));

            NLog.LogManager.LoadConfiguration(env.ContentRootPath + "\\NLog.config");




            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            
                app.UseSession();
            
                app.UseAuthentication();


                app.UseCors(CorsPolicy);
            //    app.UseMvc();
            
            }
        }
    }
}
