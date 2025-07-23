using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Services
{
    public interface IFormCreatorService
    {
        DialogResult ShowBookAddForm();
        DialogResult ShowBookEditForm(Book bookToEdit);
    }
}
