using HicoreEquipmentStudio.ViewModel;

namespace HicoreEquipmentStudio.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _currentViewModel;

        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        
    }
}