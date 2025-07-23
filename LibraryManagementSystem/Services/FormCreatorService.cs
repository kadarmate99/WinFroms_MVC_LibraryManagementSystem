using LibraryManagementSystem.Controllers;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Services
{
    public class FormCreatorService : IFormCreatorService
    {
        private readonly IServiceProvider _serviceProvider;

        public FormCreatorService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }
        
        public DialogResult ShowBookAddForm()
        {
            // Manually create a scope for this dialog operation
            using var scope = _serviceProvider.CreateScope(); // Create the new scope 
            IServiceProvider scopedServiceProvider = scope.ServiceProvider; // Get the scoped service provider to resolve services within this scope

            // Get services from the scoped provider
            var editForm = scopedServiceProvider.GetRequiredService<BookEditorForm>(); // Instance created
            var editController = scopedServiceProvider.GetRequiredService<BookEditorController>(); // Gets same instance

            editController.InitializeForAdd();

            // Show the form as a modal dialog
            var result = editForm.ShowDialog(); // the scope is disposed when the dialog is closed

            return result;
        }

        public DialogResult ShowBookEditForm(Book bookToEdit)
        {
            using var scope = _serviceProvider.CreateScope();
            IServiceProvider scopedServiceProvider = scope.ServiceProvider;

            var editForm = scopedServiceProvider.GetRequiredService<BookEditorForm>();
            var editController = scopedServiceProvider.GetRequiredService<BookEditorController>();

            editController.InitializeForEdit(bookToEdit);

            var result = editForm.ShowDialog();

            return result;
        }
    }
}
