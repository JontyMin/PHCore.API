using System;
using System.IO;
using System.Reflection;
using Autofac;
using DocumentFormat.OpenXml.EMMA;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;


namespace PH.WebApi
{
    using DbContexts;
    using UnitOfWork;
    using WebCore;
    using Models.Automapper;
    using Services;
    using Component.Aop;
    using Component.Jwt;
    using Filters;
    using WebCore.MultiLanguages;

    public class Startup
    {
        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}
        public ILifetimeScope AutofacContainer { get; private set; }

        public Startup(IWebHostEnvironment env)
        {
            // In ASP.NET Core 3.0 `env` will be an IWebHostingEnvironment, not IHostingEnvironment.
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        //添加autofac的DI配置容器
        public void ConfigureContainer(ContainerBuilder builder)
        {
            //注册IBaseService和IRoleService接口及对应的实现类
            /*builder.RegisterType<BaseService>().As<IBaseService>().InstancePerLifetimeScope();
            builder.RegisterType<TagService>().As<ITagService>().InstancePerLifetimeScope();*/
            //注册aop拦截器 
            //将业务层程序集名称传了进去，给业务层接口和实现做了注册，也给业务层各方法开启了代理
            builder.AddAopService(ServiceExtensions.GetAssemblyName());
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //添加多语言本地化支持
            services.AddMultiLanguages();

            services.AddControllers(options =>
            {
                options.Filters.Add<ApiResultFilter>();
                options.Filters.Add<ApiExceptionFilter>();
            }).AddDataAnnotationsLocalization(options =>
            {
                options.DataAnnotationLocalizerProvider = (type, factory) =>
                    factory.Create(typeof(SharedResource));//给注解添加本地化资源提供器Localizerprovider
            });

            //注册跨域策略
            services.AddCorsPolicy(Configuration);
            //注册webcore服务（网站主要配置）
            services.AddWebCoreService(Configuration);

            services.AddUnitOfWorkService<PHDbContext>(options => { options.UseSqlServer(Configuration.GetSection("ConnectionStrings:PHDbContext").Value); });

            //注册automapper服务
            services.AddAutomapperService();

            //注册jwt服务
            services.AddJwtService(Configuration);

            //注册IBaseService和IRoleService接口及对应的实现类
            /*services.AddScoped<IBaseService, BaseService>();
            services.AddScoped<ITagService, TagService>();*/

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "ProtectHeart API", Version = "v1" });
                // 获取xml文件名
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                // 获取xml文件路径
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                // 添加控制器层注释，true表示显示控制器注释
                options.IncludeXmlComments(xmlPath, true);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //添加多语言本地化支持
            app.UseMultiLanguage(Configuration);

            app.UseRouting();

            //添加跨域
            app.UseCors(WebCoreExtensions.MyAllowSpecificOrigins);

            //添加认证中间件
            app.UseAuthentication();

            app.UseAuthorization();

            //启用中间件服务生成Swagger作为JSON终结点
            app.UseSwagger();
            //启用中间件服务对swagger-ui，指定Swagger JSON终结点
             app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Demo v1");
    });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
