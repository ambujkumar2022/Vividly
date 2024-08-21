﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Vividly;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    // Configure Dependency Injection Object
    public void ConfigureServices(IServiceCollection services)
    {
        //services.AddControllersWithViews();
        //services.AddScoped<CustomerDBContext>();

        // Add any other services required by the application
        // For example:
        // services.AddDbContext<MyDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        // services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<MyDbContext>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    // Configure MiddleWare
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) 
    {
        app.UseMiddleware<CustomAuthentication>();
        //app.UseMiddleware<LogRequest>();
        //app.UseMiddleware<CheckSecurity>();
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication(); // If using authentication
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}
