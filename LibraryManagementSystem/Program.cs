using LibraryManagementSystem.Controllers;
using LibraryManagementSystem.Services;
using LibraryManagementSystem.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var builder = Host.CreateApplicationBuilder();

            // Services
            builder.Services.AddSingleton<IBookService, BookService>();
            builder.Services.AddSingleton<IFormCreatorService, FormCreatorService>();


            // Main form - singleton since it's the primary window
            builder.Services.AddSingleton<MainBookCatalogForm>();
            // Register multiple interfaces for the same form instance
            builder.Services.AddSingleton<IBookCatalogView>(provider => provider.GetRequiredService<MainBookCatalogForm>());
            builder.Services.AddSingleton<IUserNotificationView>(provider => provider.GetRequiredService<MainBookCatalogForm>());
            builder.Services.AddSingleton<ILoadingIndicatorView>(provider => provider.GetRequiredService<MainBookCatalogForm>());

            // Editor form - scoped to create new instances for each dialog
            builder.Services.AddScoped<BookEditorForm>();
            builder.Services.AddScoped<IBookEditorView>(provider => provider.GetRequiredService<BookEditorForm>());
            builder.Services.AddScoped<IUserNotificationView>(provider => provider.GetRequiredService<BookEditorForm>());
            builder.Services.AddScoped<IFormValidation>(provider => provider.GetRequiredService<BookEditorForm>());

            // Controllers
            builder.Services.AddSingleton<BookCatalogController>();
            builder.Services.AddScoped<BookEditorController>();

            using IHost host = builder.Build();

            Form? mainForm = host.Services.GetRequiredService<IBookCatalogView>() as Form;
            var controller = host.Services.GetRequiredService<BookCatalogController>();

            // Initialize the controller to load initial data
            controller.Initialize();

            if (mainForm != null)
            {
                Application.Run(mainForm);
            }
        }
    }
}