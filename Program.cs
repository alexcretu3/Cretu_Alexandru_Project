using Cretu_Alexandru_Project.Data;
using Cretu_Alexandru_Project.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Globalization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Cretu_Alexandru_ProjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Cretu_Alexandru_ProjectContext") ?? throw new InvalidOperationException("Connection string 'Cretu_Alexandru_ProjectContext' not found.")));

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<LanguageService>();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddMvc().AddViewLocalization().AddDataAnnotationsLocalization(options =>
{
    options.DataAnnotationLocalizerProvider = (type, factory) =>
    {
        var assemblyName = new AssemblyName(typeof(ShareResource).GetTypeInfo().Assembly.FullName);
        return factory.Create("SharedResource", assemblyName.Name);
    };
});

builder.Services.Configure<RequestLocalizationOptions>(
    options =>
    {
        var supportedCultures = new List<CultureInfo>
            {
                            new CultureInfo("ro-RO"),
                            new CultureInfo("en-US"),
            };

        options.DefaultRequestCulture = new RequestCulture(culture: "ro-RO", uiCulture: "ro-RO");
        options.SupportedCultures = supportedCultures;
        options.SupportedUICultures = supportedCultures;

        options.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider());
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else { app.UseDeveloperExceptionPage(); }

var locOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(locOptions.Value);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapGet("/API/GetPrice", context =>
    {
        var salaId = context.Request.Query["salaId"];
        var echipamentId = context.Request.Query["echipamentId"];

        if (string.IsNullOrEmpty(salaId) || string.IsNullOrEmpty(echipamentId))
        {
            context.Response.StatusCode = 400;
            return context.Response.WriteAsync("Invalid query parameters");
        }

        int salaIdInt;
        int echipamentIdInt;
        if (!int.TryParse(salaId, out salaIdInt) || !int.TryParse(echipamentId, out echipamentIdInt))
        {
            context.Response.StatusCode = 400;
            return context.Response.WriteAsync("Invalid query parameters");
        }

        return context.Response.WriteAsync(JsonConvert.SerializeObject(new GetPriceModel(context.RequestServices.GetService<Cretu_Alexandru_ProjectContext>()).OnGet(salaIdInt, echipamentIdInt).Value));

    });
    app.MapRazorPages();
});




app.Run();
