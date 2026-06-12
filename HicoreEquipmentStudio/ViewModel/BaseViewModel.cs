using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HiCore.EquipmentFramework.Config.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(
            [CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }

        public virtual void Initialize()
        {

        }
    }
}