﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyWebApp.Models;

namespace MyWebApp
{
	public class Startup
	{
		public Startup(IHostingEnvironment env)
		{
			//Configuration = configuration;
			var builder = new ConfigurationBuilder()
			   .SetBasePath(env.ContentRootPath)
			   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
			   .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
			   .AddEnvironmentVariables();
			Configuration = builder.Build();
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});

			
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

			string coonection = string.Format(Configuration["ConnectionString"], Configuration["HOSTNAME_MYSQL"], Configuration["PORT_NAME"],
				Configuration["MYSQL_DATABASE"], Configuration["MYSQL_USER"], Configuration["MYSQL_PASSWORD"]);

			services.Add(new ServiceDescriptor(typeof(MusicStoreContext), new MusicStoreContext(coonection)));
			//services.Add(new ServiceDescriptor(typeof(MusicStoreContext), new MusicStoreContext(Configuration["ConnectionString"])));
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
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();
			app.UseCookiePolicy();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Albums}/{action=Index}/{id?}");
			});
		}
	}
}
