using HicoreEquipmentStudio.ViewModel.Variable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HicoreEquipmentStudio.ViewModel.Alarms;
using HicoreEquipmentStudio.ViewModel.Events;

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

        private ViewModelStore()
        {
            VariableViewModel = new VariableViewModel();

            AlarmViewModel = new AlarmViewModel();

            MainViewModel = new MainViewModel();

            EventViewModel = new EventViewModel();
        }

        public void Initialize()
        {
            InitVM(VariableViewModel);
            InitVM(AlarmViewModel);
            InitVM(EventViewModel);
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


