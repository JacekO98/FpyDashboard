using FPYDashboard.Components;
using Microsoft.EntityFrameworkCore;
using FPYDashboard.Plugins.EFCoreSqlServer;
using FPY.UseCase;
using FPY.UseCase.Interfaces;

using Plugins.EFCoreSql;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FpyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FPYDashboard")));
// Add services to the container.
builder.Services.AddRazorComponents();
builder.Services.AddScoped<IFpyEFCoreRepository, FpyEFCoreRepository>();
builder.Services.AddScoped<IGetHydrBVResultsWeeklyFpyUseCase, GetHydrBVResultsWeeklyFpyUseCase>();
builder.Services.AddScoped<IGetHydrBVResultsMonthlyFpyUseCase, GetHydrBVResultsMonthlyFpyUseCase>();
builder.Services.AddScoped<IGetHydrResultsWeeklyFpyUseCase, GetHydrResultsWeeklyFpyUseCase>();
builder.Services.AddScoped<IGetHydrResultsMonthlyFpyUseCase, GetHydrResultsMonthlyFpyUseCase>();
builder.Services.AddScoped<IGetPneuResultsWeeklyFpyUseCase, GetPneuResultsWeeklyFpyUseCase>();
builder.Services.AddScoped<IGetPneuResultsMonthlyFpyUseCase, GetPneuResultsMonthlyFpyUseCase>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{

    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection(); 

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>();

app.Run();
