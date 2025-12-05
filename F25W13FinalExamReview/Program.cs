using F25W13FinalExamReview.Components;
using F25W13FinalExamReview.Data;
using F25W13FinalExamReview.Services;
using Microsoft.EntityFrameworkCore;

namespace F25W13FinalExamReview
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            // register the context class
            var connStr = builder.Configuration.GetConnectionString("ProductConnection");
            builder.Services.AddDbContext<ProductContext>(options => options.UseSqlServer(connStr));

            // register the service class
            builder.Services.AddScoped<ProductService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
