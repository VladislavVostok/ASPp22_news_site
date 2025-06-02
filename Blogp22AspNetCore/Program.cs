/*
 * Пакеты nuget для работы приложения:
 
		Npgsql.EntityFrameworkCore.PostgreSQL

 */

using Blogp22AspNetCore.Models.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Blogp22AspNetCore
{
	public class Program
	{
		public static void Main(string[] args)
		{

			var config = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json", optional: true)
				.Build();


            var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddDbContext<BlogDBContext>(options => options.UseNpgsql
						(
							builder.Configuration.GetConnectionString("CSPostgres")
						));

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area?}/{controller=Home}/{action=Index}/{id?}"
                );
            });

   //         app.MapControllerRoute(
			//	name: "default",
			//	pattern: "{controller=Home}/{action=Index}/{id?}"
			//);



            // htts://mydomain.ru/Home/Index
            // htts://mydomain.ru/Home/Privacy

            app.Run();
		}
	}
}
