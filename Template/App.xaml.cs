using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Windows;
using Template.Domain.Models;
using Template.Domain.Services;
using Template.Domain.Services.AuthenticationServices;
using Template.EntityFramework;
using Template.EntityFramework.Services;
using Template.ModelingAPI;
using Template.ModelingAPI.Services;
using Template.WPF.State.Authenticators;
using Template.WPF.State.Navigators;
using Template.WPF.State.Users;
using Template.WPF.ViewModels;
using Template.WPF.ViewModels.Factories;

namespace Template.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = CreateHostBuilder().Build();
        }

        public static IHostBuilder CreateHostBuilder(string[] args = null)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(c =>
                {
                    c.AddJsonFile("appsettings.json");
                    c.AddEnvironmentVariables();
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddHttpClient<DictionaryModelingHttpClient>(c =>
                    {
                        c.BaseAddress = new Uri("https://api.dictionaryapi.dev/api/v2/entries/en/");
                    });
                    services.AddSingleton<IDictionaryDataService, DictionaryDataService>();

                    string connectionString = context.Configuration.GetConnectionString("sqlite");
                    Action<DbContextOptionsBuilder> configureDbContext = o => o.UseSqlite(connectionString);

                    services.AddDbContext<TemplateDbContext>(configureDbContext);
                    services.AddSingleton<TemplateDbContextFactory>(new TemplateDbContextFactory(configureDbContext));

                    services.AddSingleton<IUserService, UserDataService>();
                    //services.AddSingleton<IDataService<User>, GenericDataService<User>>();

                    services.AddSingleton<IAuthenticator, Authenticator>();
                    services.AddSingleton<IAuthenticationService, AuthenticationService>();
                    services.AddSingleton<IUserStore, UserStore>();

                    services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();

                    services.AddSingleton<ITemplateViewModelFactory, TemplateViewModelFactory>();

                    services.AddTransient<HomeViewModel>(services => new HomeViewModel());
                    services.AddSingleton<DictionaryViewModel>();
                    services.AddTransient<LoginViewModel>();
                    services.AddTransient<RegisterViewModel>();

                    services.AddSingleton<CreateViewModel<HomeViewModel>>(services =>
                    {
                        return () => services.GetRequiredService<HomeViewModel>();
                    });
                    services.AddSingleton<CreateViewModel<DictionaryViewModel>>(services =>
                    {
                        return () => services.GetRequiredService<DictionaryViewModel>();
                    });
                    services.AddSingleton<CreateViewModel<LoginViewModel>>(services =>
                    {
                        return () => services.GetRequiredService<LoginViewModel>();
                    });
                    services.AddSingleton<CreateViewModel<RegisterViewModel>>(services =>
                    {
                        return () => services.GetRequiredService<RegisterViewModel>();
                    });

                    services.AddSingleton<INavigator, Navigator>(x => new Navigator(
                        x.GetRequiredService<CreateViewModel<HomeViewModel>>(),
                        x.GetRequiredService<CreateViewModel<LoginViewModel>>(),
                        x.GetRequiredService<CreateViewModel<RegisterViewModel>>()));

                    services.AddScoped<MainViewModel>();
                    services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));
                });
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            TemplateDbContextFactory contextFactory = _host.Services.GetRequiredService<TemplateDbContextFactory>();
            using (TemplateDbContext context = contextFactory.CreateDbContext())
            {
                context.Database.Migrate();
            }

            Window window = _host.Services.GetRequiredService<MainWindow>();
            window.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();

            base.OnExit(e);
        }
    }
}