using AutoMapper;
using InterviewProject.Services;

namespace InterviewProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webBuilder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            webBuilder.Services.AddControllersWithViews();
            webBuilder.Services.AddTransient<ITaxService, TaxJarService>();
            //webBuilder.Services.AddAutoMapper(typeof(StartupBase));
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            });
            webBuilder.Services.AddSingleton<IMapper>(sp => config.CreateMapper());

            var app = webBuilder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/TaxCalculator/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=TaxCalculator}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
