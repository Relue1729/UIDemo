using System;

namespace UIDemo.Common.Interfaces
{
    interface IContentDisplay
    {
        IViewModel GetCurrentView();
        void ChangeViewModel(string viewModelName);
    }
}