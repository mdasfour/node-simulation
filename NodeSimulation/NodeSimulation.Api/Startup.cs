﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NodeSimulation
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

			services.AddCors(options =>

			options.AddDefaultPolicy(
					builder =>
					{
						/* AllowAnyOrigin is only used since this is development.  If this was going to be deployed to production,
						 * WithOrigin and the domains for this app would be specified.
						 */
						builder.AllowAnyOrigin()
						.AllowAnyHeader()
						.WithMethods("GET", "POST", "PATCH", "PUT", "DELETE");
					}));


			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

			services.AddApiVersioning();

			services.AddApiVersioning(o =>
			{

				o.ReportApiVersions = true;
				o.ApiVersionReader = new UrlSegmentApiVersionReader();
				o.AssumeDefaultVersionWhenUnspecified = true;
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();

			app.UseCors();

			app.UseMvc(routes =>
			{
				routes.MapRoute("default", "{controller}/v{apiVersion}/{action}/{id?}");
			});
		}
	}
}
