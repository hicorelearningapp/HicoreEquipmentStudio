using HicoreEquipmentStudio.ViewModel.Variable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HicoreEquipmentStudio.ViewModel.Alarms;

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

        private ViewModelStore()
        {
            VariableViewModel = new VariableViewModel();

            AlarmViewModel = new AlarmViewModel();

            MainViewModel = new MainViewModel();

        }

        public void Initialize()
        {
            InitVM(VariableViewModel);
            InitVM(AlarmViewModel);
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



//using HicoreEquipmentStudio.ViewModel.Variable;
//using System;

//namespace HicoreEquipmentStudio.ViewModel
//{
//    public sealed class ViewModelStore
//    {
//        private static readonly Lazy<ViewModelStore> _instance =
//            new Lazy<ViewModelStore>(() => new ViewModelStore());

//        public static ViewModelStore Instance => _instance.Value;

//        public MainViewModel MainViewModel { get; }

//        public ConfigurationViewModel ConfigurationViewModel { get; }

//        public VariableViewModel VariableViewModel { get; }

//        public AlarmViewModel AlarmViewModel { get; }

//        private ViewModelStore()
//        {
//            // Create Child ViewModels
//            VariableViewModel = new VariableViewModel();

//            AlarmViewModel = new AlarmViewModel();

//            ConfigurationViewModel = new ConfigurationViewModel();

//            MainViewModel = new MainViewModel();

//            // Default Screen
//            MainViewModel.CurrentViewModel = VariableViewModel;
//        }

//        public void Initialize()
//        {
//            InitVM(VariableViewModel);
//            InitVM(AlarmViewModel);
//            InitVM(ConfigurationViewModel);
//        }

//        private void InitVM(BaseViewModel vm)
//        {
//            try
//            {
//                vm?.Initialize();
//            }
//            catch (Exception ex)
//            {
//                System.Diagnostics.Debug.WriteLine(ex.Message);
//            }
//        }
//    }
//}