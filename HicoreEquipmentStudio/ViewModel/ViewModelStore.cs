using HicoreEquipmentStudio.Interfaces;
using HicoreEquipmentStudio.Repository;
using HicoreEquipmentStudio.ViewModel.Alarms;
using HicoreEquipmentStudio.ViewModel.Commands;
using HicoreEquipmentStudio.ViewModel.Events;
using HicoreEquipmentStudio.ViewModel.Mapping;
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

        private readonly ConfigurationRepository _repository;

        public MainViewModel MainViewModel { get; }

        public VariableViewModel VariableViewModel { get; }

        public AlarmViewModel AlarmViewModel { get; }

        public EventViewModel EventViewModel { get; }

        public RecipeViewModel RecipeViewModel { get; }

        public CommandViewModel CommandViewModel { get; }

        public EquipmentInfoViewModel EquipmentInfoViewModel { get; }

        private ViewModelStore()
        {
            _repository = new ConfigurationRepository();

            VariableViewModel = new VariableViewModel(_repository);

            AlarmViewModel = new AlarmViewModel(_repository);

            EventViewModel = new EventViewModel(_repository);

            RecipeViewModel = new RecipeViewModel(_repository);

            CommandViewModel = new CommandViewModel(_repository);

            EquipmentInfoViewModel = new EquipmentInfoViewModel();

            MainViewModel = new MainViewModel();
        }

        public ConfigurationRepository Repository
        {
            get { return _repository; }
        }

        public void Initialize()
        {
            InitVM(VariableViewModel);
            InitVM(AlarmViewModel);
            InitVM(EventViewModel);
            InitVM(RecipeViewModel);
            InitVM(CommandViewModel);
            InitVM(EquipmentInfoViewModel);
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
            catch
            {
                // Log Error
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