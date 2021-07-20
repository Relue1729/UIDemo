using System.ComponentModel;
using System.Runtime.CompilerServices;
using UIDemo.Common.Interfaces;

namespace UIDemo.Common
{
    abstract class ViewModelBase : INotifyPropertyChanged, IViewModel
    {
        abstract public IModel Model { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
