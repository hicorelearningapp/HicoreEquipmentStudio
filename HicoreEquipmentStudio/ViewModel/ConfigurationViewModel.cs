using HicoreEquipmentStudio.Commands;
using HicoreEquipmentStudio.ViewModel;
using System.Collections.ObjectModel;
using System.Windows.Input;

public class ConfigurationViewModel : BaseViewModel
{
    public ICommand EquipmentInfoCommand { get; }
    public ICommand VariableCommand { get; }
    public ICommand AlarmCommand { get; }
    public ICommand EventCommand { get; }

    public ICommand RecipeCommand { get; }

    public ICommand CommandsCommand { get; }

    public ConfigurationViewModel()
    {
        VariableCommand =
            new RelayCommand(OpenVariables);

        AlarmCommand =
            new RelayCommand(OpenAlarms);

        EventCommand =
            new RelayCommand(OpenEvents);

        RecipeCommand =
            new RelayCommand(OpenRecipes);

        CommandsCommand =
            new RelayCommand(OpenCommands);




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

    private void OpenEvents()
    {
        ViewModelStore.Instance.MainViewModel.CurrentViewModel =
            ViewModelStore.Instance.EventViewModel;
    }

    private void OpenRecipes()
    {
        ViewModelStore.Instance.MainViewModel.CurrentViewModel =
            ViewModelStore.Instance.RecipeViewModel;
    }

    private void OpenCommands()
    {
        ViewModelStore.Instance.MainViewModel.CurrentViewModel =
            ViewModelStore.Instance.CommandViewModel;
    }


}

