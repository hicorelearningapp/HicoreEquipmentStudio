using HicoreEquipmentStudio.Commands;
using HicoreEquipmentStudio.ViewModel;
using System.Collections.ObjectModel;
using System.Windows.Input;

public class ConfigurationViewModel : BaseViewModel
{
    public ICommand EquipmentInfoCommand { get; }
    public ICommand VariableCommand { get; }
    public ICommand AlarmCommand { get; }

    public ConfigurationViewModel()
    {
        VariableCommand =
            new RelayCommand(OpenVariables);

        AlarmCommand =
            new RelayCommand(OpenAlarms);


    }

    private void OpenVariables()
    {
        ViewModelStore.Instance.MainViewModel.CurrentViewModel =
            ViewModelStore.Instance.VariableViewModel;
    }

    private void OpenAlarms()
    {
        ViewModelStore.Instance.MainViewModel.CurrentViewModel =
            ViewModelStore.Instance.AlarmViewModel;
    }
}


//using HicoreEquipmentStudio.ViewModel;
//using System.Collections.ObjectModel;

//namespace HicoreEquipmentStudio.ViewModel
//{
//    public class ConfigurationViewModel : BaseViewModel
//    {
//        public ObservableCollection<ConfigurationItemViewModel> MenuItems { get; }

//        public ConfigurationViewModel()
//        {
//            MenuItems =
//                new ObservableCollection<ConfigurationItemViewModel>
//                {
//                    new ConfigurationItemViewModel(
//                        "Variables",
//                        "Variables",
//                        Navigate),

//                    new ConfigurationItemViewModel(
//                        "Alarms",
//                        "Alarms",
//                        Navigate)
//                };

//            SetSelected("Variables");
//        }

//        private void Navigate(string key)
//        {
//            SetSelected(key);

//            switch (key)
//            {
//                case "Variables":

//                    ViewModelStore.Instance.MainViewModel.CurrentViewModel =
//                        ViewModelStore.Instance.VariableViewModel;

//                    break;

//                case "Alarms":

//                    ViewModelStore.Instance.MainViewModel.CurrentViewModel =
//                        ViewModelStore.Instance.AlarmViewModel;

//                    break;
//            }
//        }

//        private void SetSelected(string key)
//        {
//            foreach (var item in MenuItems)
//            {
//                item.IsSelected = item.Key == key;
//            }
//        }
//    }
//}