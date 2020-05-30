using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Three.Services;

namespace Three
{
    ///运行时通过约定，在项目启动的时候会调用这里面的两个方法
    public class Startup
    {
        //主要配置一些依赖注入相关的东西，.net core 已经带有IOC相关的了，不需要使用第三方的库
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Transient  每次都有新的实例
            //Scoped   每个WEB请求一个实例
            //Singleton  单个实例
            services.AddControllers();  //这种是比较推荐的，比较轻，没有视图，非常适合WEB API ，不在推荐使用mvc
            services.AddSingleton<IClock,ChinaClock>();  //如果Iclock实例请求的时候，就返回ChianClock
        }

        //管道，中间件是有先后顺序的
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //
            if (env.IsDevelopment())
            {
                //如果是在开发环境，就在页面里面显示异常信息
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();  //使用静态文件
            //app.UseHttpsRedirection();  //将HTTP请求转换为HTTPS请求
            //app.UseAuthentication();  //身份验证

            //路由
            app.UseRouting();

            //端点
            app.UseEndpoints(endpoints =>
            {
                // endpoints.MapGet("/", async context =>
                // {
                //     await context.Response.WriteAsync("Hello World!");
                // });
                endpoints.MapControllerRoute(
                    name:"default",
                    pattern:"{controller=Home}/{action=Index}/{id?}"
                );  //这种是路由表的形式

                //endpoints.MapControllers();  //这种地址适合在控制器里面配置路由地址
            });
        }
    }
}
