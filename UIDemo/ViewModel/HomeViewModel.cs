using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UIDemo.Common;
using UIDemo.Common.Interfaces;
using UIDemo.Model;

namespace UIDemo.ViewModel
{
    class HomeViewModel : ViewModelBase
    {
        override public IModel Model          { get; } = new HomeModel();
        public List<string> NewsHeaders       { get; private set; }
        public RelayCommand ChangeViewCommand { get; }
        public string CurrentTimeString => DateTime.Now.ToString("HH:mm");
        public string AlarmTimeString   => $"⏰ {(Model as HomeModel).AlarmTime:HH:mm}";

        public HomeViewModel(IContentDisplay contentDisplay)
        {
            ChangeViewCommand = new RelayCommand(x => contentDisplay.ChangeViewModel((string) x));

            HelperFunctions.PutActionOnTimer(() => OnPropertyChanged(nameof(CurrentTimeString)), new TimeSpan(0, 1, 0));

            _ = InitializeAsync();
        }
        private async Task InitializeAsync()
        {
            NewsHeaders = await (Model as HomeModel).GetTopNewsHeaders();
            OnPropertyChanged(nameof(NewsHeaders));
        }
    }
}