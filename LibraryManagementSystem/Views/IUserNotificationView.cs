using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Views
{
    /// <summary>
    /// Defines methods for displaying messages and errors to the user.
    /// </summary>
    public interface IUserNotificationView
    {
        void ShowMessage(string message);
        void ShowError(string error);
    }
}
