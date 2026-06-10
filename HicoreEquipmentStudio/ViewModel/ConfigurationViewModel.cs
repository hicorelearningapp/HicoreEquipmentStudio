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

