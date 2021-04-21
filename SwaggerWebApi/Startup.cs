using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            #region Swagger
            //ע��swagger����
            services.AddSwaggerGen(c =>
            {
                #region ��̬ע��swagger�汾����
                typeof(ApiVersions).GetEnumNames().Reverse().ToList().ForEach(version =>
                {
                    c.SwaggerDoc(version, new OpenApiInfo()
                    {
                        Title = $"{version}:�汾����",
                        Version = version,
                        Description = $"{version}�汾���ڲ���Ҫ������XXXXX"
                    });
                });

                #endregion

                #region ���Token��֤��ť                
                //�����Ȩ
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "������Token����ʽΪ��Bearer ���п�ͷ��",
                    Name = "Authorization",//jwtĬ�ϲ�������
                    In = ParameterLocation.Header,//��jwt�����header��
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"

                });
                //��֤��ʽ���˷�ʽΪȫ�����
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

                #region �������ע��

                //�������ע��
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
            #region Swagger�м��
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
