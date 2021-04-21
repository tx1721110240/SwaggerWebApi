using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SwaggerWebApi.Utilty.CustomApiVersions;

namespace SwaggerWebApi
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
            #region jwt校验
            //使用方法详见https://blog.csdn.net/tx1721110240/article/details/110355328
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,//是否验证Issuer
                    ValidateAudience = true,//是否验证Audience
                    ValidateLifetime = true,//是否验证失效时间
                    ValidateIssuerSigningKey = true,//是否验证SecurityKey
                    ValidAudience = this.Configuration["audience"],//Audience
                    ValidIssuer = this.Configuration["issuer"],//Issuer，这两项和前面签发jwt的设置一致
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.Configuration["SecurityKey"])),//拿到SecurityKey
                    //AudienceValidator = (m, n, z) =>
                    //{
                    //    return m != null && m.FirstOrDefault().Equals(this.Configuration["audience"]);
                    //},//自定义校验规则，可以新登录后将之前的无效
                };
            });
            #endregion

            #region Swagger
            //注册swagger服务
            services.AddSwaggerGen(c =>
            {
                #region 动态注册swagger版本管理
                typeof(ApiVersions).GetEnumNames().Reverse().ToList().ForEach(version =>
                {
                    c.SwaggerDoc(version, new OpenApiInfo()
                    {
                        Title = $"{version}:版本标题",
                        Version = version,
                        Description = $"{version}版本的内部主要包含了XXXXX"
                    });
                });

                #endregion

                #region 添加Token验证按钮                
                //添加授权
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "请输入Token，格式为：Bearer 带有开头的",
                    Name = "Authorization",//jwt默认参数名称
                    In = ParameterLocation.Header,//把jwt存放在header中
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"

                });
                //认证方式，此方式为全局添加
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme{
                             Reference=new OpenApiReference{
                                 Type=ReferenceType.SecurityScheme,
                                 Id="Bearer"
                             }
                        },new string[] { }
                    }
                });
                #endregion

                #region 添加中文注释

                //添加中文注释
                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);
                Console.WriteLine("basePath:   " + basePath);
                var commentsFileName = typeof(Program).Assembly.GetName().Name + ".XML";
                Console.WriteLine("commentsFileName:   " + commentsFileName);
                var xmlPath = Path.Combine(basePath, commentsFileName);
                c.IncludeXmlComments(xmlPath);

                #endregion

                //c.SwaggerDoc("v1", new OpenApiInfo { Title = "SwaggerWebApi", Version = "v1" });
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            #region Swagger中间件
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                typeof(ApiVersions).GetEnumNames().Reverse().ToList().ForEach(version =>
                {
                    c.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"{version}");
                });
            });

            // app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SwaggerWebApi v1"));
            #endregion

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
