﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EfcoreSQLiteApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services
                .AddScopedWithShellRoute<MainPage, MainPageViewModel>($"//{nameof(MainPage)}")
                .AddScopedWithShellRoute<LoginPage, LoginPageViewModel>($"//{nameof(LoginPage)}")
                .AddDbContext<MyContext>(options => 
                    options.UseSqlite($"Filename={Path.Combine(FileSystem.AppDataDirectory, "EfcoreSQLiteApp.db3")}",
                        x => x.MigrationsAssembly("EfcoreSQLiteAppContext")));

            return builder.Build();
        }
    }
}
