using System;
using System.Collections.Generic;
using System.Windows;
using UIDemo.Common;
using UIDemo.Common.Interfaces;
using UIDemo.Model;

namespace UIDemo.ViewModel
{
    class MainViewModel : ViewModelBase, IContentDisplay
    {
        #region Fields & Properties 
        public override IModel Model { get; } = new MainModel();
        public RelayCommand ChangeViewCommand        { get; }
        public RelayCommand CloseWindowCommand       { get; }
        public RelayCommand ChangeWindowStateCommand { get; }

        public IDictionary<string, bool> RadioButtonChecks { get; set; }

        readonly IDictionary<string, IViewModel> viewModels;

        private IViewModel currentView;
        public IViewModel CurrentView
        {
            get => currentView;
            private set
            {
                currentView = value;
                OnPropertyChanged();
            }
        }

        private double contentBorderWidth;
        public double ContentBorderWidth
        {
            get => contentBorderWidth;
            private set
            {
                contentBorderWidth = value;
                OnPropertyChanged(nameof(ContentBorderClip));
                OnPropertyChanged();
            }
        }
        public Rect ContentBorderClip => new Rect(-50, 0, ContentBorderWidth + 50, MainWindow.Height);
        public double MenuBorderWidth { get; } = 200;

        Window MainWindow = Application.Current.MainWindow;

        #endregion
        public MainViewModel()
        {
            ContentBorderWidth = MainWindow.Width - MenuBorderWidth;

            viewModels = new Dictionary<string, IViewModel>()
            {
                { nameof(HomeViewModel),    new HomeViewModel(this) },
                { nameof(PhotoViewModel),   new PhotoViewModel() },
                { nameof(SystemViewModel),  new SystemViewModel() },
                { nameof(WeatherViewModel), new WeatherViewModel() },
                { nameof(MessageViewModel), new MessageViewModel() }
            };

            RadioButtonChecks = new Dictionary<string, bool>()
            {
                { "HomeViewModel",     true },
                { "WeatherViewModel",  false },
                { "SystemViewModel",   false },
                { "PhotoViewModel",    false },
                { "MessageViewModel",  false }
            };

            CurrentView = viewModels[nameof(HomeViewModel)];

            ChangeViewCommand        = new RelayCommand(x => ChangeViewModel((string) x));
            ChangeWindowStateCommand = new RelayCommand(x => ChangeWindowState((string) x));
            CloseWindowCommand       = new RelayCommand(x => Application.Current.Shutdown());
        }
        public void ChangeViewModel(string viewModelName)
        { 
            if (viewModels.TryGetValue(viewModelName, out var viewModel))
            {
                CurrentView = viewModel;

                RadioButtonChecks[viewModelName] = true;
                OnPropertyChanged(nameof(RadioButtonChecks));
            }
        }
        public void ChangeWindowState (string state)
        {
            Enum.TryParse(state, out WindowState stateEnum);

            switch (stateEnum)
            {
                case WindowState.Maximized :
                    bool isMaximized = MainWindow.WindowState == WindowState.Maximized;
                    MainWindow.WindowState = isMaximized ? WindowState.Normal : WindowState.Maximized;
                    ContentBorderWidth = MainWindow.ActualWidth - MenuBorderWidth;
                    break;

                case WindowState.Minimized:
                    MainWindow.WindowState = WindowState.Minimized;
                    break;
            }
        }
        public IViewModel GetCurrentView() => CurrentView;
    }
}