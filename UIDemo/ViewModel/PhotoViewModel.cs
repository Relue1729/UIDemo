using UIDemo.Common;
using UIDemo.Common.Interfaces;
using UIDemo.Model;

namespace UIDemo.ViewModel
{
    class PhotoViewModel : ViewModelBase
    {
        public override IModel Model { get; } = new PhotoModel();
    }
}
