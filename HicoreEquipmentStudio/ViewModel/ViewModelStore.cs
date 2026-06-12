using HicoreEquipmentStudio.Core;
using HicoreEquipmentStudio.Interfaces;
using HicoreEquipmentStudio.ViewModel.Alarms;
using HicoreEquipmentStudio.ViewModel.Commands;
using HicoreEquipmentStudio.ViewModel.Events;
using HicoreEquipmentStudio.ViewModel.Recipes;
using HicoreEquipmentStudio.ViewModel.Variable;
using System;
using System.Collections.Generic;

namespace HicoreEquipmentStudio.ViewModel
{
    public sealed class ViewModelStore
    {
        private static readonly Lazy<ViewModelStore> _instance =
            new Lazy<ViewModelStore>(() => new ViewModelStore());

        public static ViewModelStore Instance
        {
            get { return _instance.Value; }
        }

        public EquipmentManager EquipmentManager { get; private set; }

        public MainViewModel MainViewModel { get; private set; }

        public EquipmentInfoViewModel EquipmentInfoViewModel { get; private set; }

        public VariableViewModel VariableViewModel { get; private set; }

        public AlarmViewModel AlarmViewModel { get; private set; }

        public EventViewModel EventViewModel { get; private set; }

        public RecipeViewModel RecipeViewModel { get; private set; }

        public CommandViewModel CommandViewModel { get; private set; }

        private ViewModelStore()
        {
            EquipmentManager = new EquipmentManager();

            MainViewModel = new MainViewModel();

            EquipmentInfoViewModel =
                new EquipmentInfoViewModel(EquipmentManager);

            VariableViewModel =
                new VariableViewModel(EquipmentManager);

            AlarmViewModel =
                new AlarmViewModel(EquipmentManager);

            EventViewModel =
                new EventViewModel(EquipmentManager);

            RecipeViewModel =
                new RecipeViewModel(EquipmentManager);

            CommandViewModel =
                new CommandViewModel(EquipmentManager);
        }

        public void Initialize()
        {
            InitVM(EquipmentInfoViewModel);
            InitVM(VariableViewModel);
            InitVM(AlarmViewModel);
            InitVM(EventViewModel);
            InitVM(RecipeViewModel);
            InitVM(CommandViewModel);
        }

        private void InitVM(BaseViewModel vm)
        {
            try
            {
                if (vm != null)
                {
                    vm.Initialize();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public IEnumerable<IJsonSectionProvider> GetExportProviders()
        {
            return new IJsonSectionProvider[]
            {
                EquipmentInfoViewModel,
                VariableViewModel,
                AlarmViewModel,
                EventViewModel,
                RecipeViewModel,
                CommandViewModel
            };
        }
    }
}