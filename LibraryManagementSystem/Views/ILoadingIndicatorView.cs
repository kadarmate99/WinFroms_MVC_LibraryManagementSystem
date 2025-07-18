using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Views
{
    public interface ILoadingIndicatorView
    {
        void ShowLoading(bool isLoading);
    }
}
