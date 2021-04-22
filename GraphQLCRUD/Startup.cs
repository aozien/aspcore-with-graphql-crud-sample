using GraphQLCRUD.GraphQL;
using GraphQLCRUD.GraphQL.Types;
using GraphQLCRUD.Services.Implementations;
using GraphQLCRUD.Services.Interfaces;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLCRUD
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ISubjectService, SubjectService>();
            services.AddSingleton<IStudentService, StudentService>();

            services.AddGraphQL(x => SchemaBuilder.New()
                                                 .AddServices(x)
                                                 .AddType<SubjectType>()
                                                 .AddType<StudentType>()
                                                 .AddQueryType<Query>()
                                                 .AddMutationType<Mutation>()
                                                 .Create()
                                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UsePlayground(new PlaygroundOptions { 
                 QueryPath="/api",
                 Path="/playground"
                });
            }

            app.UseGraphQL("/api");
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}


/** github.com/aozien **/