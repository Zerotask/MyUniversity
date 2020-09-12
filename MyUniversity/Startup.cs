using GraphiQl;
using GraphQL;
using GraphQL.Server;
using GraphQL.Types;
using GraphQL.SystemTextJson;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyUniversity.Data;
using MyUniversity.GraphQL;
using MyUniversity.GraphQL.Types;
using MyUniversity.Repositories;

namespace MyUniversity
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Infrastructure
            //services.AddControllers();
            services.Configure<KestrelServerOptions>(options => options.AllowSynchronousIO = true);
            services.Configure<IISServerOptions>(options => options.AllowSynchronousIO = true);

            // MongoDB & Repositories
            services.AddSingleton<DbContext>();
            services.AddScoped<CourseRepository>();

            // GraphQL
            services.AddScoped<IDocumentExecuter, DocumentExecuter>();
            services.AddScoped<IDocumentWriter, DocumentWriter>();
            services.AddScoped<CourseType>();
            services.AddScoped<AppQuery>();
            services.AddScoped<ISchema, AppSchema>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Test
            //app.UseRouting();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});

            // GraphQL
            app.UseGraphiQl();
            app.UseGraphQL<AppSchema>();
        }
    }
}