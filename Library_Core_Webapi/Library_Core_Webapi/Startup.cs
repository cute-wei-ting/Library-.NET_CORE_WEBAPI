using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library_Core_Webapi.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;

namespace Library_Core_Webapi
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

		public IConfiguration Configuration { get; }
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}
		public void ConfigureServices(IServiceCollection services)
		{

			services.AddControllers().AddNewtonsoftJson(options =>
			{
				// Use the default property (Pascal) casing
				options.SerializerSettings.ContractResolver = new DefaultContractResolver();
			});
			services.AddScoped<IBookService,BookService>();
			services.AddCors(options =>
			{
				// CorsPolicy 是自訂的 Policy 名稱
				options.AddPolicy("DefaultPolicy", policy =>
				{
					policy.AllowAnyOrigin()
						  .AllowAnyHeader()
						  .AllowAnyMethod();
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

			app.UseRouting();
			app.UseCors("DefaultPolicy");
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapGet("/", async context =>
				{
				   await context.Response.WriteAsync("Hello World!");
				 });
				endpoints.MapControllers();
			});
					
		}
	}
}
