using HicoreEquipmentStudio.ViewModel.Variable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HicoreEquipmentStudio.ViewModel.Alarms;
using HicoreEquipmentStudio.ViewModel.Events;
using HicoreEquipmentStudio.View.Recipes;
using HicoreEquipmentStudio.ViewModel.Recipes;
using HicoreEquipmentStudio.ViewModel.Commands;
using HicoreEquipmentStudio.ViewModel.Mapping;

namespace HicoreEquipmentStudio.ViewModel
{
    public sealed class ViewModelStore
    {
        private static readonly Lazy<ViewModelStore> _instance =
            new Lazy<ViewModelStore>(() => new ViewModelStore());

        public static ViewModelStore Instance => _instance.Value;

        public MainViewModel MainViewModel { get; }

        public VariableViewModel VariableViewModel { get; }

        public AlarmViewModel AlarmViewModel { get; }

        public EventViewModel EventViewModel { get; }

        
        public RecipeViewModel RecipeViewModel { get; } 

        public CommandViewModel CommandViewModel { get; }
        public MappingViewModel MappingViewModel { get; }
        private ViewModelStore()
        {
            VariableViewModel = new VariableViewModel();

            AlarmViewModel = new AlarmViewModel();

            MainViewModel = new MainViewModel();

            EventViewModel = new EventViewModel();

            RecipeViewModel = new RecipeViewModel();

            CommandViewModel = new CommandViewModel();
            MappingViewModel = new MappingViewModel();
        }

        public void Initialize()
        {
            InitVM(VariableViewModel);
            InitVM(AlarmViewModel);
            InitVM(EventViewModel);
            InitVM(RecipeViewModel);
            InitVM(CommandViewModel);
            InitVM(MappingViewModel);
        }

        private void InitVM(BaseViewModel vm)
        {
            try
            {
                vm?.Initialize();
            }
            catch
            {
                // Log Error
            }
        }
    }
}


